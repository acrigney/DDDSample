using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYOB.Taxation.Employees.Dto
{
    public class GetEmployeesInput
    {
        public long? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal? GrossIncome { get; set; }

        public string SalaryBand { get; set; }

    }
}
