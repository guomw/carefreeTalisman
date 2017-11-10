using Microsoft.EntityFrameworkCore;
using service.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using utils;

namespace service.DAL
{
    public class DBHelperContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //设置数据库链接
            optionsBuilder.UseSqlServer(ConfigurationHelper.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //添加实体映射表
            //如果实体名和表名不一致，则需要在此处理            
            modelBuilder.Entity<UserModel>().ToTable("Manager");
        }
    }
}
