using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace MYOB.Employees.Payslips
{
    public class Payslip : Entity<long>, IMustHaveTenant
    {
        public string Title { get; set; }

        public string Name { get; set; }

        public string PayPeriod { get; set; }

        public decimal GrossIncome { get; set; }

        public decimal IncomeTax { get; set; }

        public decimal NetIncome { get; set; }

        public decimal Super { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        public virtual long? EmployeeId { get; set; }
        

        public Payslip()
        {

        }

        public Payslip(string title)
            : this()
        {
            Title = title;
        }

        public int TenantId { get; set; } // For IMustHaveTenant
    }
}