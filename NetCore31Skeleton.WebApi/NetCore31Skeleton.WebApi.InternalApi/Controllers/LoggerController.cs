using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore31Skeleton.Library.Log;
using NLog;

namespace NetCore31Skeleton.WebApi.InternalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {

        private readonly IGenericLogger logger;

        public LoggerController(IGenericLogger logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            logger.Debug("selam Debug");
            logger.Info("selam Info");
            logger.Warning("selam Warning");
            logger.Error("selam Error");
            return Ok();
        }
    }
}
