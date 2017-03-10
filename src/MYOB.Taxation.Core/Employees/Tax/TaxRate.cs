using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace MYOB.Taxation.Employees.Tax
{
    public class TaxRate : Entity<long>
    {
        public string SalaryBand { get; set; }

        [ForeignKey("TaxTimeRateId")]
        public virtual TaxTimeRate TaxTimeRate { get; set; }
        public virtual long? TaxTimeRateId { get; set; }

        public TaxLevel TaxLevel { get; set; } // super rate (assume super could vary)

    }
}
