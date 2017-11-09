using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using utils;
using utils.ApiResultModel;

namespace web.Filters
{
    /// <summary>
    /// 接口异常处理
    /// </summary>
    public class ApiExceptionAttribute : ExceptionFilterAttribute
    {

        /// <summary>
        /// 获取header数据
        /// </summary>
        /// <param name="context"></param>
        /// <param name="keyName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private string GetHeaderValue(IHeaderDictionary header, string keyName, string defaultValue = "")
        {
            StringValues v = defaultValue;
            try
            {
                if (header.ContainsKey(keyName))
                    header.TryGetValue(keyName, out v);
            }
            catch { }
            return v;
        }
        
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.Result = new JsonResult(ApiResult.Write(ApiResultEnum.ERROR), Startup.settings);
        }
    }

    /// <summary>
    /// 后台异常处理
    /// </summary>
    public class AdminExceptionAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            context.Result = new RedirectToRouteResult("Forbidden", null);
        }
    }

}
