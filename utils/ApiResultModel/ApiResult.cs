using System;
using System.Collections.Generic;
using System.Text;


namespace utils.ApiResultModel
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiResult
    {
        public int resultCode;
        public string resultMsg;
        public object data;

        private ApiResult() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultEnum"></param>
        /// <returns></returns>
        public static ApiResult Write(ApiResultEnum resultEnum)
        {
            return new ApiResult
            {
                resultCode = (int)resultEnum,
                resultMsg = resultEnum.ToString(),
                data = new object()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultEnum"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ApiResult Write(ApiResultEnum resultEnum, object data)
        {
            return new ApiResult
            {
                resultCode = (int)resultEnum,
                resultMsg = resultEnum.ToString(),
                data = data
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultEnum"></param>
        /// <param name="resultMsg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ApiResult Write(ApiResultEnum resultEnum, string resultMsg, object data)
        {
            return new ApiResult
            {
                resultCode = (int)resultEnum,
                resultMsg = resultMsg,
                data = data
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultEnum"></param>
        /// <param name="resultMsg"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ApiResult Write(ApiResultEnum resultEnum, string resultMsg, string key, object data)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict[key] = data;
            return new ApiResult
            {
                resultCode = (int)resultEnum,
                resultMsg = string.IsNullOrEmpty(resultMsg) ? resultEnum.ToString() : resultMsg,
                data = dict
            };
        }

    }
}
