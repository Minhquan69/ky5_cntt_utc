using DaoMinhQuan_N05_221230966.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DaoMinhQuan_N05_221230966.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        QlbanNoiContext db = new QlbanNoiContext();

        public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
            var list = db.SanPhams.OrderBy(x=>x.TenSanPham).ToList();
            return View(list);
        }

		public IActionResult Privacy()
		{
			return View();
		}

        public IActionResult Them()
        {
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais.ToList(), "MaPhanLoai", "PhanLoaiChinh");
            ViewBag.MaPhanLoaiPhu = new SelectList(db.PhanLoaiPhus.ToList(), "MaPhanLoaiPhu", "TenPhanLoaiPhu");
            return View();
        }
        [HttpPost]
        public IActionResult Them(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais.ToList(), "MaPhanLoai", "PhanLoaiChinh");
            ViewBag.MaPhanLoaiPhu = new SelectList(db.PhanLoaiPhus.ToList(), "MaPhanLoaiPhu", "TenPhanLoaiPhu");
            return View(sp);
        }
        [HttpGet]
        public JsonResult GetData(string MaPhanLoai)
        {
            var List = (from sp in db.SanPhams
                              where sp.MaPhanLoai == MaPhanLoai
                              select sp).ToList();
            return Json(List);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
