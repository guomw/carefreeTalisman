using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace service.Entity
{
    public class UserModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }

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

        public string UserIcon { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime UserCreateTime { get; set; }


    }
}
