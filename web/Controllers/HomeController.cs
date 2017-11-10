using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using web.Common;
using Newtonsoft.Json;
using service.Entity;
using web.Filters;
using System.Text;
using web.ViewModel;
using service.DAL;
using service.Repository;
using service.Interface;
using service;
using service.Interface.Impl;

/// <summary>
/// 
/// </summary>
namespace web.Controllers
{
    public class HomeController : AdminBaseController
    {
        private IDemoService demoService= new DemoServiceImpl();

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
            List<UserModel> lst = new List<UserModel>();
            lst = demoService.GetAllList().ToList();
            ViewUserModel view = new ViewUserModel()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalPage = 2,
                TotalRecord = demoService.Count(),
                Rows = lst
            };
            return View(view);
        }




    }
}
