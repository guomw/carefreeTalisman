using Microsoft.EntityFrameworkCore;
using service.DAL;
using service.Entity;
using service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace service.Interface.Impl
{
    public class DemoServiceImpl : RepositoryBase<UserModel>, IDemoService
    {
        public IQueryable<UserModel> Hello()
        {
            return this.GetAllList();
        }
    }
}
