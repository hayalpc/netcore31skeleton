using Microsoft.EntityFrameworkCore;
using NetCore31Skeleton.Library.Log;
using NetCore31Skeleton.Library.Repository;
using NetCore31Skeleton.Library.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Business.Interfaces;
using NetCore31Skeleton.WebApi.Core.Results;
using NetCore31Skeleton.WebApi.Repository;
using NetCore31Skeleton.WebApi.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCore31Skeleton.WebApi.Business.Concrete
{
    public abstract class CoreBusiness<Tentity, Ttype> : ICoreBusiness<Tentity,Ttype>
        where Tentity : class, IGenericModel<Ttype>
        where Ttype : struct
    {
        private readonly ICoreRepository<Tentity, Ttype> repository;
        private readonly IGenericUnitOfWork<CoreDbContext> unitOfWork;
        private readonly IGenericLogger logger;

        public CoreBusiness(ICoreRepository<Tentity, Ttype> repository, IGenericUnitOfWork<CoreDbContext> unitOfWork, IGenericLogger logger)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public IDataResult<Tentity> Delete(Tentity entity)
        {
            try
            {
                repository.Delete(entity);
                unitOfWork.SaveChanges();
                return new SuccessDataResult<Tentity>(entity);
            }
            catch (Exception exp)
            {
                return new ErrorDataResult<Tentity>(500, exp.Message);
            }
        }

        public IDataResult<List<Tentity>> GetAll()
        {
            try
            {
                unitOfWork.SetIsolationLevel(System.Data.IsolationLevel.ReadUncommitted);
                var entity = repository.GetQuery(x => x.StatusId == Status.Active).ToList();
                return new SuccessDataResult<List<Tentity>>(entity);
            }
            catch (Exception exp)
            {
                return new ErrorDataResult<List<Tentity>>(500, exp.Message);
            }
        }

        public async Task<IDataResult<List<Tentity>>> GetAllAsync()
        {
            try
            {
                unitOfWork.SetIsolationLevel(System.Data.IsolationLevel.ReadUncommitted);
                var entity = await repository.GetQuery(x => x.StatusId == Status.Active).ToListAsync();
                return new SuccessDataResult<List<Tentity>>(entity);
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
                return new ErrorDataResult<List<Tentity>>(500, exp.Message);
            }
        }

        public IDataResult<Tentity> GetById(Ttype Id)
        {
            try
            {
                var entity = repository.GetById(Id);
                return new SuccessDataResult<Tentity>(entity);
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
                return new ErrorDataResult<Tentity>(500, exp.Message);
            }
        }

        public IDataResult<Tentity> GetByQuery(Expression<Func<Tentity, bool>> predicate)
        {
            try
            {
                unitOfWork.SetIsolationLevel(System.Data.IsolationLevel.ReadUncommitted);
                var entity = repository.GetQuery(predicate).FirstOrDefault();
                return new SuccessDataResult<Tentity>(entity);
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
                return new ErrorDataResult<Tentity>(500, exp.Message);
            }
        }

        public IDataResult<List<Tentity>> GetAllByQuery(Expression<Func<Tentity, bool>> predicate)
        {
            try
            {
                unitOfWork.SetIsolationLevel(System.Data.IsolationLevel.ReadUncommitted);
                var entity = repository.GetQuery(predicate).ToList();
                return new SuccessDataResult<List<Tentity>>(entity);
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
                return new ErrorDataResult<List<Tentity>>(500, exp.Message);
            }
        }

        public async Task<IDataResult<Tentity>> GetByQueryAsync(Expression<Func<Tentity, bool>> predicate)
        {
            try
            {
                unitOfWork.SetIsolationLevel(System.Data.IsolationLevel.ReadUncommitted);
                var entity = await repository.GetQuery(predicate).FirstOrDefaultAsync();
                return new SuccessDataResult<Tentity>(entity);
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
                return new ErrorDataResult<Tentity>(500, exp.Message);
            }
        }

        public IDataResult<Tentity> Insert(Tentity entity)
        {
            try
            {
                repository.Insert(entity);
                unitOfWork.SaveChanges();
                return new SuccessDataResult<Tentity>(entity);
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
                logger.Error(entity.ToString());
                return new ErrorDataResult<Tentity>(500, exp.Message);
            }
        }

        public async Task<IDataResult<Tentity>> InsertAsync(Tentity entity)
        {
            try
            {
                repository.Insert(entity);
                await unitOfWork.SaveChangesAsync();
                return new SuccessDataResult<Tentity>(entity);
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
                logger.Error(entity.ToString());
                return new ErrorDataResult<Tentity>(500, exp.Message);
            }
        }

        public IDataResult<Tentity> Update(Tentity entity)
        {
            try
            {
                repository.Update(entity);
                unitOfWork.SaveChanges();
                return new SuccessDataResult<Tentity>(entity);
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
                logger.Error(entity.ToString());
                return new ErrorDataResult<Tentity>(500, exp.Message);
            }
        }

        public async Task<IDataResult<Tentity>> UpdateAsync(Tentity entity)
        {
            try
            {
                repository.Update(entity);
                await unitOfWork.SaveChangesAsync();
                return new SuccessDataResult<Tentity>(entity);
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
                logger.Error(entity.ToString());
                return new ErrorDataResult<Tentity>(500, exp.Message);
            }
        }
    }
}
