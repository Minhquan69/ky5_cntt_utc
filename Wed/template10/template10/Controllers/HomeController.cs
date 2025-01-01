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
		QlgiaiBongDaContext db = new QlgiaiBongDaContext();

		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var trongTai = db.Trongtais.Take(12).ToList();
            return View(trongTai);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ThemTrongTai()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ThemTrongTai(Trongtai trongTai)
        {
            if (ModelState.IsValid)
            {
                // Thêm trận đấu mới vào cơ sở dữ liệu
                db.Trongtais.Add(trongTai);
                db.SaveChanges();

                // Sau khi thêm, chuyển hướng về trang danh sách hoặc trang chính
                return RedirectToAction("Index");
            }
            return View(trongTai);
        }
        //edit tran dau
        [HttpGet]

        public IActionResult SuaTrongTai(string TrongTaiId)
        {
            
            var trongtai = db.Trongtais.Find(TrongTaiId);

            return View(trongtai);
        }
        [HttpPost]
        public IActionResult SuaTrongTai(Trongtai trongTai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trongTai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trongTai);
        }
        //chi tiet trean dau
        [HttpGet]
        public IActionResult ChiTietTrongTai(string TrongTaiId)
        {
            var trongTai = db.Trongtais.Find(TrongTaiId);
            return View(trongTai);
        }
        //xoa
        [HttpGet]
        public IActionResult XoaTrongTai(string TrongTaiId)
        {
            //TempData["Message"] = "Khong duoc xoa san pham nay";
            //var  tranDaus= _context.Trandaus.Where(x => x.TranDauId == TranDauId).ToList();
            //if (tranDaus.Count > 0) return RedirectToAction("Index");

            db.Remove(db.Trongtais.Find(TrongTaiId));
            db.SaveChanges();
            TempData["Message"] = "San Pham da duoc xoa";
            return RedirectToAction("Index");
        }

        public JsonResult GetData(String SanVanDongId)
        {
            // Lấy danh sách trận đấu mà cầu thủ tham gia
            var trandau= (from svd in db.Sanvandongs
                            join td in db.Trandaus on svd.SanVanDongId equals td.SanVanDongId
                            where svd.SanVanDongId == SanVanDongId
                            select td).ToList();


            return Json(trandau);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
