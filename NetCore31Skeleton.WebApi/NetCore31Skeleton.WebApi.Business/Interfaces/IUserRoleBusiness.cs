using NetCore31Skeleton.WebApi.Core.Results;
using NetCore31Skeleton.WebApi.Repository.Models;
using System.Collections.Generic;

namespace NetCore31Skeleton.WebApi.Business.Interfaces
{
    public interface IUserRoleBusiness : ICoreBusiness<AppUserRole,int>
    {
        IDataResult<List<AppRole>> GetRolesByUserId(int Id);
    }
}
