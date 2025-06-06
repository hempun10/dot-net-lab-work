﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using myapp.Data;

#nullable disable

namespace myapp.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20250401130905_new-models-added")]
    partial class newmodelsadded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("myapp.models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Class");
                });

            modelBuilder.Entity("myapp.models.HelpTicket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TicketId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<string>("RequestedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ResolvedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("TechnicianId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("TicketId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("HelpTickets");
                });

            modelBuilder.Entity("myapp.models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("myapp.models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("myapp.models.Technician", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TechnicianId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("Specialty")
                        .HasColumnType("integer");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechnicianId = 1,
                            Email = "john.smith@helpdesk.com",
                            FirstName = "John",
                            HireDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            IsAvailable = true,
                            LastName = "Smith",
                            PhoneNumber = "555-123-4567",
                            Specialty = 0
                        },
                        new
                        {
                            TechnicianId = 2,
                            Email = "emma.johnson@helpdesk.com",
                            FirstName = "Emma",
                            HireDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            IsAvailable = true,
                            LastName = "Johnson",
                            PhoneNumber = "555-987-6543",
                            Specialty = 1
                        });
                });

            modelBuilder.Entity("myapp.models.TicketComment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CommentId"));

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CommentedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsInternal")
                        .HasColumnType("boolean");

                    b.Property<int>("TicketId")
                        .HasColumnType("integer");

                    b.HasKey("CommentId");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketComments");
                });

            modelBuilder.Entity("myapp.models.HelpTicket", b =>
                {
                    b.HasOne("myapp.models.Technician", "Technician")
                        .WithMany("AssignedTickets")
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("myapp.models.Student", b =>
                {
                    b.HasOne("myapp.models.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("myapp.models.TicketComment", b =>
                {
                    b.HasOne("myapp.models.HelpTicket", "HelpTicket")
                        .WithMany("Comments")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HelpTicket");
                });

            modelBuilder.Entity("myapp.models.Class", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("myapp.models.HelpTicket", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("myapp.models.Technician", b =>
                {
                    b.Navigation("AssignedTickets");
                });
#pragma warning restore 612, 618
        }
    }
}
