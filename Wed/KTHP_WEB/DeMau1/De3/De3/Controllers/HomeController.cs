using De3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace De3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        OnlineShopContext db = new OnlineShopContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var topProducts = db.Products.Where(p => p.Available == true && p.UnitPrice <= 1000).OrderBy(p => p.UnitPrice).ToList();
            return View(topProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

		[Route("ThemProduct")]
		[HttpGet]
		public IActionResult ThemProduct()
		{
			ViewBag.Id = new SelectList(db.Categories.ToList(), "Id", "Name");
			return View();
		}

		[Route("ThemProduct")]
		[HttpPost]
		public IActionResult ThemProduct(Product product)
		{
			if (!ModelState.IsValid)
			{
				db.Products.Add(product);
				db.SaveChanges();
				return RedirectToAction("Index", "Home");
			}
			ViewBag.Id = new SelectList(db.Categories.ToList(), "Id", "Name");
			return View(product);
		}


		[HttpGet]
		public JsonResult GetData(int Id)
		{
			var productlist = (from sp in db.Products
							   where sp.CategoryId == Id
							   select sp).ToList();

			return Json(productlist);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
