using Microsoft.EntityFrameworkCore;
using NetCore31Skeleton.Library.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NetCore31Skeleton.Library.Repository
{
    public abstract class GenericRepository<Ttype, Tentity, Tcontext> : IGenericRepository<Ttype, Tentity, Tcontext>
        where Tentity : class, IGenericModel<Ttype>
        where Tcontext : DbContext
        where Ttype : struct
    {
        protected readonly Tcontext context;

        public GenericRepository(Tcontext context)
        {
            this.context = context;
        }

        public IEnumerable<Tentity> GetAll()
        {
            return context.Set<Tentity>().ToList();
        }

        public Tentity Get(Ttype Id)
        {
            return context.Set<Tentity>().Find(Id);
        }

        public void Insert(Tentity entity)
        {
            context.Set<Tentity>().Add(entity);
        }

        public void Update(Tentity entity)
        {
            context.Set<Tentity>().Update(entity);
        }

        public void Delete(Tentity entity)
        {
            context.Set<Tentity>().Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public IEnumerable<Tentity> Find(Expression<Func<Tentity, bool>> predicate)
        {
            return context.Set<Tentity>().Where(predicate);
        }

        public void InsertRange(IEnumerable<Tentity> entities)
        {
            context.Set<Tentity>().AddRange(entities);
        }

        public void DeleteRange(IEnumerable<Tentity> entities)
        {
            context.Set<Tentity>().RemoveRange(entities);
        }
    }
}
