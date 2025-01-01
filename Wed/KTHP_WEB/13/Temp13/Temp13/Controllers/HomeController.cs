using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Temp13.Models;
using X.PagedList.Extensions;

namespace Temp13.Controllers
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
        // Tạo danh sách mẫu (giả sử danh sách này đến từ cơ sở dữ liệu)
        var itemList = Enumerable.Range(1, 36)
                                  .Select(i => new
                                  {
                                      Id = i,
                                      Name = $"Proin vel ligula {i}",
                                      Price = 15.00m,
                                      ImageUrl = $"../Temp/assets/images/item-01.jpg"
                                  });

        // Số trang hiện tại
        int pageNumber = page ?? 1; // Mặc định là trang 1
        int pageSize = 12; // Số mục trên mỗi trang
        var pagedList = itemList.ToPagedList(pageNumber, pageSize);

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
