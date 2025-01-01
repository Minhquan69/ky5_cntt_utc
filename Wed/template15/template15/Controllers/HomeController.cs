using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using template15.Models;

namespace template15.Controllers
{
	public class HomeController : Controller
	{
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();
        private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
            var lsttrandau = db.Trandaus.Take(7).ToList();
            ViewBag.DanhSachCauThu = db.Cauthus.AsNoTracking().Where(x => x.CauLacBoId == "101").ToList();

            // Kiểm tra số lượng cầu thủ
            var count = ViewBag.DanhSachCauThu.Count;

            if (count == 0)
            {
                Console.WriteLine("Không có cầu thủ nào trong ViewBag");
            }

            return View(lsttrandau);
        }

		public IActionResult Privacy()
		{
			return View();
		}
        [Route("CapNhatCauThu")]
        [HttpGet]
        public IActionResult CapNhatCauThu(string? idCauThu)
        {




            var cauThu = db.Cauthus.Where(c => c.CauThuId == idCauThu).FirstOrDefault();

            ViewBag.CauLacBoId = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
            return View(cauThu);

        }

        [Route("CapNhatCauThu")]
        [HttpPost]
        public IActionResult CapNhatCauThu(Cauthu cauthu)
        {


            if (ModelState.IsValid)
            {   //cach1
                db.Update(cauthu);
                //cach2  db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CauLacBoId = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");

            return View(cauthu);


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
