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
		//	int pageNumber = page ?? 1;
		//	int pageSize = 6;
		//	var sp = Enumerable.Range(1, 24).Select(i => new {
		//		Id = i,
		//		Name = $"Product name {i}",
		//		Text = $"Lorem Ipsum is simply dummy text.",
		//		Text1 = $"$222.00",
		//		ImageUrl = "../Temp/themes/images/products/6.jpg"
		//	});
		//	// Phân trang
		//	var pagedList = sp.ToPagedList(pageNumber, pageSize);
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
