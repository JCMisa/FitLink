﻿// <auto-generated />
using System;
using FitLink.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitLink.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241206124151_addFitProgramToDb")]
    partial class addFitProgramToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitLink.Domain.Entities.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Updated_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Coaches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Contact = "alex.johnson@fitlink.com",
                            Description = "Certified Personal Trainer specializing in strength training and HIIT workouts.",
                            ImageUrl = "https://via.placeholder.com/150",
                            Name = "Alex Johnson",
                            Occupancy = 5,
                            Price = 50.0
                        },
                        new
                        {
                            Id = 2,
                            Contact = "maria.lopez@fitlink.com",
                            Description = "Yoga instructor with 10 years of experience in Vinyasa and Hatha yoga.",
                            ImageUrl = "https://via.placeholder.com/150",
                            Name = "Maria Lopez",
                            Occupancy = 8,
                            Price = 60.0
                        },
                        new
                        {
                            Id = 3,
                            Contact = "david.kim@fitlink.com",
                            Description = "Nutritionist and fitness coach focusing on holistic health and wellness.",
                            ImageUrl = "https://via.placeholder.com/150",
                            Name = "David Kim",
                            Occupancy = 10,
                            Price = 70.0
                        });
                });

            modelBuilder.Entity("FitLink.Domain.Entities.CoachNumber", b =>
                {
                    b.Property<int>("Coach_Number")
                        .HasColumnType("int");

                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<string>("SpecialDetails")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Coach_Number");

                    b.HasIndex("CoachId");

                    b.ToTable("CoachNumbers");

                    b.HasData(
                        new
                        {
                            Coach_Number = 101,
                            CoachId = 1
                        },
                        new
                        {
                            Coach_Number = 102,
                            CoachId = 1
                        },
                        new
                        {
                            Coach_Number = 103,
                            CoachId = 3
                        },
                        new
                        {
                            Coach_Number = 201,
                            CoachId = 3
                        },
                        new
                        {
                            Coach_Number = 202,
                            CoachId = 4
                        },
                        new
                        {
                            Coach_Number = 203,
                            CoachId = 4
                        },
                        new
                        {
                            Coach_Number = 301,
                            CoachId = 4
                        },
                        new
                        {
                            Coach_Number = 302,
                            CoachId = 5
                        });
                });

            modelBuilder.Entity("FitLink.Domain.Entities.FitProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.ToTable("FitPrograms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoachId = 1,
                            Name = "Strength Training Basics"
                        },
                        new
                        {
                            Id = 2,
                            CoachId = 3,
                            Name = "Advanced Cardio Workouts"
                        },
                        new
                        {
                            Id = 3,
                            CoachId = 4,
                            Name = "Yoga for Beginners"
                        },
                        new
                        {
                            Id = 4,
                            CoachId = 8,
                            Name = "HIIT and Fat Loss"
                        },
                        new
                        {
                            Id = 5,
                            CoachId = 1,
                            Name = "Holistic Wellness Plan"
                        },
                        new
                        {
                            Id = 6,
                            CoachId = 3,
                            Name = "Endurance Building"
                        },
                        new
                        {
                            Id = 7,
                            CoachId = 4,
                            Name = "Flexibility and Mobility"
                        },
                        new
                        {
                            Id = 8,
                            CoachId = 5,
                            Name = "Nutritional Guidance"
                        },
                        new
                        {
                            Id = 9,
                            CoachId = 8,
                            Name = "Strength and Conditioning"
                        },
                        new
                        {
                            Id = 10,
                            CoachId = 3,
                            Name = "Meditation and Relaxation"
                        },
                        new
                        {
                            Id = 11,
                            CoachId = 4,
                            Name = "Boot Camp Intensive"
                        });
                });

            modelBuilder.Entity("FitLink.Domain.Entities.CoachNumber", b =>
                {
                    b.HasOne("FitLink.Domain.Entities.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("FitLink.Domain.Entities.FitProgram", b =>
                {
                    b.HasOne("FitLink.Domain.Entities.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");
                });
#pragma warning restore 612, 618
        }
    }
}
