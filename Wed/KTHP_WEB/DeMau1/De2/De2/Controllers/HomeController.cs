using De2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace De2.Controllers
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
			var topProducts = db.Products.OrderBy(p => p.UnitPrice).Take(4).ToList();
            return View(topProducts);
		}

        public IActionResult Privacy()
        {
            return View();
        }

		[Route("SignUp")]
		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}

		[Route("SignUp")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult SignUp(Customer customer)
		{
			if (ModelState.IsValid)
			{
				db.Customers.Add(customer); // Lưu khách hàng vào database
				db.SaveChanges();
				return RedirectToAction("Index", "Home"); // Điều hướng về trang chính
			}
			return View(customer);
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
