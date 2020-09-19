using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore31Skeleton.Web.Filters;

namespace NetCore31Skeleton.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [TypeFilter(typeof(JwtAuthorize), Arguments = new object[] { "Admin" })]
        public IActionResult Index()
        {
            return Ok("admin area");
        }
    }
}
