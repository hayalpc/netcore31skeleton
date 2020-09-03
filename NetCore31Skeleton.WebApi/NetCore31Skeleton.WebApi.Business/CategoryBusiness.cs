using NetCore31Skeleton.WebApi.Business.Interfaces;
using NetCore31Skeleton.WebApi.Core.Results;
using NetCore31Skeleton.WebApi.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore31Skeleton.WebApi.Business
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly ICategoryRepository repository;

        public CategoryBusiness(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public IDataResult<Category> Delete(Category entity)
        {
            try
            {
                repository.Delete(entity);
                repository.SaveChanges();
                return new SuccessDataResult<Category>(entity);
            }
            catch (Exception exp)
            {
                return new ErrorDataResult<Category>(500,exp.Message);
            }
        }

        public IDataResult<List<Category>> GetAll()
        {
            try
            {
                var entity = repository.GetAll().ToList();
                return new SuccessDataResult<List<Category>>(entity);
            }
            catch (Exception exp)
            {
                return new ErrorDataResult<List<Category>>(500, exp.Message);
            }
        }

        public IDataResult<Category> GetById(long Id)
        {
            try
            {
                var entity = repository.Get(Id);
                return new SuccessDataResult<Category>(entity);
            }
            catch (Exception exp)
            {
                return new ErrorDataResult<Category>(500, exp.Message);
            }
        }

        public IDataResult<Category> Insert(Category entity)
        {
            try
            {
                repository.Update(entity);
                repository.SaveChanges();
                return new SuccessDataResult<Category>(entity);
            }
            catch (Exception exp)
            {
                return new ErrorDataResult<Category>(500, exp.Message);
            }
        }

        public IDataResult<Category> Update(Category entity)
        {
            try
            {
                repository.Update(entity);
                repository.SaveChanges();
                return new SuccessDataResult<Category>(entity);
            }
            catch (Exception exp)
            {
                return new ErrorDataResult<Category>(500, exp.Message);
            }
        }
    }
}
