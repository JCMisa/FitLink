using FitLink.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitLink.ViewModels
{
    public class FitProgramVM
    {
        public FitProgram? FitProgram { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? CoachList { get; set; }
    }
}
