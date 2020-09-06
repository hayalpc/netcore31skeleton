using NetCore31Skeleton.Library.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Business.Interfaces;
using NetCore31Skeleton.WebApi.Core.Results;
using NetCore31Skeleton.WebApi.Repository.Context;
using NetCore31Skeleton.WebApi.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NetCore31Skeleton.WebApi.Business
{
    public class TransactionBusiness : ITransactionBusiness
    {
        private readonly ITransactionRepository repository;
        private readonly IGenericUnitOfWork<CoreDbContext> unitOfWork;

        public TransactionBusiness(ITransactionRepository repository, IGenericUnitOfWork<CoreDbContext> unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IDataResult<Transaction> Delete(Transaction entity)
        {
            try
            {
                repository.Delete(entity);
                unitOfWork.SaveChanges();
                return new SuccessDataResult<Transaction>(entity);
            }
            catch (Exception exp)
            {
                return new ErrorDataResult<Transaction>(500,exp.Message);
            }
        }

        public IDataResult<List<Transaction>> GetAll()
        {
            try
            {
                unitOfWork.SetIsolationLevel(System.Data.IsolationLevel.ReadUncommitted);
                var entity = repository.GetQuery(x=>x.StatusId == Library.Repository.Status.Active).ToList();
                return new SuccessDataResult<List<Transaction>>(entity);
            }
            catch (Exception exp)
            {
                return new ErrorDataResult<List<Transaction>>(500, exp.Message);
            }
        }

        public IDataResult<Transaction> GetById(long Id)
        {
            try
            {
                unitOfWork.SetIsolationLevel(System.Data.IsolationLevel.ReadUncommitted);
                var entity = repository.GetById(Id);
                return new SuccessDataResult<Transaction>(entity);
            }
            catch (Exception exp)
            {
                return new ErrorDataResult<Transaction>(500, exp.Message);
            }
        }

        public IDataResult<Transaction> GetByQuery(Expression<Func<Transaction, bool>> predicate)
        {
            try
            {
                unitOfWork.SetIsolationLevel(System.Data.IsolationLevel.ReadUncommitted);
                var entity = repository.GetQuery(predicate).FirstOrDefault();
                return new SuccessDataResult<Transaction>(entity);
            }
            catch (Exception exp)
            {
                return new ErrorDataResult<Transaction>(500, exp.Message);
            }
        }

        public IDataResult<Transaction> Insert(Transaction entity)
        {
            try
            {
                repository.Insert(entity);
                unitOfWork.SaveChanges();
                return new SuccessDataResult<Transaction>(entity);
            }
            catch (Exception exp)
            {
                return new ErrorDataResult<Transaction>(500, exp.Message);
            }
        }

        public IDataResult<Transaction> Update(Transaction entity)
        {
            try
            {
                repository.Update(entity);
                unitOfWork.SaveChanges();
                return new SuccessDataResult<Transaction>(entity);
            }
            catch (Exception exp)
            {
                return new ErrorDataResult<Transaction>(500, exp.Message);
            }
        }
    }
}
