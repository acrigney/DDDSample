using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace MYOB.Taxation.Web.Views
{
    public abstract class TaxationRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected TaxationRazorPage()
        {
            LocalizationSourceName = TaxationConsts.LocalizationSourceName;
        }
    }
}
