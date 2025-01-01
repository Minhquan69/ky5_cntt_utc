using de210704.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace de210704.Controllers
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
			var topProducts = db.Products.OrderByDescending(p => p.UnitPrice).Take(3).ToList();
		ViewData["category"]=	db.Categories.ToList();
			return View(topProducts);
		}
		public IActionResult Privacy()
        {
            return View();
        }


		[HttpGet]
		public JsonResult GetData(string name)
		{
			var productlist = db.Products
								.Where(p => string.IsNullOrEmpty(name) || p.Name.Contains(name)) // Lọc nếu có từ khóa
								.OrderBy(p => p.Name) // Sắp xếp theo tên
								.Select(p => new
								{
									p.Id,
									p.Name,
									p.UnitPrice,
									p.Image
								}).ToList();

			return Json(productlist); // Trả về dữ liệu JSON
		}

		[Route("SignUp")]
		[HttpGet]
		public IActionResult SignUp()
		{
			ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "Name");
			return View();
		}

		[Route("SignUp")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult SignUp(Product product)
		{
			if (ModelState.IsValid)
			{
				db.Products.Add(product); // Lưu khách hàng vào database
				db.SaveChanges();
				return RedirectToAction("Index", "Home"); // Điều hướng về trang chính
			}
			ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "Name");

			return View(product);
		}








		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
