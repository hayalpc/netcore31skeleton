using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore31Skeleton.WebApi.Core.Results;

namespace NetCore31Skeleton.WebApi.InternalApi.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet("/error/{code}")]
        public IActionResult Get(int code)
        {
            switch ((HttpStatusCode)code)
            {
                case HttpStatusCode.NotFound:
                    return NotFound(new ErrorResult(404, "PageNotFound"));
                    break;
                case HttpStatusCode.Unauthorized:
                    return Unauthorized(new ErrorResult(401, "Unauthorized"));
                    break;
                case HttpStatusCode.BadGateway:
                    return Unauthorized(new ErrorResult(502, "BadGateway"));
                    break;
                default:
                    return Ok(new ErrorResult(500, "InternalError"));
                    break;
            }

        }
    }
}
