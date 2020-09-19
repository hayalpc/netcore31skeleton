using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetCore31Skeleton.Core.Dtos;
using NetCore31Skeleton.Core.Utils.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCore31Skeleton.Web.Filters
{
    public class JwtAuthorize : ActionFilterAttribute
    {
        public string Roles { get; set; }
        private readonly IHttpClientHelperFactory clientHelperFactory;

        public JwtAuthorize(string Roles, IHttpClientHelperFactory clientHelperFactory)
        {
            this.clientHelperFactory = clientHelperFactory;
            this.Roles = Roles;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Session.GetString("token");
            if (string.IsNullOrWhiteSpace(token))
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
            else
            {
                if (Roles != "*")
                {
                    var helper = clientHelperFactory.Create<string, HttpResponseMessage>();
                    helper.AddToken(token);
                    var result = helper.Get(ConfigurationManager.AppSettings["ApiUrl"], "auth/validate");
                    if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        context.HttpContext.Session.Remove("token");
                        context.Result = new RedirectToActionResult("Logout", "Home", new { type = "401", @area = "" });
                    }
                    else if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var roles = Roles.Split(",");
                        var sessionDto = JsonConvert.DeserializeObject<SessionDto>(result.Content.ReadAsStringAsync().Result);
                        var userRoles = sessionDto.Roles.Split(",");
                        foreach (var role in roles)
                        {
                            if (!userRoles.Where(x => x == role).Any())
                            {
                                context.HttpContext.Session.Remove("token");
                                context.Result = new RedirectToActionResult("Logout", "Home", new { type = "401", @area = "" });
                            }
                        }
                    }
                    else
                    {
                        context.HttpContext.Session.Remove("token");
                        context.Result = new RedirectToActionResult("Error", "Home", new { type = result.StatusCode, @area = "" });
                    }
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
