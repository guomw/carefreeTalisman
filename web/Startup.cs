using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace web
{
    public class Startup
    {

        public static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            DateFormatString = "yyyy-MM-dd HH:mm:ss",
            Formatting = Formatting.Indented
        };


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<DbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o =>
                {
                    o.LoginPath = new PathString("/login");
                    o.AccessDeniedPath = new PathString("/Forbidden");
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Forbidden");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "home",
                    template: "",
                    defaults: new { controller = "Home", action = "Index" }
                );

                //登录
                routes.MapRoute(
                    name: "login",
                    template: "login",
                    defaults: new { controller = "Login", action = "Login" }
                );

                //
                routes.MapRoute(
                    name: "Forbidden",
                    template: "Forbidden",
                    defaults: new { controller = "Login", action = "Forbidden" }
                );


                //接口路由
                routes.MapRoute(
                    name: "defaultApi",
                    template: "api/{controller}/{action}",
                    defaults: new { controller = "api", action = "Index" }
                );


                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
