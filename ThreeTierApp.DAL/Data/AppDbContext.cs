using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreeTierApp.DAL.Models;

namespace ThreeTierApp.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskDetails> TaskDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Employee Entity
            modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .HasColumnType("int");

            // Configure TaskDetails Entity
            modelBuilder.Entity<TaskDetails>()
                .Property(t => t.Id)
                .HasColumnType("int");

            modelBuilder.Entity<TaskDetails>()
                .Property(t => t.Description)
                .HasColumnType("text")
                .IsRequired(false);

            modelBuilder.Entity<TaskDetails>()
                .Property(t => t.AssignedEmployeeIds)
                .HasColumnType("longtext")
                .IsRequired(false);

            modelBuilder.Entity<TaskDetails>()
                .Property(t => t.IsCompleted)
                .HasColumnType("tinyint(1)")
                .HasDefaultValue(0);

            modelBuilder.Entity<TaskDetails>()
                .Property(t => t.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<TaskDetails>()
                .Property(t => t.UpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<TaskDetails>()
                .Property(t => t.DueDate)
                .HasColumnType("datetime")
                .IsRequired(false);

            modelBuilder.Entity<TaskDetails>()
                 .Property(t => t.AssignedEmployeeIds)
                 .HasConversion(
                     v => JsonConvert.SerializeObject(v),  // Convert List<int> to a JSON string.
                     v => JsonConvert.DeserializeObject<List<int>>(v) // Convert JSON string back to List<int>.
                 );

            // Convert property names to snake_case
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(ToSnakeCase(property.Name));
                }
            }

            // Configure table names
            modelBuilder.Entity<Employee>().ToTable("employees");
            modelBuilder.Entity<TaskDetails>().ToTable("tasks");
        }

        private string ToSnakeCase(string propertyName) =>
            string.Concat(propertyName.Select((ch, i) => i > 0 && char.IsUpper(ch) ? "_" + char.ToLower(ch) : char.ToLower(ch).ToString()));
    }
}
