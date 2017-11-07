using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using web.Filters;
using utils;
using utils.ApiResultModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;

namespace web.Controllers
{

    public class BaseController : Controller
    {
        /// <summary>
        /// 返回json格式
        /// </summary>
        /// <param name="apiResult"></param>
        /// <returns></returns>
        protected ActionResult GetContent(ApiResult apiResult)
        {
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return Content(JsonConvert.SerializeObject(apiResult, Startup.settings), "application/json", System.Text.Encoding.UTF8);

        }


        /// <summary>
        /// 设置授权认证数
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="value"></param>
        /// <param name="Expires">时效，单位分钟</param>
        public async void SetsAuthenticationAsync(string keyName, string value, long Expires = 60 * 24)
        {
            var claims = new List<Claim>()
            {
              new Claim(keyName,value)
            };
            var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            await HttpContext.Authentication.SignInAsync("Cookie", userPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(Expires),
                IsPersistent = false,
                AllowRefresh = false
            });
        }

        /// <summary>
        /// 获取授权数据
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public string GetAuthClainValue(string keyName)
        {
            string value = string.Empty;
            Task<AuthenticateInfo> authenticateInfo = HttpContext.Authentication.GetAuthenticateInfoAsync("Cookie");
            IEnumerable<Claim> l = authenticateInfo.Result.Principal.Claims;
            foreach (Claim item in l)
            {
                if (item.Type.Equals(keyName))
                {
                    value = item.Value;
                    break;
                }
            }
            return value;
        }

    }
}