using FitLink.Domain.Entities;
using FitLink.Infrastructure.Data;
using FitLink.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FitLink.Controllers
{
	public class CoachNumberController : Controller
	{
		private readonly ApplicationDbContext db;
        public CoachNumberController(ApplicationDbContext db)
        {
            this.db = db;
        }

		// get all coach numbers
        public IActionResult Index()
		{
			var coachNumbers = db.CoachNumbers.Include(u => u.Coach).ToList();
			return View(coachNumbers);
		}





		// display create coach number view
		public IActionResult Create()
		{
            CoachNumberVM coachNumberVM = new()
            {
                CoachList = db.Coaches.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
			return View(coachNumberVM);
		}

        // create the coach number post method
        [HttpPost]
        public IActionResult Create(CoachNumberVM obj)
        {
            bool coachNumberExist = db.CoachNumbers.Any(n => n.Coach_Number == obj.CoachNumber.Coach_Number); // returns true kung already exist na yung nilagay na coach number

            if (ModelState.IsValid && !coachNumberExist)
			{
				db.CoachNumbers.Add(obj.CoachNumber);
				db.SaveChanges();
                TempData["success"] = "The coach number has been created successfully.";
                return RedirectToAction("Index", "CoachNumber");
			}

            if (coachNumberExist)
            {
                TempData["error"] = "Coach Number already exist.";
            }

            obj.CoachList = db.Coaches.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(obj);
        }




        // display the update form of coach numbers
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
