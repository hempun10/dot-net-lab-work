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

         public DbSet<HelpTicket> HelpTickets { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<TicketComment> TicketComments { get; set; }

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

  
            modelBuilder.Entity<HelpTicket>()
                .HasOne(t => t.Technician)
                .WithMany(t => t.AssignedTickets)
                .HasForeignKey(t => t.TechnicianId)
                .OnDelete(DeleteBehavior.SetNull);
                
            modelBuilder.Entity<TicketComment>()
                .HasOne(c => c.HelpTicket)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TicketId)
                .OnDelete(DeleteBehavior.Cascade);
                
           
            modelBuilder.Entity<Technician>().HasData(
                new Technician
                {
                    TechnicianId = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john.smith@helpdesk.com",
                    PhoneNumber = "555-123-4567",
                    Specialty = TechnicianSpecialty.Hardware,
                    HireDate = new DateTime().ToUniversalTime()
                },
                new Technician
                {
                    TechnicianId = 2,
                    FirstName = "Emma",
                    LastName = "Johnson",
                    Email = "emma.johnson@helpdesk.com",
                    PhoneNumber = "555-987-6543",
                    Specialty = TechnicianSpecialty.Software,
                    HireDate = new DateTime().ToUniversalTime()
                }
            );

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            base.OnModelCreating(modelBuilder);
        }
    }
}