using Magazine.Data;
using Magazine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing.Printing;

namespace Magazine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MagazineContext _context;
        public HomeController(ILogger<HomeController> logger,MagazineContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View(_context.Products);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return View(_context.Categories);
        }
        public async Task<IActionResult> Notebooks(
            
    string currentFilter,
    string searchString,
    int? pageNumber)
        {
           

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var products = from s in _context.Products.Where(s => s.Category.CategoryName == "Laptops")
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name!.Contains(searchString));
            }
            int pageSize = 3;
            return View(await PaginatedList<Product>.CreateAsync(products.Include(p => p.Category).AsNoTracking(), pageNumber ?? 1, pageSize));
           
        }
        public async Task<IActionResult> Computers(

    string currentFilter,
    string searchString,
    int? pageNumber)
        {


            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var products = from s in _context.Products.Where(s => s.Category.CategoryName == "Computers")
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name!.Contains(searchString));
            }
            int pageSize = 3;
            return View(await PaginatedList<Product>.CreateAsync(products.Include(p => p.Category).AsNoTracking(), pageNumber ?? 1, pageSize));

        }
        public async Task<IActionResult> Phones(

   string currentFilter,
   string searchString,
   int? pageNumber)
        {


            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var products = from s in _context.Products.Where(s => s.Category.CategoryName=="Phones")
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name!.Contains(searchString));
            }
            int pageSize = 3;
            return View(await PaginatedList<Product>.CreateAsync(products.Include(p => p.Category).AsNoTracking(), pageNumber ?? 1, pageSize));

        }
        public async Task<IActionResult> Cameras(

   string currentFilter,
   string searchString,
   int? pageNumber)
        {


            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var products = from s in _context.Products.Where(s => s.Category.CategoryName == "Cameras")
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name!.Contains(searchString));
            }
            int pageSize = 3;
            return View(await PaginatedList<Product>.CreateAsync(products.Include(p => p.Category).AsNoTracking(), pageNumber ?? 1, pageSize));

        }
        public IActionResult Testimonial()
        {
            return View();
        }
        public IActionResult Why()
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