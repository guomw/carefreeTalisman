using System;
using System.Security.Cryptography;
using System.Text;

namespace utils
{
    public class EncryptHelper
    {
        /// <summary>
        /// MD5
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string md5DigestAsHex(byte[] bytes)
        {
            string ret = "";
            byte[] result = MD5Digest(bytes);
            for (int i = 0; i < result.Length; i++)//逐字节变为16进制字符，以隔开
            {
                ret += result[i].ToString("x").PadLeft(2, '0');
            }
            return ret;
        }
        private static byte[] MD5Digest(byte[] bytes)
        {
            MD5 md5 = MD5.Create();
            return md5.ComputeHash(bytes);
        }
        public static string md5DigestAsHex(string str)
        {
            string ret = "";
            byte[] b = Encoding.UTF8.GetBytes(str);
            byte[] result = MD5Digest(b);
            for (int i = 0; i < result.Length; i++)
                ret += result[i].ToString("x").PadLeft(2, '0');

            return ret;
        }

    }
}
