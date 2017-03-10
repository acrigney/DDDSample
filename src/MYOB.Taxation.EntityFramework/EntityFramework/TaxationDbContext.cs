using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Microsoft.Extensions.Configuration;
using MYOB.Taxation.Authorization.Roles;
using MYOB.Taxation.Configuration;
using MYOB.Taxation.MultiTenancy;
using MYOB.Taxation.Users;
using MYOB.Taxation.Web;
using MYOB.Employees;
using MYOB.Employees.Payslips;
using MYOB.Taxation.Employees.Tax;

namespace MYOB.Taxation.EntityFramework
{
    [DbConfigurationType(typeof(TaxationDbConfiguration))]
    public class TaxationDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */
        public virtual IDbSet<Employee> Employees { get; set; }
        public virtual IDbSet<Payslip> Payslips { get; set; }

        public virtual IDbSet<TaxRate> TaxRates { get; set; }
        public virtual IDbSet<TaxTimeRate> TaxTimeRates { get; set; }


        /* Default constructor is needed for EF command line tool. */
        public TaxationDbContext()
            : base(GetConnectionString())
        {

        }

        private static string GetConnectionString()
        {
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder()
                );

            return configuration.GetConnectionString(
                TaxationConsts.ConnectionStringName
                );
        }

        /* This constructor is used by ABP to pass connection string.
         * Notice that, actually you will not directly create an instance of TaxationDbContext since ABP automatically handles it.
         */
        public TaxationDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection. */
        public TaxationDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }

        public TaxationDbContext(DbConnection dbConnection, bool contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection)
        {

        }
    }

    public class TaxationDbConfiguration : DbConfiguration
    {
        public TaxationDbConfiguration()
        {
            SetProviderServices(
                "System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance
            );
        }
    }
}
