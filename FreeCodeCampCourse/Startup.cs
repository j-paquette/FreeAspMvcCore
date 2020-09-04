using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FreeCodeCampCourse
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //This is where you register your service. 
        //registering all dependancies within dependancy containers.
        //where you add services to the collection of services(entities are registered here, where other parts of the application can use it.
        //Invoked automatically by ASP.NET core.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Invoked automatically by ASP.NET core.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            //IApplicationBuilder configures the HTTPS request pipeline of .net core.
            //IApplicationBuilder decides how to respond to HTTPS requests.
            //IWebHostEnvironment is used to check if the environment is in dev, int, uat, prod
            //used to configure the pipeline
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //This forces the user to use a secure line.
            //All of these app.* are the middleware used in the pipeline that an application needs to "pass" to go thru the pipeline.
            //Each middleware has an order of sequence.
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //The endpoint calculates the default route for the application.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //This shows the default URL pattern for routing, after the domain name.
                    //default controller: Home, default action:Index, default id is optional.
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
