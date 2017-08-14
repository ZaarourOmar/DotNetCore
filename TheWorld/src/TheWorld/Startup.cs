using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheWorld.Services;
using Microsoft.Extensions.Configuration;

namespace TheWorld
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json");
            _config = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton(_config);  // for config settings, we only need a singleton


            if (_env.IsEnvironment("Development"))
            {
                //services.AddTransient<IMailService, MailService>(); // this means that the app will create an instance if mail service and keep it cached around if someone needs it
                services.AddScoped<IMailService, FakeMailService>(); // this means that the app will create an instance for each request that comes in
                                                                 //services.AddSingleton<IMailService, MailService>(); // this means that only one is there
            }
            else
            {
                // Use a real mail service
            }
            //dependency injection
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsEnvironment("Development")) // look in the project properties->Debug, other environments can be added
            {
                app.UseDeveloperExceptionPage(); // show detailed exeption in the browser
            }

            app.UseStaticFiles();


            app.UseMvc(cnfg =>
            {
                cnfg.MapRoute(
                   name: "Default",
                   template: "{controller}/{action}/{id?}",
                   defaults: new { controller = "App", action = "Index" }
                            );
            });
        }
    }
}
