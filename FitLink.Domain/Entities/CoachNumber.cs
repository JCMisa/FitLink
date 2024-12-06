using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLink.Domain.Entities
{
    public class CoachNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] // to not let database to auto increment the value for this property
        [Display(Name = "Coach Number")]
        public int Coach_Number { get; set; } // admin mismo and me-maintain na unique ang value ng property na ito

        [ForeignKey("Coach")]
        public int CoachId { get; set; }
        [ValidateNever]
        public Coach Coach { get; set; }

        [Display(Name = "Special Details")]
        public string? SpecialDetails { get; set; }
    }
}
