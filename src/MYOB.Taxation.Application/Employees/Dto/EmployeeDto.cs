using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYOB.Employees.Dto
{
    public class EmployeeDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal GrossIncome { get; set; }

        public string SalaryBand { get; set; }

        public DateTime PaymentStartDate { get; set; }

        public decimal SuperRate { get; set; }

    }
}
