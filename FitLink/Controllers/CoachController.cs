using FitLink.Application.Common.Interfaces;
using FitLink.Domain.Entities;
using FitLink.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace FitLink.Controllers
{
	public class CoachController : Controller
	{
		private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CoachController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            this.unitOfWork = unitOfWork;
            this.webHostEnvironment = webHostEnvironment;
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
                // function to add an image from local machine rather than a url link
                if(obj.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                    string imagePath = Path.Combine(webHostEnvironment.WebRootPath, @"images\CoachImage");

                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    obj.Image.CopyTo(fileStream);

                    obj.ImageUrl = @"\images\CoachImage\" + fileName;
                }
                else
                {
                    obj.ImageUrl = "https://www.pngkey.com/png/full/73-730477_first-name-profile-image-placeholder-png.png";
                }

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

				if (obj.Image != null)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
					string imagePath = Path.Combine(webHostEnvironment.WebRootPath, @"images\CoachImage");

                    if(!string.IsNullOrEmpty(obj.ImageUrl)) // check if imageUrl is there
                    {
                        var oldImagePath = Path.Combine(webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\')); // then dont delete it, else replace it

                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

					using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
					obj.Image.CopyTo(fileStream);

					obj.ImageUrl = @"\images\CoachImage\" + fileName;
				}

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
				if (!string.IsNullOrEmpty(objFromDb.ImageUrl)) // check if imageUrl is there
				{
					var oldImagePath = Path.Combine(webHostEnvironment.WebRootPath, objFromDb.ImageUrl.TrimStart('\\'));

					if (System.IO.File.Exists(oldImagePath))
					{
						System.IO.File.Delete(oldImagePath);
					}
				}

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
