using FitLink.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitLink.ViewModels
{
    public class CoachNumberVM
    {
        public CoachNumber? CoachNumber { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? CoachList { get; set; }
    }
}
