using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using service.DAL;

namespace web.Models
{
    /// <summary>
    /// 
    /// </summary>
    public static class DbInitialize
    {
        public static void Initialize(IServiceProvider serviceProvider, DBHelperContext dBHelperContext)
        {

            //var context = serviceProvider.GetService<DbContext>();
            //dBHelperContext.Database
            
            var context = serviceProvider.GetService<DBHelperContext>();
            if (context.Database == null)
            {
                throw new Exception("DB is null");
            }
        }
    }
}
