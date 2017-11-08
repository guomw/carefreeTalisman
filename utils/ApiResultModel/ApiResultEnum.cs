using System;
using System.Collections.Generic;
using System.Text;

namespace utils.ApiResultModel
{
    public enum ApiResultEnum
    {
        /// <summary>
        /// No request
        /// </summary>
        NOREQUEST = 403,
        /// <summary>
        /// 成功
        /// </summary>
        SUCCESS = 2000,
        /// <summary>
        /// 错误
        /// </summary>
        ERROR = 5000,
        /// <summary>
        /// 缺少签名
        /// </summary>
        LACKSIGN = 4002,
        /// <summary>
        /// 签名错误
        /// </summary>
        SIGNERROR = 4003,

    }
}
