using NetCore31Skeleton.Library.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Repository.Context;

namespace NetCore31Skeleton.WebApi.Repository
{
    public interface ICoreRepository<Tentity,Ttype> : IGenericRepository<Tentity,Ttype, CoreDbContext>
        where Tentity : class, IGenericModel<Ttype>
        where Ttype : struct
    {
    }
}
