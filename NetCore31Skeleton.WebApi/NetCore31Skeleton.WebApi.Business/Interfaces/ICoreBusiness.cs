using NetCore31Skeleton.Library.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Core.Results;
using NetCore31Skeleton.WebApi.Repository;
using NetCore31Skeleton.WebApi.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCore31Skeleton.WebApi.Business.Interfaces
{
    public interface ICoreBusiness<Tentity,Ttype> 
        where Tentity : class , IGenericModel<Ttype> 
        where Ttype : struct
    {
        IDataResult<List<Tentity>> GetAll();

        Task<IDataResult<List<Tentity>>> GetAllAsync();

        IDataResult<Tentity> GetByQuery(Expression<Func<Tentity, bool>> predicate);

        IDataResult<List<Tentity>> GetAllByQuery(Expression<Func<Tentity, bool>> predicate);

        Task<IDataResult<Tentity>> GetByQueryAsync(Expression<Func<Tentity, bool>> predicate);

        IDataResult<Tentity> GetById(Ttype Id);

        Task<IDataResult<Tentity>> InsertAsync(Tentity entity);
        IDataResult<Tentity> Insert(Tentity entity);
        IDataResult<Tentity> Update(Tentity entity);
        Task<IDataResult<Tentity>> UpdateAsync(Tentity entity);
        IDataResult<Tentity> Delete(Tentity entity);
    }
}
