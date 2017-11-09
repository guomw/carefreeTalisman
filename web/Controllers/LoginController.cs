using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Authorization;
using utils.ApiResultModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using service.entity;
using Newtonsoft.Json;
using web.Common;
using Microsoft.AspNetCore.Authentication;
using service;
using service.Interface;
using utils;
using service.DAL;
using service.repository;
using service.Interface.Impl;

namespace web.Controllers
{
    public class LoginController : BaseController
    {
        private IDemoService demoService;
        public LoginController(DBHelperContext ctx) : base(ctx)
        {
            demoService=new DemoServiceImpl(ctx);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (IsAuthenticated)
                await AuthenticationHttpContextExtensions.SignOutAsync(HttpContext, authenticationScheme);

            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string userpassword)
        {
            UserModel userData = demoService.Get(p => p.UserName == username && p.UserPassword.Equals(EncryptHelper.md5DigestAsHex(userpassword)));
            if (userData == null)
            {
                ViewData["resultCode"] = 1;
                ViewData["errorMsg"] = "用户名或密码错误";
                return View();
            }
            userData.LastUpdateTime = DateTime.Now;
            demoService.Update(userData);
            this.SetsAuthenticationAsync(JsonConvert.SerializeObject(userData), AuthorizationStorageType.UserData);

            return RedirectToRoute("home");
        }
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}