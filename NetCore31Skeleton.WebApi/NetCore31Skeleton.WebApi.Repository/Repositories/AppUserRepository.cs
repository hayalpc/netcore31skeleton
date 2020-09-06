using NetCore31Skeleton.Library.Repository;
using NetCore31Skeleton.WebApi.Repository.Context;
using NetCore31Skeleton.WebApi.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Repository.Models;

namespace NetCore31Skeleton.WebApi.Repository
{
    public class AppUserRepository : GenericRepository<int, AppUser, CoreDbContext>, IAppUserRepository
    {
        public AppUserRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
