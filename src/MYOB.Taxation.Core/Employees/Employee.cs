using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYOB.Employees
{
    public class Employee : Entity<long>, IMustHaveTenant
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal GrossIncome { get; set; }

        public string SalaryBand { get; set; }

        public DateTime PaymentStartDate { get; set; }

        public decimal SuperRate { get; set; }

        public int TenantId { get; set; } // For IMustHaveTenant
    }
}
