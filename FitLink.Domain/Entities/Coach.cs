using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLink.Domain.Entities
{
	public class Coach
	{
        public int Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Display(Name = "Session Price")]
        [Range(10, 10000)]
        public double Price { get; set; }

        public required string Contact { get; set; }

        [Range(1, 10)]
        public int Occupancy { get; set; } // number ng students na kayang i-handle ni coach in a single session

        [NotMapped] // dont add the property to the database is wat notmapped anotation do
        public IFormFile? Image { get; set; }

        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        public DateTime? Created_Date { get; set; }

        public DateTime? Updated_Date { get; set; }
    }
}
