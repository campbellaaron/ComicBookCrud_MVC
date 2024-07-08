using ComicBookCrud.DataAccess.Data;
using ComicBookCrud.DataAccess.Repository.IRepository;
using ComicBookCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComicBooksWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList(); // Retrieves the list of Categories from the database using the DbContext set in Data folder
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Category Name cannot be the exact same as the Display Order");
            }
            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "The value of \"Test\" is invalid.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj); // Adds Category object to the Category table 
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index"); // Redirect to Category controller
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(c => c.Id == id);
            if (categoryFromDb == null) { return NotFound(); }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj); // Adds Category object to the Category table 
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index"); // Redirect to Category controller
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(c => c.Id == id);
            if (categoryFromDb == null) { return NotFound(); }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(c => c.Id == id);
            if (obj == null) { return NotFound(); }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index"); // Redirect to Category controller
        }
    }
}
