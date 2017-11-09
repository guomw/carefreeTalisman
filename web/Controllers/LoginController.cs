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

namespace web.Controllers
{
    public class LoginController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (IsAuthenticated)
                await AuthenticationHttpContextExtensions.SignOutAsync(HttpContext, authenticationScheme);


            //IDemoService demoService = ServiceFactory<IDemoService>.Factory();

            //demoService.Insert(new UserModel()
            //{
            //    UserName = "admin",
            //    UserPassword = EncryptHelper.md5DigestAsHex("123456"),
            //    UserRole = "π‹¿Ì‘±"

            //});

            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string userpassword)
        {

            UserModel userData = new UserModel()
            {
                Id = 1,
                UserName = username,
                UserPassword = utils.EncryptHelper.md5DigestAsHex(userpassword),
                UserRole = "admin",
                UserCreateTime = DateTime.Now
            };
            this.SetsAuthenticationAsync(JsonConvert.SerializeObject(userData), AuthorizationStorageType.UserData);

            return RedirectToRoute("home");
        }
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}