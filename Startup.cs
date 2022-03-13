using LiftTrackerApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftTrackerApi
{
    public class Startup
    {
        private IWebHostEnvironment CurrentEnvironment { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment Env)
        {
            Configuration = configuration;
            CurrentEnvironment = Env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string env = CurrentEnvironment.EnvironmentName;
            services.AddControllers();
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(env == "Development" ? Configuration["dbConnDev"] : Configuration["dbConnProd"]);
            });
            services.AddScoped<ILogSql, LogSql>();
            //AddIdentityCoreServices(services);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LiftTrackerApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiftTrackerApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{Name?}");
            });
        }
        //private static void AddIdentityCoreServices(IServiceCollection services)
        //{
        //    var builder = services.AddIdentityCore<Users>();
        //    builder = new IdentityBuilder(
        //        builder.UserType,
        //        typeof(UserRoles),
        //        builder.Services);

        //    builder.AddRoles<UserRoles>()
        //        //.AddEntityFrameworkStores<ApplicationDbContext>()
        //        .AddDefaultTokenProviders()
        //        .AddSignInManager<SignInManager<Users>>();
        //}
    }
}
