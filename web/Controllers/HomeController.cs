using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using web.Common;
using Newtonsoft.Json;
using service.entity;
using web.Filters;
using System.Text;
using web.ViewModel;

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
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IActionResult List(int pageIndex = 1, int pageSize = 10)
        {
            var value = GetAuthClainValue(AuthorizationStorageType.UserData);
            var user = JsonConvert.DeserializeObject<UserModel>(value);
            List<UserModel> lst = new List<UserModel>();
            lst.Add(user);
            ViewUserModel view = new ViewUserModel()
            {
                PageIndex = pageIndex,
                PageSize=pageSize,
                TotalPage = 2,
                TotalRecord = 20,
                Rows = lst
            };
            return View(view);
        }




    }
}
