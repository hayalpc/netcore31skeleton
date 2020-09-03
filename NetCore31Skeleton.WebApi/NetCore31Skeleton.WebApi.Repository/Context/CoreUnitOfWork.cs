using NetCore31Skeleton.Library.Repository;

namespace NetCore31Skeleton.WebApi.Repository.Context
{
    public class CoreUnitOfWork : GenericUnitOfWork<CoreDbContext>
    {
        public CoreUnitOfWork(CoreDbContext context) : base(context)
        {
        }
    }
}
