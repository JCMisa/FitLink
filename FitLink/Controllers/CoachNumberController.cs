using FitLink.Application.Common.Interfaces;
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
        private readonly IUnitOfWork unitOfWork;
        public CoachNumberController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // get all coach numbers
        public IActionResult Index()
		{
            var coachNumbers = unitOfWork.CoachNumber.GetAll(includeProperties: "Coach");
			return View(coachNumbers);
		}





		// display create coach number view
		public IActionResult Create()
		{
            CoachNumberVM coachNumberVM = new()
            {
                CoachList = unitOfWork.Coach.GetAll().Select(u => new SelectListItem
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
            bool coachNumberExist = unitOfWork.CoachNumber.Any(n => n.Coach_Number == obj.CoachNumber.Coach_Number); // returns true kung already exist na yung nilagay na coach number

            if (ModelState.IsValid && !coachNumberExist)
			{
				unitOfWork.CoachNumber.Add(obj.CoachNumber);
                unitOfWork.Save();
                TempData["success"] = "The coach number has been created successfully.";
                return RedirectToAction("Index", "CoachNumber");
			}

            if (coachNumberExist)
            {
                TempData["error"] = "Coach Number already exist.";
            }

            obj.CoachList = unitOfWork.Coach.GetAll().Select(u => new SelectListItem
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
                CoachList = unitOfWork.Coach.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                CoachNumber = unitOfWork.CoachNumber.Get(u => u.Coach_Number == coachNumberId)
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
                unitOfWork.CoachNumber.Update(coachNumberVM.CoachNumber);
                unitOfWork.Save();
                TempData["success"] = "The coach number has been updated successfully.";
                return RedirectToAction("Index", "CoachNumber");
            }

            coachNumberVM.CoachList = unitOfWork.Coach.GetAll().Select(u => new SelectListItem
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
                CoachList = unitOfWork.Coach.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                CoachNumber = unitOfWork.CoachNumber.Get(u => u.Coach_Number == coachNumberId)
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
            CoachNumber? objFromDb = unitOfWork.CoachNumber.Get(c => c.Coach_Number == coachNumberVM.CoachNumber.Coach_Number);

            if (objFromDb is not null)
            {
                unitOfWork.CoachNumber.Remove(objFromDb);
                unitOfWork.Save();
                TempData["success"] = "The coach number has been deleted successfully.";
                return RedirectToAction("Index", "CoachNumber");
            }

            TempData["error"] = "Internal error while deleting the coach number.";
            return View();
        }
    }
}
