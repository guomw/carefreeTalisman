using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utils;
using utils.ApiResultModel;

namespace web.Filters
{
    /// <summary>
    /// Api签名授权
    /// </summary>
    public class ApiAuthorizeAttribute : ActionFilterAttribute
    {

        private static StringValues secrectKey = "";

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
        /// <summary>
        /// 获取 get/post 数据
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        private JObject GetParams(HttpRequest Request)
        {
            JObject p = new JObject();
            StringValues value;
            if (Request.Method.ToLower() == "post") //post 数据请求
            {
                IFormCollection values = Request.Form;
                foreach (string key in values.Keys)
                {
                    if (values.TryGetValue(key, out value))
                        p.Add(key, value.ToString());
                }
            }
            else  //get 数据请求
            {
                IQueryCollection values = Request.Query;
                foreach (string key in values.Keys)
                {
                    if (values.TryGetValue(key, out value))
                        p.Add(key, value.ToString());
                }
            }
            return p;
        }
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="Request"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private string GetRequestValue(HttpRequest Request, string key, string defaultValue = "")
        {
            if (Request.Method.ToLower() == "post")
            {
                if (Request.Form.ContainsKey(key))
                    defaultValue = Request.Form[key];
            }
            else
            {
                if (Request.Query.ContainsKey(key))
                    defaultValue = Request.Query[key];
            }
            return defaultValue;
        }

        /// <summary>
        /// 函数执行之前
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //HttpContext httpContext = context.HttpContext;
            //IHeaderDictionary header = context.HttpContext.Request.Headers;
            //string appVersion = GetHeaderValue(header, "appVersion");// context.Request.Headers.Get("appVersion");//APP版本
            //string hwid = GetHeaderValue(header, "hwid");//  context.Request.Headers.Get("hwid");//设备号
            //string mobileType = GetHeaderValue(header, "mobileType");//  context.Request.Headers.Get("mobileType");//设备类型
            //string osType = GetHeaderValue(header, "osType");//  context.Request.Headers.Get("osType");//系统类型  ios or android
            //string osVersion = GetHeaderValue(header, "osVersion");//  context.Request.Headers.Get("osVersion");//系统版本

            //string requestSign = GetRequestValue(context.HttpContext.Request, "sign");
            //if (string.IsNullOrEmpty(requestSign))
            //{
            //    context.Result = new JsonResult(ApiResult.Write(ApiResultEnum.LACKSIGN, "No signature!!", null), Startup.settings);
            //    return;
            //}
            //JObject prams = GetParams(context.HttpContext.Request);
            //SortedDictionary<string, string> paramters = new SortedDictionary<string, string>();
            //foreach (var item in prams)
            //{
            //    if (item.Key != "sign" && !string.IsNullOrEmpty(item.Value.ToString()))
            //    {
            //        paramters.Add(item.Key.ToLower(), item.Value.ToString());
            //    }
            //}
            //StringBuilder preStr = new StringBuilder();
            //foreach (KeyValuePair<string, string> kp in paramters)
            //{
            //    preStr.Append(kp.Key + kp.Value);
            //}
            //preStr.Append(secrectKey);
            //string currentSign = EncryptHelper.md5DigestAsHex(Encoding.UTF8.GetBytes(preStr.ToString()));
            //if (!requestSign.Equals(currentSign.ToUpper()))
            //{
            //    context.Result = new JsonResult(ApiResult.Write(ApiResultEnum.SIGNERROR, "Signature error", null), Startup.settings);
            //    return;
            //}
            ////存储当前会话数据            
            //context.HttpContext.Session.SetString("appVersion", appVersion);
        }
    }
}
