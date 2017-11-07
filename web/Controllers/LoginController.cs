using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace web.Controllers
{
    public class LoginController : BaseController
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Login(string name)
        {

            this.SetsAuthenticationAsync("userName", name, 30);

            //return RedirectToAction("Forbidden", "login");

            return View();
        }

        [Authorize]
        public IActionResult Forbidden()
        {
            string userName = this.GetAuthClainValue("userName");
            return View();
        }
    }
}