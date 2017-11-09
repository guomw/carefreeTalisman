using Microsoft.EntityFrameworkCore;
using service.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace service.DAL
{
    public class DBHelperContext : DbContext
    {

        public DBHelperContext(DbContextOptions<DBHelperContext> options) : base(options) { }


        public DbSet<UserModel> UserInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<UserModel>().ToTable("Manager");
        }
    }
}
