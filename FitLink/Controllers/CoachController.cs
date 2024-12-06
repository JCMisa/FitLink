using FitLink.Application.Common.Interfaces;
using FitLink.Domain.Entities;
using FitLink.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace FitLink.Controllers
{
	public class CoachController : Controller
	{
		private readonly IUnitOfWork unitOfWork;
        public CoachController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }




		// get all coach
        public IActionResult Index()
		{
			var coaches = unitOfWork.Coach.GetAll();
			return View(coaches);
		}





		// display create coach view
		public IActionResult Create()
		{
			return View();
		}

        // create the coach post method
        [HttpPost]
        public IActionResult Create(Coach obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The description cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
			{
                unitOfWork.Coach.Add(obj);
                unitOfWork.Save();
                TempData["success"] = "The coach has been created successfully.";
                return RedirectToAction("Index", "Coach");
			}
            TempData["error"] = "Internal error while creating the coach.";
            return View();
        }




        // display the update form
        public IActionResult Update(int coachId)
        {
            Coach? obj = unitOfWork.Coach.Get(u => u.Id == coachId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        // update the coach
        [HttpPost]
        public IActionResult Update(Coach obj)
        {
            if (ModelState.IsValid && obj.Id > 0)
            {
                unitOfWork.Coach.Update(obj);
                unitOfWork.Save();
                TempData["success"] = "The coach has been updated successfully.";
                return RedirectToAction("Index", "Coach");
            }
            TempData["error"] = "Internal error while updating the coach.";
            return View();
        }





        // display delete page
        public IActionResult Delete(int coachId)
        {
            Coach? obj = unitOfWork.Coach.Get(c => c.Id == coachId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        // delete the coach
        [HttpPost]
        public IActionResult Delete(Coach obj)
        {
            Coach? objFromDb = unitOfWork.Coach.Get(c => c.Id == obj.Id);
            if (objFromDb is not null)
            {
                unitOfWork.Coach.Remove(objFromDb);
                unitOfWork.Save();
                TempData["success"] = "The coach has been deleted successfully.";
                return RedirectToAction("Index", "Coach");
            }
            TempData["error"] = "Internal error while deleting the coach.";
            return View();
        }
    }
}
