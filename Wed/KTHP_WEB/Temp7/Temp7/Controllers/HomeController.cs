using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Temp7.Models;

namespace Temp7.Controllers
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
            var listCLB = (from clb in db.Caulacbos
                           join svd in db.Sanvandongs on clb.SanVanDongId equals svd.SanVanDongId
                           join hlv in db.Huanluyenviens on clb.HuanLuyenVienId equals hlv.HuanLuyenVienId
                           select new 
                           {
                               CLBID = clb.CauLacBoId,
                               TenCLB = clb.TenClb,
                               TenGoiTat = clb.TenGoi,
                               AnhClb = clb.Anh,
                               TenHLV = hlv.TenHlv,
                               TenSVD = svd.TenSan
                           }).ToList();

            return View(listCLB);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ChiTiet(string CauLacBoId)
        {
            var tt = (from clb in db.Caulacbos
                      join hlv in db.Huanluyenviens on clb.HuanLuyenVienId equals hlv.HuanLuyenVienId
                      join svd in db.Sanvandongs on clb.SanVanDongId equals svd.SanVanDongId
                      where clb.CauLacBoId == CauLacBoId
                      select new
                      {
                          CauLacBoID = clb.CauLacBoId,
                          Ten = clb.TenClb,
                          TenGOI = clb.TenGoi,
                          AnhClb = clb.Anh,
                          TenCLB = clb.TenClb,
                          TenHuanLuyenVien = hlv.TenHlv,
                          TenSanVanDong = svd.TenSan
                      }).FirstOrDefault();

            if (tt == null)
            {
                return NotFound();
            }

            // Truyền dữ liệu sang View
            return View(tt);
        }


        public IActionResult ThemCLB()
        {
            ViewBag.SanVanDongId = new SelectList(db.Sanvandongs.ToList(), "SanVanDongId", "TenSan");
            ViewBag.HuanLuyenVienId = new SelectList(db.Huanluyenviens.ToList(), "HuanLuyenVienId", "TenHlv");
            return View();
        }

        [HttpPost]
        public IActionResult ThemCLB(Caulacbo clb)
        {
            var existingBook = db.Caulacbos.FirstOrDefault(x => x.CauLacBoId == clb.CauLacBoId);
            if (existingBook != null)
            {
                ModelState.AddModelError("CauLacBoId", "Mã Câu Lạc Bộ đã tồn tại. Vui lòng nhập mã khác.");
            }
            if (ModelState.IsValid)
            {
                db.Caulacbos.Add(clb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SanVanDongId = new SelectList(db.Sanvandongs.ToList(), "SanVanDongId", "TenSan");
            ViewBag.HuanLuyenVienId = new SelectList(db.Huanluyenviens.ToList(), "HuanLuyenVienId", "TenHlv");
            return View(clb);
        }

        public JsonResult GetData(string CauLacBoID)
        {
            var trandauList = (from cauThu in db.Cauthus
                               where cauThu.CauLacBoId == CauLacBoID
                               select cauThu).OrderBy(x => x.HoVaTen).ToList();
            return Json(trandauList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
