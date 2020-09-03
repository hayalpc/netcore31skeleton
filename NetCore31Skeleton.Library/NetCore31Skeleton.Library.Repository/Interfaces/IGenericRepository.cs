using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NetCore31Skeleton.Library.Repository.Interfaces
{
    public interface IGenericRepository<Ttype, T, Tcontext> 
        where T : class, IGenericModel<Ttype> 
        where Tcontext : DbContext 
        where Ttype : struct
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        T Get(Ttype Id);

        void SaveChanges();

        void Insert(T entity);
        void InsertRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

    }
}
