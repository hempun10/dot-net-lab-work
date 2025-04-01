using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using myapp.models;
using System.Reflection;


namespace myapp.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Class> Class {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasIndex(p => p.Id).IsUnique();
                entity.Property(p => p.Name)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(p => p.Address)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            modelBuilder.Entity<Class>(entity => {
                entity.HasIndex(p => p.Id).IsUnique();
                entity.Property(p => p.Name)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(p => p.Address)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            modelBuilder.Entity<Student>()
            .HasOne(s => s.Class)
            .WithMany(c => c.Students)
            .HasForeignKey(s => s.ClassId)
            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}