using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NetCore31Skeleton.Library.Log;
using NetCore31Skeleton.WebApi.Core.Results;

namespace NetCore31Skeleton.WebApi.InternalApi.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly IGenericLogger logger;

        public ErrorController(IGenericLogger logger)
        {
            this.logger = logger;
        }

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
                case HttpStatusCode.InternalServerError:
                    var errorInfo = HttpContext.Features.Get<IExceptionHandlerFeature>();
                    logger.Error(errorInfo.Error.ToString());
                    return Ok(new ErrorResult(500, "InternalError " + errorInfo.Error.Message));
                    break;
                default:
                    return Ok(new ErrorResult(500, "InternalError"));
                    break;
            }

        }
    }
}
