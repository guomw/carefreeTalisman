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
    public class DemoServiceImpl : IDemoService
    {
        private static DemoServiceImpl instance = new DemoServiceImpl();
        private static UserRepository userRepository = null;
        public DemoServiceImpl()
        {
            if (userRepository == null)
            {
                //DbContextOptions<DBHelperContext> options = ;    

                userRepository = new UserRepository(new DBHelperContext(new DbContextOptions<DBHelperContext>()));
            }
        }

        public static IDemoService Instance
        {
            get
            {
                return instance;
            }
        }

        public IQueryable<UserModel> Hello()
        {
            Expression<Func<UserModel, bool>> predicate = null;
            //predicate = f => f.UserId == 1;
            return userRepository.GetAllList(predicate);
        }

        public void Insert(UserModel user)
        {
            userRepository.Insert(user);
        }
    }
}
