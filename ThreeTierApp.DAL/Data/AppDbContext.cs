using Microsoft.EntityFrameworkCore;
using System.Text;
using ThreeTierApp.Core.Models;

namespace ThreeTierApp.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply a global naming convention for all entities and properties
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    // Convert property names to snake_case (lowercase with underscores)
                    property.SetColumnName(ToSnakeCase(property.Name));
                }
            }

            // Explicitly set the table name for the Employee entity (optional)
            modelBuilder.Entity<Employee>().ToTable("employees");
        }

        // Helper method to convert PascalCase to snake_case
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
