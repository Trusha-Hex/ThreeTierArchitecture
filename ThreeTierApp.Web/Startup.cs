using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThreeTierApp.Core.Interfaces;
using ThreeTierApp.Core.Services;
using ThreeTierApp.DAL.Repositories;
using ThreeTierApp.DAL.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

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
         
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"))
            );

            
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

           
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseRouting();

           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();  
            });
        }
    }
}
