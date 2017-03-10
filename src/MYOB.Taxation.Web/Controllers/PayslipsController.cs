using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MYOB.Taxation.Employees;
using MYOB.Employees.Dto;
using MYOB.Taxation.Web.Models.Payslips;
using MYOB.Taxation.Employees.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using Abp.Application.Services.Dto;

namespace MYOB.Taxation.Web.Controllers
{
    public class PayslipsController : TaxationControllerBase
    {
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IEmployeeTaxAppService _employeeTaxAppService;

        public PayslipsController(IEmployeeAppService employeeAppService, IEmployeeTaxAppService employeeTaxAppService)
        {
            _employeeAppService = employeeAppService;
            _employeeTaxAppService = employeeTaxAppService;
        }

        public async Task<ActionResult> Index()
        {
            GetEmployeesInput getEmployeesInput = new GetEmployeesInput();
            var output = await _employeeAppService.GetEmployeesAsync(getEmployeesInput);

            //SelectList x= new SelectList()
            List<SelectListItem> employees = new List<SelectListItem>(output.Employees.Select(x => new SelectListItem() { Text = x.LastName, Value = x.Id }));

            employees.Insert(0, new SelectListItem { Value = string.Empty, Text = L("Unassigned"), Selected = true });

            var model = new PayslipViewModel(employees);
            return View(model);
        }

        [HttpPost]
        public ActionResult Display(GetEmployeePayslipOutputs getEmployeePayslipOutputs)
        {
            //var output = await _employeeTaxAppService.GetPaySlip(employee, DateTime.Now);
            //var model = new CreatePayslipViewModel(employee);
            return View("Display", getEmployeePayslipOutputs);
        }
    }
}

