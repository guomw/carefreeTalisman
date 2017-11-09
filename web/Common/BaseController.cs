using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using utils.ApiResultModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using web.Common;
using Microsoft.AspNetCore.Authentication;

namespace web.Controllers
{

    public class BaseController : Controller
    {

        public static string authenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;

        /// <summary>
        /// ����json��ʽ
        /// </summary>
        /// <param name="apiResult"></param>
        /// <returns></returns>
        protected ActionResult GetContent(ApiResult apiResult)
        {
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return Content(JsonConvert.SerializeObject(apiResult, Startup.settings), "application/json", System.Text.Encoding.UTF8);
        }


        /// <summary>
        /// ������Ȩ��֤��
        /// </summary>        
        /// <param name="value">ʵ�����л�JsonConvert.SerializeObject(data)</param>
        /// <param name="valueType"></param>
        public async void SetsAuthenticationAsync(string value, AuthorizationStorageType valueType)
        {
            var claims = new List<Claim>() { new Claim(valueType.ToString(), value) };
            Task<AuthenticateResult> authenticateInfo = AuthenticationHttpContextExtensions.AuthenticateAsync(HttpContext, authenticationScheme);
            if (!authenticateInfo.IsFaulted && authenticateInfo.Result.Principal != null)
            {
                claims = authenticateInfo.Result.Principal.Claims.ToList();
                int idx = claims.FindIndex(c => { return c.Type.Equals(valueType.ToString()); });
                if (idx >= 0)
                    claims.RemoveAt(idx);
                claims.Add(new Claim(valueType.ToString(), value));
            }
            ClaimsIdentity identity = new ClaimsIdentity(claims);
            var userPrincipal = new ClaimsPrincipal(identity);
            await AuthenticationHttpContextExtensions.SignInAsync(HttpContext,authenticationScheme, userPrincipal, new Microsoft.AspNetCore.Authentication.AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddHours(24),
                IsPersistent = false,
                AllowRefresh = true
            });

        }

        /// <summary>
        /// ��ȡ��Ȩ����
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public string GetAuthClainValue(AuthorizationStorageType valueType)
        {
            string value = string.Empty;
            try
            {
                Task<AuthenticateResult> authenticateInfo = AuthenticationHttpContextExtensions.AuthenticateAsync(HttpContext, authenticationScheme);
                if (authenticateInfo.IsFaulted || authenticateInfo.Result.Principal == null) return value;
                IEnumerable<Claim> claims = authenticateInfo.Result.Principal.Claims;
                foreach (Claim claim in claims)
                {
                    if (claim.Type.Equals(valueType.ToString()))
                    {
                        value = claim.Value;
                        break;
                    }
                }
            }
            catch (Exception)
            {
            }
            return value;
        }
        /// <summary>
        /// ��֤��Ȩ�û��Ƿ�ɹ�
        /// </summary>
        public bool IsAuthenticated
        {
            get
            {
                var userData = GetAuthClainValue(AuthorizationStorageType.UserData);
                return !string.IsNullOrEmpty(userData);
            }
        }

    }
}