using MYOB.Taxation.EntityFramework;
using EntityFramework.DynamicFilters;

namespace MYOB.Taxation.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly TaxationDbContext _context;

        public InitialHostDbBuilder(TaxationDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
