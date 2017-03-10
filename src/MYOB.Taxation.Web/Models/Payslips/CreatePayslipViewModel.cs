using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MYOB.Taxation.Employees.Dto;

namespace MYOB.Taxation.Web.Models.Payslips
{
    public class CreatePayslipViewModel
    {
        public List<SelectListItem> Employees { get; set; }

        public GetEmployeePayslipOutputs Payslip { get; set; }

        public CreatePayslipViewModel(List<SelectListItem> employees)
        {
            Employees = employees;
        }
    }
}