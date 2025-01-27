using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThreeTierApp.Core.Interfaces;
using ThreeTierApp.Core.Services;
using ThreeTierApp.Core.Repositories;
using ThreeTierApp.DAL.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using ThreeTierApp.Core.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using ThreeTierApp.DAL.Repositories;
using Microsoft.Extensions.Logging;
using NLog.Web;
using NLog;
using StackExchange.Redis;
using System;
using ThreeTierApp.DAL.Models;
using ZeroFormatter;
//using ThreeTierApp.Binders;

namespace ThreeTierApp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var redisConnectionString = configuration.GetConnectionString("Redis");

                if (string.IsNullOrEmpty(redisConnectionString))
                {
                    throw new InvalidOperationException("Redis connection string is missing in configuration.");
                }

                var options = ConfigurationOptions.Parse(redisConnectionString, true);
                return ConnectionMultiplexer.Connect(options);
            });

            // Add Controllers with Views
            services.AddControllersWithViews();

            services.AddScoped<TaskDetailsRepository>();

            // Register TaskRepositoryWrapper
            services.AddScoped<ITaskRepository, TaskRepositoryWrapper>();

            services.AddScoped<ICacheService, RedisCacheService>();

            services.AddScoped<ITaskNotificationService, TaskNotificationService>();

            // Register TaskDetailsService
            services.AddScoped<TaskDetailsService>();

            // Register Core services
            services.AddScoped<IEmployeeService, EmployeeService>();  // Register IEmployeeService and EmployeeService

            // Register DAL Repository
            services.AddScoped<EmployeeRepository>();  // Register EmployeeRepository from DAL layer

            // Register the wrapper from Core
            services.AddScoped<IEmployeeRepository, EmployeeRepositoryWrapper>();  // Register Core wrapper

            // Add Authentication with cookies
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Employee/Login";
                    options.LogoutPath = "/Home/Logout";
                    options.AccessDeniedPath = "/Home/AccessDenied";
                });

            services.AddAuthorization();

            // Register DbContext (assuming you're using EF Core for data access)
            services.AddDbContext<AppDbContext>(options =>
               options.UseMySql(_configuration.GetConnectionString("DefaultConnection"))
           );

            //services.AddMvc(options =>
            //{
            //    // Register your custom model binder provider
            //    options.ModelBinderProviders.Insert(0, new EmployeeModelBinderProvider());
            //});

            services.AddControllers();

        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            LogManager.LoadConfiguration("nlog.config");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //logger.LogInformation("Application started successfully.");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Add Authentication and Authorization Middleware
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // This will point to the Login action of HomeController
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=Login}/{id?}");
            });
        }
    }
}
