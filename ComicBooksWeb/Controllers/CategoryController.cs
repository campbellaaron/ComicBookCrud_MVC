using ComicBooksWeb.Data;
using ComicBooksWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComicBooksWeb.Controllers
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
            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj); // Adds Category object to the Category table 
                _context.SaveChanges();
                return RedirectToAction("Index"); // Redirect to Category controller
            }
            return View();
        }
    }
}
