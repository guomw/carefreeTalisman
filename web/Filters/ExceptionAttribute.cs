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
    public class ExceptionAttribute : ExceptionFilterAttribute
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
            IHeaderDictionary header = context.HttpContext.Request.Headers;
            //string mobileType = GetHeaderValue(header, "mobileType");// context.HttpContext.Request.Headers.Get("mobileType");//设备类型
            //string osType = GetHeaderValue(header, "osType");//context.HttpContext.Request.Headers.Get("osType");
            //string logInfo = string.Format("url:{0} mobileType:{3} osType:{4} Message:{1} StackTrace:{2}", context.HttpContext.Request.Path.ToString(), context.Exception.Message, context.Exception.StackTrace, mobileType, osType);
            context.ExceptionHandled = true;
            context.Result = new JsonResult(ApiResult.Write(ApiResultEnum.ERROR), Startup.settings);
        }
    }
}
