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

        public IActionResult Index(int? page)
        {
			int pageNumber = page ?? 1; 
			int pageSize = 6;
			var sp = Enumerable.Range(1, 24).Select(i => new {
				Id = i,
				Name = $"Whirlpool LTE5243D  {i}",
				Price = $"$839.93",
				ImageUrl = "../Temp/images/product-img1.jpg"
			});
			// Phân trang
			var pagedList = sp.ToPagedList(pageNumber, pageSize);
			return View(pagedList);
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
