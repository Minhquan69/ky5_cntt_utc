using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using template10.Models;

namespace template10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

		QliGiaiBongDaContext db = new QliGiaiBongDaContext();

		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
			var tranDau = db.Trandaus.AsNoTracking().Where(x => x.Clbkhach == "101" || x.Clbnha == "101").ToList();
            return View(tranDau);
        }

        public IActionResult Privacy()
        {
            return View();
        }

		public IActionResult ThemTranDau()
		{
			ViewBag.Clbkhach = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
			ViewBag.Clbnha = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
			ViewBag.SanVanDongId = new SelectList(db.Sanvandongs.ToList(), "SanVanDongId", "TenSan");
			return View();
		}

		[HttpPost]
		public IActionResult ThemTranDau(Trandau td)
		{
			var existingBook = db.Trandaus.FirstOrDefault(x => x.TranDauId == td.TranDauId);
			if (existingBook != null)
			{
				ModelState.AddModelError("TranDauId", "Mã Tran Dau đã tồn tại. Vui lòng nhập mã khác.");
			}
            if (td.Clbnha.Equals(td.Clbkhach)  )
            {
                ModelState.AddModelError("Clbkhach", "CLB nhà và CLB khách không được trùng nhau.");
            }
            if (ModelState.IsValid)
			{
				db.Trandaus.Add(td);
				db.SaveChanges();
				return RedirectToAction("Index"); // Quay về trang danh sách sách
			}
			ViewBag.Clbkhach = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
			ViewBag.Clbnha = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
			ViewBag.SanVanDong = new SelectList(db.Sanvandongs.ToList(), "SanVanDongId", "TenSan");
			return View(td);
		}

		public JsonResult GetData(String CauThuId)
		{
			// Lấy danh sách trận đấu mà cầu thủ tham gia
			var tranDaus = (from tg in db.TrandauCauthus
							join td in db.Trandaus on tg.TranDauId equals td.TranDauId
							where tg.CauThuId == CauThuId
							select td).ToList();
			return Json(tranDaus);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
