using NetCore31Skeleton.WebApi.Core.Results;
using NetCore31Skeleton.WebApi.Repository.Models;
using System.Collections.Generic;

namespace NetCore31Skeleton.WebApi.Business.Interfaces
{
    public interface ICategoryBusiness
    {
        IDataResult<List<Category>> GetAll();

        IDataResult<Category> GetById(long Id);

        IDataResult<Category> Insert(Category entity);
        IDataResult<Category> Update(Category entity);
        IDataResult<Category> Delete(Category entity);
    }
}
