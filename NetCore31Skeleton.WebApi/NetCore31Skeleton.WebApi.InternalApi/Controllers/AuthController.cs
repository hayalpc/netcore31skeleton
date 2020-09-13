using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore31Skeleton.WebApi.Business.Interfaces;
using NetCore31Skeleton.WebApi.Core.Dtos;
using NetCore31Skeleton.WebApi.Core.Enums;
using NetCore31Skeleton.WebApi.Core.Results;
using NetCore31Skeleton.WebApi.Core.Utils;
using NetCore31Skeleton.WebApi.Repository.Models;

namespace NetCore31Skeleton.WebApi.InternalApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenCreator tokenCreator;
        private readonly IUserBusiness userBusiness;
        private readonly IUserRoleBusiness userRoleBusiness;

        public AuthController(ITokenCreator tokenCreator, IUserBusiness userBusiness, IUserRoleBusiness userRoleBusiness)
        {
            this.tokenCreator = tokenCreator;
            this.userBusiness = userBusiness;
            this.userRoleBusiness = userRoleBusiness;
        }

        [HttpPost]
        public IDataResult<string> Login(LoginDto loginDto)
        {

            var userResult = userBusiness.Login(loginDto);
            if (userResult.Success)
            {
                var user = userResult.Data;
                var roles = userRoleBusiness.GetRolesByUserId(user.Id);
                if (roles.Success)
                    return new SuccessDataResult<string>(tokenCreator.CreateToken(userResult.Data, roles.Data), "Success");
                else
                    return new ErrorDataResult<string>(401, "RolesNotFound");
            }
            else
            {
                return new ErrorDataResult<string>(401, "UserNotFound");
            }
        }

        [Authorize(Roles = RoleInfo.Admin)]
        [HttpPost]
        public IResult Register(RegisterDto registerDto)
        {
            return userBusiness.Register(registerDto);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Validate()
        {
            var user = userBusiness.GetByQuery(x => x.StatusId == Library.Repository.Status.Active && x.Username == User.Identity.Name).Data;
            if (user != null)
            {
                return Ok();
            }
            return Unauthorized();
        }


    }
}
