using FitLink.Domain.Entities;

namespace FitLink.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Coach>? CoachList { get; set; }
        public DateOnly SessionStartDate { get; set; }
        public DateOnly? SessionEndDate { get; set; }
        public int SessionCount { get; set; }
    }
}
