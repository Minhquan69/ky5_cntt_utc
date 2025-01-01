using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Temp17.Models;
using X.PagedList;

namespace Temp17.Controllers
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
            var listHLV = db.Huanluyenviens.ToList();
            return View(listHLV);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ThemHLV()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThemHLV(Huanluyenvien hlv)
        {
            if (ModelState.IsValid)
            {
                db.Huanluyenviens.Add(hlv);
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(hlv);
        }

        [HttpGet]
        [Route("SuaHLV")]
        public IActionResult SuaHLV(string HuanLuyenVienId)
        {
            var hlv = db.Huanluyenviens.Find(HuanLuyenVienId);

            return View(hlv);
        }
        [HttpPost]
        [Route("SuaHLV")]
        public IActionResult SuaHLV(Huanluyenvien hlv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hlv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hlv);
        }

        [HttpGet]
        [Route("XoaHLV")]
        public IActionResult XoaHLV(string HuanLuyenVienId)
        {
            var hlv = db.Huanluyenviens.Find(HuanLuyenVienId);
            if (hlv != null)
            {
                db.Huanluyenviens.Remove(hlv);
                db.SaveChanges();
            }
            TempData["Message"] = "HLV da duoc xoa thanh cong";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("ChiTiet")]
        public IActionResult ChiTiet(string HuanLuyenVienId)
        {
            var tt = db.Huanluyenviens.Find(HuanLuyenVienId);
            return View(tt);
        }

        public JsonResult GetData(string CauLacBoID)
        {
            var trandauList = (from a in db.Trandaus
                               join b1 in db.Caulacbos on a.Clbkhach equals b1.CauLacBoId into clbKhach
                               from b1 in clbKhach.DefaultIfEmpty()
                               join b2 in db.Caulacbos on a.Clbnha equals b2.CauLacBoId into clbChu
                               from b2 in clbChu.DefaultIfEmpty()
                               where (b1 != null && b1.CauLacBoId == CauLacBoID) || (b2 != null && b2.CauLacBoId == CauLacBoID)
                               select new
                               {
                                   TenCLBKhach = b1.TenClb,
                                   TenCLBNha = b2.TenClb,
                                   Ngay = a.NgayThiDau,
                                   Anhtt = a.Anh,
                                   KetQuatt = a.KetQua
                               }).Take(9).ToList();
            return Json(trandauList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
