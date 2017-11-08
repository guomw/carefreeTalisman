using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using web.Common;
using Newtonsoft.Json;
using service.Model;
using web.Filters;
using System.Text;

/// <summary>
/// 
/// </summary>
namespace web.Controllers
{
    public class HomeController : AdminBaseController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var value = GetAuthClainValue(AuthorizationStorageType.UserData);
            var user = JsonConvert.DeserializeObject<UserModel>(value);
            return View(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {

            return View();
        }

    }
}
