using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace web.Models
{
    /// <summary>
    /// 
    /// </summary>
    public static class DbInitialize
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            //var context = serviceProvider.GetService<DbContext>();

            var context = serviceProvider.GetRequiredService<DbContextOptions<DbContext>>();
            if (context == null)
            {
                throw new Exception("DB is null");
            }
        }
    }
}
