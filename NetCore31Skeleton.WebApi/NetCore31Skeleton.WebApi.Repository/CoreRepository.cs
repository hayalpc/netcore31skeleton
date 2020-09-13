using NetCore31Skeleton.Library.Repository;
using NetCore31Skeleton.Library.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Repository.Context;

namespace NetCore31Skeleton.WebApi.Repository
{
    public class CoreRepository<Tentity,Ttype> : GenericRepository<Tentity,Ttype, CoreDbContext>, ICoreRepository<Tentity,Ttype>
        where Tentity : class, IGenericModel<Ttype>
        where Ttype : struct
    {
        public CoreRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
