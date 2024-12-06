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
        public IActionResult Update(int coachNumberId)
        {
            CoachNumberVM coachNumberVM = new()
            {
                CoachList = db.Coaches.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                CoachNumber = db.CoachNumbers.FirstOrDefault(u => u.Coach_Number == coachNumberId)
            };

            if(coachNumberVM.CoachNumber is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(coachNumberVM);
        }

        // update the coach number
        [HttpPost]
        public IActionResult Update(CoachNumberVM coachNumberVM)
        {
            if (ModelState.IsValid)
            {
                db.CoachNumbers.Update(coachNumberVM.CoachNumber);
                db.SaveChanges();
                TempData["success"] = "The coach number has been updated successfully.";
                return RedirectToAction("Index", "CoachNumber");
            }

            coachNumberVM.CoachList = db.Coaches.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(coachNumberVM);
        }





        // display delete page for coach number
        public IActionResult Delete(int coachNumberId)
        {
            CoachNumberVM coachNumberVM = new()
            {
                CoachList = db.Coaches.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                CoachNumber = db.CoachNumbers.FirstOrDefault(u => u.Coach_Number == coachNumberId)
            };

            if (coachNumberVM.CoachNumber is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(coachNumberVM);
        }

        // delete the coach number
        [HttpPost]
        public IActionResult Delete(CoachNumberVM coachNumberVM)
        {
            CoachNumber? objFromDb = db.CoachNumbers.FirstOrDefault(c => c.Coach_Number == coachNumberVM.CoachNumber.Coach_Number);

            if (objFromDb is not null)
            {
                db.CoachNumbers.Remove(objFromDb);
                db.SaveChanges();
                TempData["success"] = "The coach number has been deleted successfully.";
                return RedirectToAction("Index", "CoachNumber");
            }

            TempData["error"] = "Internal error while deleting the coach number.";
            return View();
        }
    }
}
