using DaoMinhQuan_N05_221230966.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using X.PagedList.Extensions;

namespace DaoMinhQuan_N05_221230966.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

		public IActionResult Index()
		{
			return View();
		}
		//public IActionResult Index(int? page)
		//{
		//	int pageNumber = page ?? 1; // Số trang hiện tại, mặc định là 1
		//	int pageSize = 6; // Số phần tử trên mỗi trang
		//					  // Giả sử bạn có danh sách dữ liệu (dùng danh sách tạm thời để minh họa)
		//	var rooms = Enumerable.Range(1, 24).Select(i => new {
		//		Id = i,
		//		Name = $"Fujifilm X100T 16 MP Digital Camera {i}",
		//		Price = $"$520.00",
		//		ImageUrl = "../Temp/images/product_1.png"
		//	});
		//	// Phân trang
		//	var pagedList = rooms.ToPagedList(pageNumber, pageSize);
		//	return View(pagedList);
		//}

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
