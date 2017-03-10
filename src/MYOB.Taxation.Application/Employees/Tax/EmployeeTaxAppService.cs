
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using AutoMapper;
using Castle.Core.Logging;
using Newtonsoft.Json;
using MYOB.Taxation;
using MYOB.Employees;
using MYOB.Taxation.Employees.Dto;
using MYOB.Employees.Dto;
using MYOB.Employees.Tax;
using MYOB.Taxation.Employees.Tax;

namespace MYOB.Taxation.Employees
{
    public class EmployeeTaxAppService : TaxationAppServiceBase, IEmployeeTaxAppService
    {
        //private static readonly TracerX.Logger InfoLog = TracerX.Logger.GetLogger("EmployeeAppService-Info");
        private readonly IRepository<Employee, long> _employeeRepository;
        private readonly IRepository<TaxTimeRate, long> _taxTimeRateRepository;


        public EmployeeTaxAppService(IRepository<Employee, long> employeeRepository, IRepository<TaxTimeRate, long> taxTimeRateRepository)
        {
            _employeeRepository = employeeRepository;
            _taxTimeRateRepository = taxTimeRateRepository;

            //InfoLog.LoggingStyle = ConfigurationFacade.LoggingStyle;
        }

        public async Task<GetTaxRatesOutputs> GetTaxRates(EmployeeDto employee, DateTime payslipDateTime)
        {
            var taxTimeRates = await _taxTimeRateRepository.GetAllListAsync();

            // Tax rates can be changed for each year and will be the same until a new tax rate is specified for subsequent years.
            // So get the tax rate for the required payslipDateTime by finding the first tax rate that has a time that is >= the required time
            // Hence we can get the payslip for any date in the past.
            var taxTimeRate = taxTimeRates.OrderByDescending(x => x.StartDate).FirstOrDefault(x => payslipDateTime >= x.StartDate);

            if (taxTimeRate == null)
            {
                throw new Exception(String.Format("Tax rate not found for date {0}", payslipDateTime));
            }

            var taxRate = taxTimeRate.TaxRates.Where(x => (employee.GrossIncome >= x.TaxLevel.MinLevel) && (employee.GrossIncome <= x.TaxLevel.MaxLevel)).FirstOrDefault();

            if (taxRate == null)
            {
                throw new Exception(String.Format("Tax rate not found for tax time rate {0} and income {1}", taxTimeRate.StartDate, employee.GrossIncome));
            }

            return (new GetTaxRatesOutputs() { BaseTaxAmount = taxRate.TaxLevel.BaseTaxRate, BaseTaxLowerLimit = taxRate.TaxLevel.MinLevel, ExtraIncomeTaxRate = taxRate.TaxLevel.ExtraTaxRate });
        }

        public async Task<GetEmployeePayslipOutputs> GetPaySlip(EmployeeDto employee, DateTime payslipDateTime)
        {
            MonthlyEmployeeTaxCalculator monthlyEmployeeTaxCalculator = new MonthlyEmployeeTaxCalculator();

            var taxRate = await GetTaxRates(employee, payslipDateTime);

            GetEmployeePayslipOutputs paySlip = new GetEmployeePayslipOutputs() {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PayPeriod = monthlyEmployeeTaxCalculator.GetMonthlyPayPeriod(payslipDateTime),
                GrossIncome = monthlyEmployeeTaxCalculator.GetMonthlyGrossIncomeRounded(employee.GrossIncome),
                IncomeTax = monthlyEmployeeTaxCalculator.GetMonthlyIncomeTaxRounded(taxRate.BaseTaxAmount, taxRate.BaseTaxLowerLimit, taxRate.ExtraIncomeTaxRate, employee.GrossIncome)

            };

            paySlip.NetIncome = monthlyEmployeeTaxCalculator.GetMonthlyNetIncomeRounded(
                paySlip.GrossIncome, paySlip.IncomeTax);

            paySlip.Super = monthlyEmployeeTaxCalculator.GetMonthlySuperRounded(paySlip.GrossIncome, employee.SuperRate);

            return paySlip;
        }

        public async Task<GetEmployeePayslipOutputs> GetPaySlip(long employeeId, DateTime? payslipDateTime)
        {
            if (!payslipDateTime.HasValue)
            {
                payslipDateTime = DateTime.Now;
            }
            var employees = await _employeeRepository.GetAllListAsync(x => x.Id == employeeId);
            var employeeDtos = Mapper.Map<List<EmployeeDto>>(employees);
            var employee = employeeDtos.FirstOrDefault();

            if (employee == null)
            {
                throw new Exception(String.Format("Employee with id {0} not found", employeeId));
            }

            return (await GetPaySlip(employee, payslipDateTime.Value));
        }

        public async Task<GetEmployeePayslipOutputs> GetPaySlipForWeb(GetPayslipDto getPayslipDto)
        {
            return (await GetPaySlip(long.Parse(getPayslipDto.Id), null));
        }
    }
}
