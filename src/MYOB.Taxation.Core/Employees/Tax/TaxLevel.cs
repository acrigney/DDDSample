using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MYOB.Taxation.Employees.Tax
{
    [ComplexType]
    public class TaxLevel
    {
        public decimal MinLevel { get; set; }

        public decimal MaxLevel { get; set; }

        public decimal BaseTaxRate { get; set; }

        public decimal ExtraTaxRate { get; set; }

    }
}
