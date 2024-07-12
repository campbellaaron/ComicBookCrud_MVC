using ComicBookCrud.DataAccess.Data;
using ComicBookCrud.DataAccess.Repository.IRepository;
using ComicBookCrud.Models;
using ComicBookCrud.Models.ViewModels;
using ComicBookCrud.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComicBooksWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ComicBookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ComicBookController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<ComicBook> objComicBookList = _unitOfWork.ComicBook.GetAll(includeProperties:"Category").ToList(); // Retrieves the list of Categories from the database using the DbContext set in Data folder
            return View(objComicBookList);
        }

        public IActionResult Publish(int? id)
        {
            // IEnumerable<SelectListItem> CategoryList;

            ComicBookVM comicBookVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString() // EF Core projection pulls Categories and puts it in a Select List
                }),
                ComicBook = new ComicBook()
            };
            if(id == null || id == 0)
            {
                // Create
                return View(comicBookVM);
            }
            else
            {
                // Update
                comicBookVM.ComicBook = _unitOfWork.ComicBook.Get(u=>u.Id == id);
                return View(comicBookVM);
            }
        }
        [HttpPost]
        public IActionResult Publish(ComicBookVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                // Add functionality to handle file uploads and an upload directory
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string comicImgPath = Path.Combine(wwwRootPath, @"images\comics");

                    if (!string.IsNullOrEmpty(obj.ComicBook.ImageUrl)) 
                    { 
                        // Delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, obj.ComicBook.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var filetream = new FileStream(Path.Combine(comicImgPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(filetream);
                    }

                    obj.ComicBook.ImageUrl = @"\images\comics\" + fileName;
                }

                if(obj.ComicBook.Id == 0)
                {
                    _unitOfWork.ComicBook.Add(obj.ComicBook); // Adds ComicBook object to the ComicBook table 
                }
                else
                {
                    _unitOfWork.ComicBook.Update(obj.ComicBook);
                }
                _unitOfWork.Save();
                TempData["success"] = "Comic Book published successfully";
                return RedirectToAction("Index"); // Redirect to ComicBook controller
            }
            else
            {
                obj.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString() // EF Core projection pulls Categories and puts it in a Select List
                });
                return View(obj);
            }
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ComicBook> objComicBookList = _unitOfWork.ComicBook.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objComicBookList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            var comicToBeDeleted = _unitOfWork.ComicBook.Get(u=>u.Id == id);

            if (comicToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while attempting to delete" });
            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, comicToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.ComicBook.Remove(comicToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Comic successfully deleted" });
        }

        #endregion
    }
}
