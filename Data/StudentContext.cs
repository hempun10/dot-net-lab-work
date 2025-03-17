using Microsoft.EntityFrameworkCore;
using myapp.models;
using System.Reflection;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace myapp.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Product entity
            modelBuilder.Entity<Student>(entity =>
            {
                // Create a unique index on SKU
                entity.HasIndex(p => p.Id)
                      .IsUnique();

                // Configure the Name property
                entity.Property(p => p.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}