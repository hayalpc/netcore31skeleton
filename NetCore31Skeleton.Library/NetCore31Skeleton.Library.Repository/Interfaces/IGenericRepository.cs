using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCore31Skeleton.Library.Repository.Interfaces
{
    public interface IGenericRepository<Ttype, Tentity, Tcontext> 
        where Tentity : class, IGenericModel<Ttype> 
        where Tcontext : DbContext 
        where Ttype : struct
    {
        DbSet<Tentity> GetContext();
        IQueryable<Tentity> GetQuery(Expression<Func<Tentity, bool>> predicate);
        Tentity Get(Expression<Func<Tentity, bool>> predicate);
        Tentity GetById(Ttype Id);
        Tentity GetByIdNoTracking(Ttype Id);

        int SaveChanges();
        Task<int> SaveChangesAsync();

        void Insert(Tentity entity);
        void InsertRange(IEnumerable<Tentity> entities);
        void Update(Tentity entity);
        void Update(Tentity entity, params string[] fields)
        void UpdateRange(IEnumerable<Tentity> entities);
        void Delete(Tentity entity);
        void DeleteRange(IEnumerable<Tentity> entities);
    }
}
