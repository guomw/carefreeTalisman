using System;
using System.Collections.Generic;
using System.Text;

namespace utils
{
    /// <summary>
    /// 字符串帮助类
    /// </summary>
    public static class StringHelper
    {

        #region 判断字符串是否为空,返回true为空，否则不为空
        /// <summary>
        /// 判断字符串是否为空,返回true为空，否则不为空
        /// </summary>
        /// <param name="boolValue">字符串值</param>
        /// <returns></returns>
        public static bool Empty(this string boolValue)
        {
            if (boolValue != null && boolValue != "" && boolValue.ToLower() != "null" && !string.IsNullOrEmpty(boolValue) && boolValue.ToString().Trim().Length != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion


        /// <summary>
        /// 将字符串转换成字节
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static byte[] ToByte(this string content)
        {
            return Encoding.UTF8.GetBytes(content);
        }
    }
}
