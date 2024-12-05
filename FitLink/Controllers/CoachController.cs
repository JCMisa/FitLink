using FitLink.Domain.Entities;
using FitLink.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace FitLink.Controllers
{
	public class CoachController : Controller
	{
		private readonly ApplicationDbContext db;
        public CoachController(ApplicationDbContext db)
        {
            this.db = db;
        }

		// get all coach
        public IActionResult Index()
		{
			var coaches = db.Coaches.ToList();
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
				db.Coaches.Add(obj);
				db.SaveChanges();
                TempData["success"] = "The coach has been created successfully.";
                return RedirectToAction("Index", "Coach");
			}
            TempData["error"] = "Internal error while creating the coach.";
            return View();
        }




        // display the update form
        public IActionResult Update(int coachId)
        {
            Coach? obj = db.Coaches.FirstOrDefault(c => c.Id == coachId);
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
                db.Coaches.Update(obj);
                db.SaveChanges();
                TempData["success"] = "The coach has been updated successfully.";
                return RedirectToAction("Index", "Coach");
            }
            TempData["error"] = "Internal error while updating the coach.";
            return View();
        }





        // display delete page
        public IActionResult Delete(int coachId)
        {
            Coach? obj = db.Coaches.FirstOrDefault(c => c.Id == coachId);
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
            Coach? objFromDb = db.Coaches.FirstOrDefault(c => c.Id == obj.Id);
            if (objFromDb is not null)
            {
                db.Coaches.Remove(objFromDb);
                db.SaveChanges();
                TempData["success"] = "The coach has been deleted successfully.";
                return RedirectToAction("Index", "Coach");
            }
            TempData["error"] = "Internal error while deleting the coach.";
            return View();
        }
    }
}
