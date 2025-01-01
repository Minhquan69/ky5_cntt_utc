using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using template1.Models;

namespace template1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();

        public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
            var cauthu = db.Cauthus.Include(td => td.CauLacBo).Take(50).ToList();
            return View(cauthu);
        }

		public IActionResult Privacy()
		{
			return View();
		}
        [HttpGet]
        public IActionResult ThemCauThu()
        {          
            ViewBag.CauLacBoId = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
            return View();
        }
        [HttpPost]
        public IActionResult ThemCauThu(Cauthu cauThu)
        {
            if (ModelState.IsValid)
            {
                // Thêm trận đấu mới vào cơ sở dữ liệu
                db.Cauthus.Add(cauThu);
                db.SaveChanges();

                // Sau khi thêm, chuyển hướng về trang danh sách hoặc trang chính
                return RedirectToAction("Index");
            }
            return View(cauThu);
        }

        //ajax
        public JsonResult GetData(String cauLacBoId)
        {
            // Lấy danh sách trận đấu mà cầu thủ tham gia
            var cauthus = (from clb in db.Caulacbos
                            join ct in db.Cauthus on clb.CauLacBoId equals ct.CauLacBoId
                            where ct.CauLacBoId == cauLacBoId
                            select ct).ToList();


            return Json(cauthus);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
