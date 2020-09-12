using Microsoft.EntityFrameworkCore;
using NetCore31Skeleton.Library.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        public DbSet<Tentity> GetContext()
        {
            return context.Set<Tentity>();
        }

        public IQueryable<Tentity> GetQuery(Expression<Func<Tentity, bool>> predicate)
        {
            return context.Set<Tentity>().Where(predicate);
        }

        public Tentity Get(Expression<Func<Tentity, bool>> predicate)
        {
            return context.Set<Tentity>().Where(predicate).AsNoTracking().FirstOrDefault();
        }

        public Tentity GetByIdNoTracking(Ttype Id)
        {
            var entity = context.Set<Tentity>().Find(Id);
            if (entity != null)
                context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public Tentity GetById(Ttype Id)
        {
            var entity = context.Set<Tentity>().Find(Id);
            return entity;
        }

        public void Insert(Tentity entity)
        {
            context.Set<Tentity>().Add(entity);
        }

        public void Update(Tentity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.Set<Tentity>().Update(entity);
        }

        public void Update(Tentity entity, List<string> fields)
        {
            var attack = context.Set<Tentity>().Attach(entity);
            foreach (var field in fields)
            {
                if (entity.GetType().GetProperty(field) != null)//geçersiz bir 
                {
                    attack.Property(field).IsModified = true;
                }
                else
                {
                    throw new Exception($"{field} is not a property of " + entity.GetType().Name);
                }
            }
        }

        public void Update(Tentity entity, params string[] fields)
        {
            var attack = context.Set<Tentity>().Attach(entity);
            foreach (var field in fields)
            {
                if (entity.GetType().GetProperty(field) != null)//geçersiz bir 
                {
                    attack.Property(field).IsModified = true;
                }
                else
                {
                    throw new Exception($"{field} is not a property of " + entity.GetType().Name);
                }
            }
        }

        public void Delete(Tentity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.Set<Tentity>().Remove(entity);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void InsertRange(IEnumerable<Tentity> entities)
        {
            context.Set<Tentity>().AddRange(entities);
        }

        public void UpdateRange(IEnumerable<Tentity> entities)
        {
            context.Entry(entities).State = EntityState.Modified;
            context.Set<Tentity>().UpdateRange(entities);
        }

        public void DeleteRange(IEnumerable<Tentity> entities)
        {
            context.Entry(entities).State = EntityState.Deleted;
            context.Set<Tentity>().RemoveRange(entities);
        }

    }
}
