using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestKT2._1.Models;

namespace TestKT2._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		QlthuVienContext db = new QlthuVienContext();
		QlthuVienContext _context = new QlthuVienContext();

		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
			var listdocgia = db.TDocGia.Take(12).ToList();
			return View(listdocgia);
		}


        [HttpGet]
        public JsonResult GetData(string tennxb)
        {
            var manxb = db.TNhaXbs
                          .Where(tnxb => tnxb.TenNxb == tennxb)
                          .Select(tnxb=>tnxb.MaNxb)
                          .FirstOrDefault();

            if (manxb != null)
            {
                var TenSach = (
                    from ts in db.TSaches
                    where ts.MaNxb == manxb
                    select ts
                ).ToList();

                return Json(TenSach);
            }
            else
            {
                // Trả về thông báo khi không tìm thấy MaLoai tương ứng
                return Json(new { message = "Không tìm thấy loại sách." });
            }
        }

        [Route("SuaThongTin")]
        [HttpGet]
        public IActionResult SuaThongTin(string masach)
        {
            var sach = _context.TSaches.Find(masach);
            if (sach == null)
            {
                return NotFound();
            }

            ViewBag.MaLoai = new SelectList(_context.TLoaiSaches, "MaLoai", "TenLoai");
            ViewBag.MaNgonNgu = new SelectList(_context.TNgonNgus, "MaNgonNgu", "TenNgonNgu");
            ViewBag.MaNxb = new SelectList(_context.TNhaXbs, "MaNxb", "TenNxb");

            return View(sach);
        }


        [Route("SuaThongTin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaThongTin(TSach sach)
        {
            if (ModelState.IsValid)
            {
                var sach01 = db.TSaches.AsNoTracking().SingleOrDefault(tt => tt.MaSach == sach.MaSach);
                if (sach01 == null)
                {
                    return NotFound("Sách không tồn tại hoặc đã bị xóa.");
                }

                try
                {
                    db.Entry(sach).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    ModelState.AddModelError("", "Không thể lưu thay đổi. Dữ liệu có thể đã bị thay đổi bởi người dùng khác.");
                    return View(sach);
                }

                return RedirectToAction("Index");
            }

            return View(sach);
        }

        public IActionResult ThemSach()
        {
            ViewBag.MaNgonNgu = new SelectList(db.TNgonNgus.ToList(), "MaNgonNgu", "TenNgonNgu");
            ViewBag.MaNxb = new SelectList(db.TNhaXbs.ToList(), "MaNxb", "TenNxb");
            ViewBag.MaLoai = new SelectList(db.TLoaiSaches.ToList(), "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult ThemSach(TSach s)
        {
            if (ModelState.IsValid)
            {
                db.TSaches.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            ViewBag.MaNgonNgu = new SelectList(db.TNgonNgus.ToList(), "MaNgonNgu", "TenNgonNgu");
            ViewBag.MaNxb = new SelectList(db.TNhaXbs.ToList(), "MaNxb", "TenNxb");
            ViewBag.MaLoai = new SelectList(db.TLoaiSaches.ToList(), "MaLoai", "TenLoai");
            return View(s);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
