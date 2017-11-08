using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.Authentication;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace web
{
    public class Startup
    {
        public static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            DateFormatString = "yyyy-MM-dd HH:mm:ss",
            Formatting = Formatting.Indented
        };

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Add framework services.
            services.AddMvc();
            services.AddAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                //app.UseExceptionHandler("/login/Forbidden");
            }

            app.UseStaticFiles();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "Cookie",
                LoginPath = new PathString("/login"),
                AccessDeniedPath = new PathString("/Forbidden"),                        
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });



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
