using NetCore31Skeleton.Core.Dtos;
using NetCore31Skeleton.Core.Results;
using NetCore31Skeleton.WebApi.Repository.Models;

namespace NetCore31Skeleton.WebApi.Business.Interfaces
{
    public interface IUserBusiness : ICoreBusiness<AppUser,int>
    {

        IDataResult<AppUser> FindByUserName(string username);

        IDataResult<AppUser> Login(LoginDto loginDto);

        IResult Register(RegisterDto registerDto);

    }
}
