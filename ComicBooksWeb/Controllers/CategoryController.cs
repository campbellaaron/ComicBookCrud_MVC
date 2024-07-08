using ComicBookCrud.DataAccess.Data;
using ComicBookCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComicBookCrud.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ComicCrudDbContext _context;
        public CategoryController(ComicCrudDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _context.Categories.ToList(); // Retrieves the list of Categories from the database using the DbContext set in Data folder
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
                _context.Categories.Add(obj); // Adds Category object to the Category table 
                _context.SaveChanges();
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
            Category? categoryFromDb = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryFromDb == null) { return NotFound(); }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            
            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj); // Adds Category object to the Category table 
                _context.SaveChanges();
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
            Category? categoryFromDb = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryFromDb == null) { return NotFound(); }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (obj == null) { return NotFound(); }
            _context.Categories.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index"); // Redirect to Category controller
        }
    }
}
