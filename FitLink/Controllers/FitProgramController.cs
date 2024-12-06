using FitLink.Application.Common.Interfaces;
using FitLink.Domain.Entities;
using FitLink.Infrastructure.Data;
using FitLink.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FitLink.Controllers
{
	public class FitProgramController : Controller
	{
        private readonly IUnitOfWork unitOfWork;
        public FitProgramController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // get all fit programs
        public IActionResult Index()
		{
            var FitPrograms = unitOfWork.FitProgram.GetAll(includeProperties: "Coach");
			return View(FitPrograms);
		}





		// display create fit program view
		public IActionResult Create()
		{
            FitProgramVM FitProgramVM = new()
            {
                CoachList = unitOfWork.Coach.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
			return View(FitProgramVM);
		}

        // create the fit program post method
        [HttpPost]
        public IActionResult Create(FitProgramVM obj)
        {
            if (ModelState.IsValid)
			{
				unitOfWork.FitProgram.Add(obj.FitProgram);
                unitOfWork.Save();
                TempData["success"] = "The fit program has been created successfully.";
                return RedirectToAction("Index", "FitProgram");
			}

            obj.CoachList = unitOfWork.Coach.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(obj);
        }




        // display the update form of fit programs
        public IActionResult Update(int FitProgramId)
        {
            FitProgramVM FitProgramVM = new()
            {
                CoachList = unitOfWork.Coach.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                FitProgram = unitOfWork.FitProgram.Get(u => u.Id == FitProgramId)
            };

            if(FitProgramVM.FitProgram is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(FitProgramVM);
        }

        // update the fit program
        [HttpPost]
        public IActionResult Update(FitProgramVM FitProgramVM)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.FitProgram.Update(FitProgramVM.FitProgram);
                unitOfWork.Save();
                TempData["success"] = "The fit program has been updated successfully.";
                return RedirectToAction("Index", "FitProgram");
            }

            FitProgramVM.CoachList = unitOfWork.Coach.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(FitProgramVM);
        }





        // display delete page for fit program
        public IActionResult Delete(int FitProgramId)
        {
            FitProgramVM FitProgramVM = new()
            {
                CoachList = unitOfWork.Coach.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                FitProgram = unitOfWork.FitProgram.Get(u => u.Id == FitProgramId)
            };

            if (FitProgramVM.FitProgram is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(FitProgramVM);
        }

        // delete the fit program
        [HttpPost]
        public IActionResult Delete(FitProgramVM FitProgramVM)
        {
            FitProgram? objFromDb = unitOfWork.FitProgram.Get(c => c.Id == FitProgramVM.FitProgram.Id);

            if (objFromDb is not null)
            {
                unitOfWork.FitProgram.Remove(objFromDb);
                unitOfWork.Save();
                TempData["success"] = "The fit program has been deleted successfully.";
                return RedirectToAction("Index", "FitProgram");
            }

            TempData["error"] = "Internal error while deleting the fit program.";
            return View();
        }
    }
}
