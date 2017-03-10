using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MYOB.Employees;
using MYOB.Employees.Dto;

namespace MYOB.Taxation.Employees.Dto
{
    public class GetEmployeesOutputs
    {
        public List<EmployeeDto> Employees { get; set; }
    }
}
