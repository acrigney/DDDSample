using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MYOB.Employees.Tax
{
    public class MonthlyEmployeeTaxCalculator
    {
        //
        public string GetMonthlyPayPeriod(DateTime currentTime)
        {
            int daysInMonth = DateTime.DaysInMonth(currentTime.Year, currentTime.Month);

            string payPeriod = String.Format("Month of {0} (01 to {1})", currentTime.ToString("MMMM"), daysInMonth);

            return (payPeriod);
        }

        public decimal GetMonthlyGrossIncomeRounded(decimal grossYearlyIncome)
        {
            decimal monthlyGrossIncome = grossYearlyIncome/12;

            decimal monthlyGrossIncomeRounded = Math.Round(monthlyGrossIncome, 0, MidpointRounding.AwayFromZero);

            return (monthlyGrossIncomeRounded);
        }

        public decimal GetMonthlyIncomeTaxRounded(decimal baseTaxAmount, decimal baseTaxLowerLimit, decimal baseTaxRate, decimal grossYearlyIncome)
        {

            decimal monthlyIncomeTax = (baseTaxAmount + (grossYearlyIncome - baseTaxLowerLimit) * baseTaxRate) /12;

            decimal monthlyIncomeTaxRounded = Math.Round(monthlyIncomeTax, 0, MidpointRounding.AwayFromZero);

            return (monthlyIncomeTaxRounded);
        }

        public decimal GetMonthlyNetIncomeRounded(decimal monthlyGrossIncomeRounded, decimal monthlyIncomeTaxRounded)
        {
            decimal monthlyNetIncomeRounded = (monthlyGrossIncomeRounded - monthlyIncomeTaxRounded);

            return (monthlyNetIncomeRounded);
        }

        public decimal GetMonthlySuperRounded(decimal monthlyGrossIncomeRounded, decimal superRate)
        {
            decimal monthlySuperRounded = (monthlyGrossIncomeRounded * superRate);

            decimal monthlySuperRoundedRounded = Math.Round(monthlySuperRounded, 0, MidpointRounding.AwayFromZero);

            return (monthlySuperRoundedRounded);
        }


    }
}
