using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using MYOB.Taxation.Employees.Dto;

namespace MYOB.Taxation.Employees
{
    public interface IEmployeeAppService : IApplicationService
    {
        Task<GetEmployeesOutputs> GetEmployeesAsync(GetEmployeesInput getEmployeesInput);

    }
}
