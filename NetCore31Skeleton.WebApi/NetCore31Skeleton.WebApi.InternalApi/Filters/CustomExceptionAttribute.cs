using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetCore31Skeleton.WebApi.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore31Skeleton.WebApi.InternalApi
{
    public class CustomExceptionAttribute : Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            //var response = new ErrorResult(500, context.Exception.Message);

            //context.Result = new OkObjectResult(response);
        }

    }
}
