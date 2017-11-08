using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using web.Common;

namespace web.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class AdminAuthorizeAttribute : ActionFilterAttribute
    {
        public static string authenticationScheme = "Cookie";

        /// <summary>
        /// 获取授权数据
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public string GetAuthClainValue(AuthenticationManager authenticationManager, AuthorizationStorageType valueType)
        {
            string value = string.Empty;
            try
            {
                Task<AuthenticateInfo> authenticateInfo = authenticationManager.GetAuthenticateInfoAsync(authenticationScheme);
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
        /// 主要是拦截当前用户授权认证是否有效(类似cookie,判断cookie值是否有效)
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userData = GetAuthClainValue(context.HttpContext.Authentication, AuthorizationStorageType.UserData);
            if (string.IsNullOrEmpty(userData))
            {
                context.Result = new RedirectToRouteResult("login",null);
                return;
            }
        }
    }
}
