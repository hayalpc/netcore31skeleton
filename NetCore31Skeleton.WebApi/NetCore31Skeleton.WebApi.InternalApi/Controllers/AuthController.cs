using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore31Skeleton.Core.Dtos;
using NetCore31Skeleton.Core.Enums;
using NetCore31Skeleton.Core.Results;
using NetCore31Skeleton.WebApi.Business.Interfaces;
using NetCore31Skeleton.WebApi.Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace NetCore31Skeleton.WebApi.InternalApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenCreator tokenCreator;
        private readonly IUserBusiness userBusiness;
        private readonly IUserRoleBusiness userRoleBusiness;
        private readonly IMapper mapper;

        public AuthController(ITokenCreator tokenCreator, IUserBusiness userBusiness, IUserRoleBusiness userRoleBusiness, IMapper mapper)
        {
            this.tokenCreator = tokenCreator;
            this.userBusiness = userBusiness;
            this.userRoleBusiness = userRoleBusiness;
            this.mapper = mapper;
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
                var roles = new List<string>();
                userRoleBusiness.GetRolesByUserId(user.Id).Data.ForEach((result)=> roles.Add(result.Name));
                var session = new SessionDto();
                session.User = mapper.Map<UserDto>(user);
                session.Roles = string.Join(",",roles.Select(x=>x.ToString()).ToArray());
                var res = new SuccessDataResult<SessionDto>(session);
                return Ok(res);
            }
            return Unauthorized();
        }


    }
}
