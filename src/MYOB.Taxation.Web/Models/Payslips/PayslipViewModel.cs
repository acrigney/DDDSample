using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using MYOB.Employees.Dto;

namespace MYOB.Taxation.Web.Models.Payslips
{
    public class PayslipViewModel
    {
        public List<SelectListItem> Employees { get; set; }

        public PayslipViewModel(List<SelectListItem> employees)
        {
            Employees = employees;
        }

        //public List<SelectListItem> GetTasksStateSelectListItems(ILocalizationManager localizationManager)
        //{
        //    var list = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Text = localizationManager.GetString(SimpleTaskAppConsts.LocalizationSourceName, "AllTasks"),
        //            Value = "",
        //            Selected = SelectedTaskState == null
        //        }
        //    };

        //    list.AddRange(Enum.GetValues(typeof(TaskState))
        //            .Cast<TaskState>()
        //            .Select(state =>
        //                new SelectListItem
        //                {
        //                    Text = localizationManager.GetString(SimpleTaskAppConsts.LocalizationSourceName, $"TaskState_{state}"),
        //                    Value = state.ToString(),
        //                    Selected = state == SelectedTaskState
        //                })
        //    );

        //    return list;
        //}
    }
}
