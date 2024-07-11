using ComicBookCrud.DataAccess.Repository.IRepository;
using ComicBookCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ComicBooksWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<ComicBook> books = _unitOfWork.ComicBook.GetAll(includeProperties: "Category");
            return View(books);
        }
        
        public IActionResult Details(int comicBookId)
        {
            ComicBook book = _unitOfWork.ComicBook.Get(u=>u.Id==comicBookId, includeProperties: "Category");
            return View(book);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
