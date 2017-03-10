using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using MYOB.Taxation.Employees.Dto;
using MYOB.Employees.Dto;

namespace MYOB.Taxation.Employees
{
    public interface IEmployeeTaxAppService : IApplicationService
    {
        Task<GetTaxRatesOutputs> GetTaxRates(EmployeeDto employee, DateTime payslipDateTime);

        Task<GetEmployeePayslipOutputs> GetPaySlip(EmployeeDto employee, DateTime payslipDateTime);

        Task<GetEmployeePayslipOutputs> GetPaySlip(long employeeId, DateTime? payslipDateTime);

        Task<GetEmployeePayslipOutputs> GetPaySlipForWeb(GetPayslipDto getPayslipDto);

    }
}
