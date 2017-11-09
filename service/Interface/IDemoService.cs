using service.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using service.repository;

namespace service.Interface
{
    /// <summary>
    /// 接口
    /// </summary>
    public interface IDemoService: IRepository<UserModel>
    {
        IQueryable<UserModel> Hello();
    }
}
