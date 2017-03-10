using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using MYOB.Taxation.Authorization;
using MYOB.Employees;
using MYOB.Employees.Dto;

namespace MYOB.Taxation
{
    [DependsOn(
        typeof(TaxationCoreModule),
        typeof(AbpAutoMapperModule))]
    public class TaxationApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TaxationAuthorizationProvider>();
            Configuration.MultiTenancy.IsEnabled = true;
            InitializeAutoMapper();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        private void InitializeAutoMapper()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                mapper.CreateMap<EmployeeDto, Employee>();

                mapper.CreateMap<Employee, EmployeeDto>();


            });


        }
    }
}