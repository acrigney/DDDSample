using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MYOB.Employees;
using MYOB.Employees.Dto;

namespace MYOB.Taxation.Employees.Dto
{
    public class GetEmployeePayslipOutputs
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PayPeriod { get; set; }
        public decimal GrossIncome { get; set; }
        public decimal NetIncome { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal Super { get; set; }
    }
}
