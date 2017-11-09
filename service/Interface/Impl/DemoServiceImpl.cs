using Microsoft.EntityFrameworkCore;
using service.DAL;
using service.entity;
using service.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace service.Interface.Impl
{
    public class DemoServiceImpl : RepositoryBase<UserModel>, IDemoService
    {
        private static DemoServiceImpl instance = null;

        public DemoServiceImpl(DBHelperContext context) : base(context)
        {
        }
        public static IDemoService Instance(DBHelperContext context)
        {
            if (instance != null)
                return instance;
            return new DemoServiceImpl(context);

        }
        public IQueryable<UserModel> Hello()
        {
            return this.GetAllList();
        }
    }
}
