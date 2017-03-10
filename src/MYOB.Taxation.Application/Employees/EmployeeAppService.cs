
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

namespace MYOB.Taxation.Employees
{
    public class EmployeeAppService : TaxationAppServiceBase, IEmployeeAppService
    {
        //private static readonly TracerX.Logger InfoLog = TracerX.Logger.GetLogger("EmployeeAppService-Info");
        private readonly IRepository<Employee, long> _employeeRepository;


        public EmployeeAppService(IRepository<Employee, long> employeeRepository)
        {
            _employeeRepository = employeeRepository;

            //InfoLog.LoggingStyle = ConfigurationFacade.LoggingStyle;
        }

        public async Task<GetEmployeesOutputs> GetEmployeesAsync(GetEmployeesInput getEmployeeInput)
        {
            //InfoLog.CategoryDebugFormat("MatchesApplicationService", "Async MatchesApplicationService for getMatchesInput = {0}.",
            //     JsonConvert.SerializeObject(getMatchesInput).ToString());

            // N.B> For queries that require the return of nested object data (Not required in this case).
            // ASP.NET boilerplate supports GetAllIncluding. However this is only with EF. As we have to allow for
            // a change in database then we can just use a Linq query to generate an IQueryable which will still provide
            // us with a generic solution for nested searches as when the query is executed it will include the query parameters.
            // i.e the query will not scan the database!
            List<Employee> employees = null;

            if (getEmployeeInput.SalaryBand != null) // Only used for testing.
            {
                employees = await _employeeRepository.GetAllListAsync(x => x.SalaryBand == getEmployeeInput.SalaryBand);
            }
            else if (getEmployeeInput.Id.HasValue)
            {
                employees = await _employeeRepository.GetAllListAsync(x => x.Id == getEmployeeInput.Id);
                //employees = await Task.Run(() => _employeeRepository.GetAll().Where(x => x.Id == getEmployeeInput.Id));
            }
            else
            {
                employees = await _employeeRepository.GetAllListAsync();
//                employees = await Task.Run(() => _employeeRepository.GetAll());
            }

            var employeesList = employees.ToList();

            return new GetEmployeesOutputs
            {
                Employees = Mapper.Map<List<EmployeeDto>>(employeesList)
            };
        }
    }
}
