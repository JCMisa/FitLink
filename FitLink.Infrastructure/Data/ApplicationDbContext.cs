using FitLink.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLink.Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<CoachNumber> CoachNumbers { get; set; }
		public DbSet<FitProgram> FitPrograms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);

			// seed te coach table
			modelBuilder.Entity<Coach>().HasData(
				new Coach
				{
					Id = 1,
					Name = "Alex Johnson",
					Description = "Certified Personal Trainer specializing in strength training and HIIT workouts.",
					Price = 50,
					Contact = "alex.johnson@fitlink.com",
					Occupancy = 5,
					ImageUrl = "https://via.placeholder.com/150"
				},
				new Coach
				{
					Id = 2,
					Name = "Maria Lopez",
					Description = "Yoga instructor with 10 years of experience in Vinyasa and Hatha yoga.",
					Price = 60.00,
					Contact = "maria.lopez@fitlink.com",
					Occupancy = 8,
					ImageUrl = "https://via.placeholder.com/150"
				},
				new Coach
				{
					Id = 3,
					Name = "David Kim",
					Description = "Nutritionist and fitness coach focusing on holistic health and wellness.",
					Price = 70.00,
					Contact = "david.kim@fitlink.com",
					Occupancy = 10,
					ImageUrl = "https://via.placeholder.com/150"
				}
			);

			// seed the coachNumber table
			modelBuilder.Entity<CoachNumber>().HasData(
				new CoachNumber
				{
					Coach_Number = 101,
					CoachId = 1
				},
                new CoachNumber
                {
                    Coach_Number = 102,
                    CoachId = 1
                },
                new CoachNumber
                {
                    Coach_Number = 103,
                    CoachId = 3
                },
                new CoachNumber
                {
                    Coach_Number = 201,
                    CoachId = 3
                },
                new CoachNumber
                {
                    Coach_Number = 202,
                    CoachId = 4
                },
                new CoachNumber
                {
                    Coach_Number = 203,
                    CoachId = 4
                },
                new CoachNumber
                {
                    Coach_Number = 301,
                    CoachId = 4
                },
                new CoachNumber
                {
                    Coach_Number = 302,
                    CoachId = 5
                }
            );

			// seed the coachNumber table
			modelBuilder.Entity<FitProgram>().HasData(
				new FitProgram { Id = 1, CoachId = 1, Name = "Strength Training Basics" }, 
				new FitProgram { Id = 2, CoachId = 3, Name = "Advanced Cardio Workouts" }, 
				new FitProgram { Id = 3, CoachId = 4, Name = "Yoga for Beginners" }, 
				new FitProgram { Id = 4, CoachId = 8, Name = "HIIT and Fat Loss" }, 
				new FitProgram { Id = 5, CoachId = 1, Name = "Holistic Wellness Plan" }, 
				new FitProgram { Id = 6, CoachId = 3, Name = "Endurance Building" }, 
				new FitProgram { Id = 7, CoachId = 4, Name = "Flexibility and Mobility" }, 
				new FitProgram { Id = 8, CoachId = 5, Name = "Nutritional Guidance" }, 
				new FitProgram { Id = 9, CoachId = 8, Name = "Strength and Conditioning" }, 
				new FitProgram { Id = 10, CoachId = 3, Name = "Meditation and Relaxation" },
				new FitProgram { Id = 11, CoachId = 4, Name = "Boot Camp Intensive" }
			);
		}
	}
}
