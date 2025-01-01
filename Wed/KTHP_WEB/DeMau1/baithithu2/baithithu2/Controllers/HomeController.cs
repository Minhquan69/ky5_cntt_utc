using baithithu2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace baithithu2.Controllers
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
            var sp = db.Products.OrderBy(x => x.UnitPrice).Take(4).ToList();
            return View(sp);
        }

        public IActionResult Privacy()
        {
            return View();
        }

		[HttpGet]
		public JsonResult GetData(string name)
		{
			if (string.IsNullOrEmpty(name))
				return Json(new List<Product>()); // Trả về danh sách rỗng nếu từ khóa trống

			var productlist = db.Products
								.Where(p => p.Name.Contains(name)) // Tìm kiếm theo từ khóa
								.OrderBy(p => p.Name) // Sắp xếp theo tên
								.Select(p => new
								{
									p.Id,
									p.Name,
									p.UnitPrice,
									p.Image
								})
								.ToList();

			return Json(productlist); // Trả về dữ liệu JSON
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
