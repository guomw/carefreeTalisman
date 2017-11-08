using System;
using System.Collections.Generic;
using System.Text;

namespace service.Model
{
    public class UserModel
    {

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public string UserRole { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime UserCreateTime { get; set; }


    }
}
