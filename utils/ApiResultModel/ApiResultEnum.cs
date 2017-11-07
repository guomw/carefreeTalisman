using System;
using System.Collections.Generic;
using System.Text;

namespace utils.ApiResultModel
{
    public enum ApiResultEnum
    {
        禁止请求 = 403,
        请求成功 = 2000,
        缺少签名 = 4002,
        签名错误 = 4003,
        服务器开小差 = 5000,
    }
}
