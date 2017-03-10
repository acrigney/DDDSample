using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace MYOB.Taxation.EntityFramework.Repositories
{
    public abstract class TaxationRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<TaxationDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected TaxationRepositoryBase(IDbContextProvider<TaxationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class TaxationRepositoryBase<TEntity> : TaxationRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected TaxationRepositoryBase(IDbContextProvider<TaxationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
