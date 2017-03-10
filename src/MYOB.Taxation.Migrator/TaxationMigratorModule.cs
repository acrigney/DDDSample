using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using MYOB.Taxation.Configuration;
using MYOB.Taxation.EntityFramework;

namespace MYOB.Taxation.Migrator
{
    [DependsOn(typeof(TaxationEntityFrameworkModule))]
    public class TaxationMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public TaxationMigratorModule()
        {
            _appConfiguration = AppConfigurations.Get(
                typeof(TaxationMigratorModule).Assembly.GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Database.SetInitializer<TaxationDbContext>(null);

            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                TaxationConsts.ConnectionStringName
                );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}