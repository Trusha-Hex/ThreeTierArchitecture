using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text;
using ThreeTierApp.Core.Models;

namespace ThreeTierApp.DAL.Data
{
    public class AppDbContext : IdentityDbContext<Employee, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Employee Id to be of type int
            modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .HasColumnType("int");

            // Convert property names to snake_case
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(ToSnakeCase(property.Name));
                }
            }

            // Configure the table name for Employee
            modelBuilder.Entity<Employee>().ToTable("employees");
        }

        private string ToSnakeCase(string propertyName)
        {
            var stringBuilder = new StringBuilder();
            foreach (var ch in propertyName)
            {
                if (char.IsUpper(ch) && stringBuilder.Length > 0)
                {
                    stringBuilder.Append("_");
                }
                stringBuilder.Append(char.ToLower(ch));
            }
            return stringBuilder.ToString();
        }
    }
}
