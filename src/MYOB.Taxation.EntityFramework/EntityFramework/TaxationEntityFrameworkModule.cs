using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;

namespace MYOB.Taxation.EntityFramework
{
    [DependsOn(
        typeof(TaxationCoreModule), 
        typeof(AbpZeroEntityFrameworkModule))]
    public class TaxationEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TaxationDbContext>());
            Configuration.MultiTenancy.IsEnabled = true;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}