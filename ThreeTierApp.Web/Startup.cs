using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThreeTierApp.Core.Interfaces;
using ThreeTierApp.Core.Services;
using ThreeTierApp.DAL.Repositories;
using ThreeTierApp.DAL.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using ThreeTierApp.Core.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

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
            // Add Controllers with Views
            services.AddControllersWithViews();

            // Register Core services
            services.AddScoped<IEmployeeService, EmployeeService>();  // Register IEmployeeService and EmployeeService
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();  // Register IEmployeeRepository and EmployeeRepository

            // Add Authentication with cookies
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Home/Index";
                    options.LogoutPath = "/Home/Logout";
                    options.AccessDeniedPath = "/Home/AccessDenied";
                });

            services.AddAuthorization();

            // Register DbContext (assuming you're using EF Core for data access)
            services.AddDbContext<AppDbContext>(options =>
               options.UseMySql(_configuration.GetConnectionString("DefaultConnection"))
           );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

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
