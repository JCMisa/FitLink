using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLink.Domain.Entities
{
	public class FitProgram
	{
		[Key]
        public int Id { get; set; }

		public required string Name { get; set; }

		public string? Description { get; set; }

		[ForeignKey("Coach")]
		public int CoachId { get; set; }
		[ValidateNever]
		public Coach Coach { get; set; }
		
	}
}
