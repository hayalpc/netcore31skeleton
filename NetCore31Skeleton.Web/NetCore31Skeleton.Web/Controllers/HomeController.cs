using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCore31Skeleton.Core.Dtos;
using NetCore31Skeleton.Library.Log;
using NetCore31Skeleton.Web.Filters;
using NetCore31Skeleton.Web.Models;
using NetCore31Skeleton.Web.Services.Interfaces;
using NetCore31Skeleton.Web.ViewModels;

namespace NetCore31Skeleton.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericLogger logger;
        private readonly IUserServices userServices;
        public HomeController(IGenericLogger logger, IUserServices userServices)
        {
            this.logger = logger;
            this.userServices = userServices;
        }

        [TypeFilter(typeof(JwtAuthorize), Arguments = new object[] { "*" })]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/giris")]
        public IActionResult Login()
        {
            var loginVM = new LoginVM();
            return View(loginVM);
        }

        [HttpPost("/giris")]
        public IActionResult Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = userServices.Login(loginVM);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Username", "Giriş Başarısız");
                }
            }
            return View(loginVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
