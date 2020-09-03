using NetCore31Skeleton.Library.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Business.Interfaces;
using NetCore31Skeleton.WebApi.Core.Results;
using NetCore31Skeleton.WebApi.Repository.Context;
using NetCore31Skeleton.WebApi.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore31Skeleton.WebApi.Business
{
    public class NoteBusiness : INoteBusiness
    {
        private readonly INoteRepository repository;
        private readonly IGenericUnitOfWork<CoreDbContext> unitOfWork;

        public NoteBusiness(INoteRepository repository, IGenericUnitOfWork<CoreDbContext> unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IDataResult<Note> Delete(Note entity)
        {
            try
            {
                unitOfWork.BeginTransaction();
                repository.Delete(entity);
                unitOfWork.SaveChanges();
                unitOfWork.CommitTransaction();
                return new SuccessDataResult<Note>(entity);
            }
            catch (Exception exp)
            {
                unitOfWork.RollBackTransaction();
                return new ErrorDataResult<Note>(500,exp.Message);
            }
        }

        public IDataResult<List<Note>> GetAll()
        {
            try
            {
                unitOfWork.SetIsolationLevel(System.Data.IsolationLevel.Snapshot);
                var entity = repository.GetAll().ToList();
                return new SuccessDataResult<List<Note>>(entity);
            }
            catch (Exception exp)
            {
                return new ErrorDataResult<List<Note>>(500, exp.Message);
            }
        }

        public IDataResult<Note> GetById(long Id)
        {
            try
            {
                unitOfWork.SetIsolationLevel(System.Data.IsolationLevel.Snapshot);
                var entity = repository.Get(Id);
                return new SuccessDataResult<Note>(entity);
            }
            catch (Exception exp)
            {
                return new ErrorDataResult<Note>(500, exp.Message);
            }
        }

        public IDataResult<Note> Insert(Note entity)
        {
            try
            {
                unitOfWork.BeginTransaction();
                repository.Insert(entity);
                unitOfWork.SaveChanges();
                unitOfWork.CommitTransaction();
                return new SuccessDataResult<Note>(entity);
            }
            catch (Exception exp)
            {
                unitOfWork.RollBackTransaction();
                return new ErrorDataResult<Note>(500, exp.Message);
            }
        }

        public IDataResult<Note> Update(Note entity)
        {
            try
            {
                unitOfWork.BeginTransaction();
                repository.Update(entity);
                unitOfWork.SaveChanges();
                unitOfWork.CommitTransaction();
                return new SuccessDataResult<Note>(entity);
            }
            catch (Exception exp)
            {
                unitOfWork.RollBackTransaction();
                return new ErrorDataResult<Note>(500, exp.Message);
            }
        }
    }
}
