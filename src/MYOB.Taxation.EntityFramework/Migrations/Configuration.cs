using System;
using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using MYOB.Taxation.Migrations.SeedData;
using EntityFramework.DynamicFilters;
using MYOB.Taxation.Employees.Tax;
using MYOB.Employees;

namespace MYOB.Taxation.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<Taxation.EntityFramework.TaxationDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Taxation";
        }

        protected override void Seed(Taxation.EntityFramework.TaxationDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();
            TaxTimeRate taxTimeRateFrom2012 = new TaxTimeRate() {  Id = 1, StartDate = new DateTime(2012, 1, 1) };

            taxTimeRateFrom2012.TaxRates.Add(new TaxRate() { Id = 1, SalaryBand = "Band 0", TaxLevel = new TaxLevel() { MinLevel = 0, MaxLevel = 18200, BaseTaxRate = 0, ExtraTaxRate = 0.0M } });
            taxTimeRateFrom2012.TaxRates.Add(new TaxRate() { Id = 2, SalaryBand = "Band 1", TaxLevel = new TaxLevel() { MinLevel = 18201, MaxLevel = 37000, BaseTaxRate = 0, ExtraTaxRate = 0.19M } });
            taxTimeRateFrom2012.TaxRates.Add(new TaxRate() { Id = 3, SalaryBand = "Band 2", TaxLevel = new TaxLevel() { MinLevel = 37001, MaxLevel = 80000, BaseTaxRate = 3572, ExtraTaxRate = 0.325M } });
            taxTimeRateFrom2012.TaxRates.Add(new TaxRate() { Id = 4, SalaryBand = "Band 3", TaxLevel = new TaxLevel() { MinLevel = 80001, MaxLevel = 180000, BaseTaxRate = 17547, ExtraTaxRate = 0.37M } });
            taxTimeRateFrom2012.TaxRates.Add(new TaxRate() { Id = 5, SalaryBand = "Band 4", TaxLevel = new TaxLevel() { MinLevel = 180001, MaxLevel = 1000000, BaseTaxRate = 54547, ExtraTaxRate = 0.45M } });

            context.TaxTimeRates.AddOrUpdate(x => new { x.Id }, taxTimeRateFrom2012);

            context.Employees.AddOrUpdate(x => new { x.Id }, new Employee() { FirstName = "Band0FirstName1", LastName = "Band0LastName1", GrossIncome = 0, SalaryBand = "Band 0", SuperRate = 0.09M, PaymentStartDate = new DateTime(2012, 1, 1), TenantId = 1 });
            context.Employees.AddOrUpdate(x => new { x.Id }, new Employee() { FirstName = "Band0FirstName2", LastName = "Band0LastName2", GrossIncome = 7000, SalaryBand = "Band 0", SuperRate = 0.09M, PaymentStartDate = new DateTime(2012, 1, 1), TenantId = 1 });
            context.Employees.AddOrUpdate(x => new { x.Id }, new Employee() { FirstName = "Band0FirstName3", LastName = "Band0LastName3", GrossIncome = 18200, SalaryBand = "Band 0", SuperRate = 0.09M, PaymentStartDate = new DateTime(2012, 1, 1), TenantId = 1 });

            context.Employees.AddOrUpdate(x => new { x.Id }, new Employee() { FirstName = "Band1FirstName1", LastName = "Band1LastName1", GrossIncome = 18201, SalaryBand = "Band 1", SuperRate = 0.09M, PaymentStartDate = new DateTime(2012, 1, 1), TenantId = 1 });
            context.Employees.AddOrUpdate(x => new { x.Id }, new Employee() { FirstName = "Band1FirstName2", LastName = "Band1LastName2", GrossIncome = 20000, SalaryBand = "Band 1", SuperRate = 0.09M, PaymentStartDate = new DateTime(2012, 1, 1), TenantId = 1 });
            context.Employees.AddOrUpdate(x => new { x.Id }, new Employee() { FirstName = "Band1FirstName3", LastName = "Band1LastName3", GrossIncome = 37000, SalaryBand = "Band 1", SuperRate = 0.09M, PaymentStartDate = new DateTime(2012, 1, 1), TenantId = 1 });

            context.Employees.AddOrUpdate(x => new { x.Id }, new Employee() { FirstName = "Band2FirstName1", LastName = "Band2LastName1", GrossIncome = 37001, SalaryBand = "Band 2", SuperRate = 0.09M, PaymentStartDate = new DateTime(2012, 1, 1), TenantId = 1 });
            context.Employees.AddOrUpdate(x => new { x.Id }, new Employee() { FirstName = "Band2FirstName2", LastName = "Band2LastName2", GrossIncome = 60050, SalaryBand = "Band 2", SuperRate = 0.09M, PaymentStartDate = new DateTime(2012, 1, 1), TenantId = 1 });
            context.Employees.AddOrUpdate(x => new { x.Id }, new Employee() { FirstName = "Band2FirstName3", LastName = "Band2LastName3", GrossIncome = 80000, SalaryBand = "Band 2", SuperRate = 0.09M, PaymentStartDate = new DateTime(2012, 1, 1), TenantId = 1 });

            context.Employees.AddOrUpdate(x => new { x.Id }, new Employee() { FirstName = "Band3FirstName1", LastName = "Band3LastName1", GrossIncome = 80001, SalaryBand = "Band 3", SuperRate = 0.09M, PaymentStartDate = new DateTime(2012, 1, 1), TenantId = 1 });
            context.Employees.AddOrUpdate(x => new { x.Id }, new Employee() { FirstName = "Band3FirstName2", LastName = "Band3LastName2", GrossIncome = 99050, SalaryBand = "Band 3", SuperRate = 0.09M, PaymentStartDate = new DateTime(2012, 1, 1), TenantId = 1 });
            context.Employees.AddOrUpdate(x => new { x.Id }, new Employee() { FirstName = "Band3FirstName3", LastName = "Band3LastName3", GrossIncome = 180000, SalaryBand = "Band 3", SuperRate = 0.09M, PaymentStartDate = new DateTime(2012, 1, 1), TenantId = 1 });

            context.Employees.AddOrUpdate(x => new { x.Id }, new Employee() { FirstName = "Band4FirstName1", LastName = "Band4LastName1", GrossIncome = 180001, SalaryBand = "Band 4", SuperRate = 0.09M, PaymentStartDate = new DateTime(2012, 1, 1), TenantId = 1 });
            context.Employees.AddOrUpdate(x => new { x.Id }, new Employee() { FirstName = "Band4FirstName2", LastName = "Band4LastName2", GrossIncome = 200000, SalaryBand = "Band 4", SuperRate = 0.09M, PaymentStartDate = new DateTime(2012, 1, 1), TenantId = 1 });
            context.Employees.AddOrUpdate(x => new { x.Id }, new Employee() { FirstName = "Band4FirstName3", LastName = "Band4LastName3", GrossIncome = 1000000, SalaryBand = "Band 4", SuperRate = 0.09M, PaymentStartDate = new DateTime(2012, 1, 1), TenantId = 1 });

            context.SaveChanges();
        }
    }
}
