using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetCore31Skeleton.WebApi.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore31Skeleton.WebApi.InternalApi.Filters
{
    public class CustomValidateAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.ModelState.IsValid)
            {
                List<string> errorMessages = new List<string>();

                context.ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList().ForEach(x => errorMessages.Add(x));

                var delimiter = "; ";
                var message = "Please solve the following error(s): " + errorMessages.Aggregate((i, j) => i + delimiter + j);
                var response = new ErrorResult(message);
                context.Result = new OkObjectResult(response);
            }
        }
    }
}
