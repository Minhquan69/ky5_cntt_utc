using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Tem23_10.Models;

namespace Tem23_10.Controllers
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
            var lstSach = db.TSaches.ToList();
            return View(lstSach);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        [Route("XoaSach")]
        public IActionResult XoaSach(string MaSach)
        {
            var lstmabansao = db.TBanSaoSaches.AsNoTracking().
                Where(x => x.MaSach == MaSach).Select(x => x.MaBanSao).ToList();
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
            var sach = db.TSaches.Find(MaSach);
            if (sach != null)
            {
                db.TSaches.Remove(sach);
                db.SaveChanges();
            }
            TempData["Message"] = "Sach da duoc xoa thanh cong";
            return RedirectToAction("Index", "Home");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
