using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using template15_1.Models;

namespace template15_1.Controllers
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
            var tranDau = db.Trandaus.Include(td => td.ClbkhachNavigation).Include(td => td.ClbnhaNavigation).Include(td => td.SanVanDong).Where(td => td.Clbnha == "101"|| td.Clbkhach == "101").ToList();
            return View(tranDau);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]

        public IActionResult ThemTranDau()
        {
            ViewBag.Clbkhach = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
            ViewBag.Clbnha = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
            ViewBag.SanVanDongId = new SelectList(db.Sanvandongs.ToList(), "SanVanDongId", "TenSan");
            return View();
        }


        [HttpPost]
        public IActionResult ThemTranDau(Trandau tranDau)
        {
            if (ModelState.IsValid)
            {
                // Thêm trận đấu mới vào cơ sở dữ liệu
                db.Trandaus.Add(tranDau);
                db.SaveChanges();

                // Sau khi thêm, chuyển hướng về trang danh sách hoặc trang chính
                return RedirectToAction("Index");
            }
            return View(tranDau);
        }
        //edit tran dau
        [HttpGet]

        public IActionResult SuaTranDau(string TranDauId)
        {
            ViewBag.Clbkhach = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
            ViewBag.Clbnha = new SelectList(db.Caulacbos.ToList(), "CauLacBoId", "TenClb");
            ViewBag.SanVanDongId = new SelectList(db.Sanvandongs.ToList(), "SanVanDongId", "TenSan");
            var tranDau = db.Trandaus.Find(TranDauId);

            return View(tranDau);
        }
        [HttpPost]
        public IActionResult SuaTranDau(Trandau tranDau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tranDau).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tranDau);
        }
        //chi tiet trean dau
        [HttpGet]
        public IActionResult ChiTietTranDaU(string TranDauId)
        {
            var tranDau = db.Trandaus.Find(TranDauId);
            return View(tranDau);
        }
        //xoa
        [HttpGet]
        public IActionResult XoaSanPham(string TranDauId)
        {
            //TempData["Message"] = "Khong duoc xoa san pham nay";
            //var  tranDaus= _context.Trandaus.Where(x => x.TranDauId == TranDauId).ToList();
            //if (tranDaus.Count > 0) return RedirectToAction("Index");

            db.Remove(db.Trandaus.Find(TranDauId));
            db.SaveChanges();
            TempData["Message"] = "San Pham da duoc xoa";
            return RedirectToAction("Index");
        }
        //ajax
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
