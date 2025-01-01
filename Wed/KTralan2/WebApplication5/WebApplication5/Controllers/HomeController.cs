using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		QlthuVienContext db = new QlthuVienContext();

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			var list = db.TDocGia.ToList();
			return View(list);
		}

		public IActionResult Privacy()
		{
			return View();
		}

        [HttpGet]
        [Route("XoaBanSao")]
        public IActionResult XoaBanSao(string MaBanSao)
        {
            var lstmabansao = db.TBanSaoSaches.AsNoTracking().
                Where(x => x.MaBanSao == MaBanSao).Select(x => x.MaBanSao).ToList();
            var muonTras = db.TMuonTras
                .Where(mt => lstmabansao.Contains(mt.MaBanSao)).ToList();
            foreach (var muonTra in muonTras)
            {
                db.TMuonTras.Remove(muonTra);
                db.SaveChanges();
            }
            foreach (var maBanSao in lstmabansao)
            {
                var banSao = db.TBanSaoSaches.Find(maBanSao);
                if (banSao != null)
                {
                    db.TBanSaoSaches.Remove(banSao);
                    db.SaveChanges();
                }
            }
            // Xóa sách t? b?ng TSaches
            TempData["Message"] = "Sach da duoc xoa thanh cong";
            return RedirectToAction("Index", "Home");
        }
        public JsonResult GetData(string MaSach)
        {
            var sachList = (from s in db.TBanSaoSaches
                            where s.MaSach == MaSach
                            select s).OrderBy(x => x.MaSach).ToList();
            return Json(sachList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
