using NetCore31Skeleton.WebApi.Core.Results;
using NetCore31Skeleton.WebApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCore31Skeleton.WebApi.Business.Interfaces
{
    public interface ITransactionBusiness
    {
        IDataResult<List<Transaction>> GetAll();

        Task<IDataResult<List<Transaction>>> GetAllAsync();

        IDataResult<Transaction> GetByQuery(Expression<Func<Transaction, bool>> predicate);

        Task<IDataResult<Transaction>> GetByQueryAsync(Expression<Func<Transaction, bool>> predicate);

        IDataResult<Transaction> GetById(long Id);

        Task<IDataResult<Transaction>> InsertAsync(Transaction entity);
        IDataResult<Transaction> Insert(Transaction entity);
        IDataResult<Transaction> Update(Transaction entity);
        Task<IDataResult<Transaction>> UpdateAsync(Transaction entity);
        IDataResult<Transaction> Delete(Transaction entity);
    }
}
