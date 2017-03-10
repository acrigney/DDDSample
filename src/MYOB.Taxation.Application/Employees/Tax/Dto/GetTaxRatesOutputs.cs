using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MYOB.Employees;
using MYOB.Employees.Dto;

namespace MYOB.Taxation.Employees.Dto
{
    public class GetTaxRatesOutputs
    {
        public decimal BaseTaxAmount { get; set; }
        public decimal BaseTaxLowerLimit { get; set; }
        public decimal ExtraIncomeTaxRate { get; set; }

    }
}
