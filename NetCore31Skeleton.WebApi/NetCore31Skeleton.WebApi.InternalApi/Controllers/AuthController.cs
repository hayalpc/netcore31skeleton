using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore31Skeleton.WebApi.Core.Results;
using NetCore31Skeleton.WebApi.Core.Utils.Interfaces;

namespace NetCore31Skeleton.WebApi.InternalApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ITokenCreator tokenCreator;

        public AuthController(ITokenCreator tokenCreator)
        {
            this.tokenCreator = tokenCreator;
        }

        [HttpGet]
        public IDataResult<string> Login()
        {
            return new SuccessDataResult<string>(tokenCreator.CreateToken(),"Success");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Validate()
        {
            return Ok();
        }
    }
}
