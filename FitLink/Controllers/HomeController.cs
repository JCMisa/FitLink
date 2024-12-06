using FitLink.Application.Common.Interfaces;
using FitLink.Models;
using FitLink.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FitLink.Controllers
{
	public class HomeController : Controller
	{
        private readonly IUnitOfWork unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }



        public IActionResult Index()
		{
			HomeVM homeVM = new()
			{
				CoachList = unitOfWork.Coach.GetAll(includeProperties: "CoachPrograms"),
				SessionCount = 1,
				SessionStartDate = DateOnly.FromDateTime(DateTime.Now),
			};
			return View(homeVM);
		}

        //[HttpPost]
        //public IActionResult GetCoachesByDate(int session, DateOnly sessionStartDate)
        //{

        //    HomeVM homeVM = new()
        //    {
        //        SessionStartDate = sessionStartDate,
        //        CoachList = _coachService.GetVillasAvailabilityByDate(session, sessionStartDate),
        //        SessionCount = session
        //    };

        //    return PartialView("_VillaList", homeVM);
        //}

        public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Error()
		{
			return View();
		}
	}
}
