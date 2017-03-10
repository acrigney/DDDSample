using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace MYOB.Taxation.Employees.Tax
{
    public class TaxTimeRate : Entity<long> // Applies to all tenants
    {
        private HashSet<TaxRate> _taxRates;
        public DateTime StartDate { get; set; }

        public virtual HashSet<TaxRate> TaxRates
        {
            get { return _taxRates ?? (_taxRates = new HashSet<TaxRate>()); }
            set { _taxRates = value; }
        }

    }
}
