using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Temp16.Models;

namespace Temp16.Controllers
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
            var list = db.Sanvandongs.ToList();
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ThemSVD()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ThemSVD(Sanvandong svd)
        {
            if (ModelState.IsValid)
            {
                db.Sanvandongs.Add(svd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(svd);
        }

        [HttpGet]
        [Route("SuaSVD")]
        public IActionResult SuaSVD(string SanVanDongID)
        {
            var svd = db.Sanvandongs.Find(SanVanDongID);
            return View(svd);
        }
        [HttpPost]
        [Route("SuaSVD")]
        public IActionResult SuaSVD(Sanvandong svd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(svd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(svd);
        }

        [HttpGet]
        [Route("ChiTiet")]
        public IActionResult ChiTiet(string SanVanDongID)
        {
            var tt = db.Sanvandongs.Find(SanVanDongID);
            return View(tt);
        }

        [HttpGet]
        [Route("XoaSVD")]
        public IActionResult XoaSVD(string SanVanDongID)
        {
            var svd = db.Sanvandongs.Find(SanVanDongID);
            if (svd != null)
            {
                db.Sanvandongs.Remove(svd);
                try
                {
                    int changes = db.SaveChanges();
                    if (changes > 0)
                    {
                        TempData["Message"] = "SVD đã được xóa thành công";
                    }
                    else
                    {
                        TempData["Message"] = "Không thể xóa SVD. Vui lòng thử lại.";
                    }
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Khong the xaa SVD. Vui long thu lai.";
                }
            }
            else
            {
                TempData["Message"] = "Không tìm thấy SVD với ID này.";
            }

            return RedirectToAction("Index", "Home");
        }

        //public JsonResult GetData(string TranDauId)
        //{
        //    var trandauList = (from a in db.Trandaus
        //                       where a.TranDauId == TranDauId
        //                       select a).ToList();
        //    return Json(trandauList);
        //}
        public JsonResult GetData(string TranDauId)
        {
            var cauthuList = (from ct in db.Cauthus
                               join tdct in db.TrandauCauthus on ct.CauThuId equals tdct.CauThuId
                               join td in db.Trandaus on tdct.TranDauId equals td.TranDauId
                               where td.TranDauId == TranDauId
                               select ct).ToList();
            return Json(cauthuList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
