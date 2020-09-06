using NetCore31Skeleton.WebApi.Core.Results;
using NetCore31Skeleton.WebApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetCore31Skeleton.WebApi.Business.Interfaces
{
    public interface ITransactionBusiness
    {
        IDataResult<List<Transaction>> GetAll();

        IDataResult<Transaction> GetByQuery(Expression<Func<Transaction, bool>> predicate);

        IDataResult<Transaction> GetById(long Id);

        IDataResult<Transaction> Insert(Transaction entity);
        IDataResult<Transaction> Update(Transaction entity);
        IDataResult<Transaction> Delete(Transaction entity);
    }
}
