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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);

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
		}
	}
}
