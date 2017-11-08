using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using web.Common;
using Newtonsoft.Json;
using service.Model;

namespace web.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            if (!IsAuthenticated)
                return RedirectToAction("login", "login");

            string value = this.GetAuthClainValue(AuthorizationStorageType.UserData);
            if (string.IsNullOrEmpty(value))
                return RedirectToAction("login", "login");

            var user = JsonConvert.DeserializeObject<UserModel>(value);            
            return View(user);
        }
    }
}
