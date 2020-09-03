using NetCore31Skeleton.WebApi.Core.Results;
using NetCore31Skeleton.WebApi.Repository.Models;
using System.Collections.Generic;

namespace NetCore31Skeleton.WebApi.Business.Interfaces
{
    public interface INoteBusiness
    {
        IDataResult<List<Note>> GetAll();

        IDataResult<Note> GetById(long Id);

        IDataResult<Note> Insert(Note entity);
        IDataResult<Note> Update(Note entity);
        IDataResult<Note> Delete(Note entity);
    }
}
