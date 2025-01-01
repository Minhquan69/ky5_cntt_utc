using de210705.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace de210705.Controllers
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
			var productAvailable = db.Products
						 .Where(p => p.Available == true) // Lọc sản phẩm có Available = true
						 .OrderBy(p => p.UnitPrice)      // Sắp xếp theo UnitPrice
						 .ToList();

			ViewData["dropdown"] = db.Categories.ToList();
			return View(productAvailable);
		}




		public IActionResult Privacy()
		{
			return View();
		}



        [HttpGet]
        public JsonResult GetData(int? categoryId)
        {
            var productlist = db.Products
                .Where(p =>
                    (categoryId == null || p.CategoryId == categoryId) // Nếu categoryId là null, bỏ qua lọc Category
                    && (categoryId != null || p.Available == true) // Nếu "Tất cả", chỉ lấy sản phẩm có Available = true
                )
                .OrderBy(p => p.Name) // Sắp xếp theo tên
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.UnitPrice,
                    p.Image
                })
                .ToList();

            return Json(productlist); // Trả về danh sách dưới dạng JSON
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
