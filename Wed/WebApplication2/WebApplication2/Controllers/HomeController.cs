using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication2.Models;
using X.PagedList;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QlthuVienContext db = new QlthuVienContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index(int? page)
        //{
        //    var listsach = db.TSaches.ToList();
        //    return View(listsach);
        //}
        public IActionResult Index(int? page)
        {
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            int pageSize = 12;
            var listsach = db.TDocGia.ToList();
            PagedList<TDocGium> lst = new PagedList<TDocGium>
                (listsach, pageNumber, pageSize);
            return View(lst);
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ThemSach()
        {
            ViewBag.MaNgonNgu = new SelectList(db.TNgonNgus.ToList(), "MaNgonNgu", "TenNgonNgu");
            ViewBag.MaNxb = new SelectList(db.TNhaXbs.ToList(), "MaNxb", "TenNxb");
            ViewBag.MaLoai = new SelectList(db.TLoaiSaches.ToList(), "MaLoai", "TenLoai");

            TempData["Message"] = "Sach da them thanh cong Thay Luan oi";
            return View();
        }

        [HttpPost]
        public IActionResult ThemSach(TSach s)
        {
            // Kiểm tra xem mã sách đã tồn tại hay chưa
            var existingBook = db.TSaches.FirstOrDefault(x => x.MaSach == s.MaSach);
            if (existingBook != null)
            {
                ModelState.AddModelError("MaSach", "Mã sách đã tồn tại. Vui lòng nhập mã khác.");
            }

            if (ModelState.IsValid)
            {
                db.TSaches.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index"); // Quay về trang danh sách sách
            }
            ViewBag.MaNgonNgu = new SelectList(db.TNgonNgus.ToList(), "MaNgonNgu", "TenNgonNgu");
            ViewBag.MaNxb = new SelectList(db.TNhaXbs.ToList(), "MaNxb", "TenNxb");
            ViewBag.MaLoai = new SelectList(db.TLoaiSaches.ToList(), "MaLoai", "TenLoai");
            return View(s);
        }

        //[HttpGet]
        //[Route("SuaDG")]
        //public IActionResult SuaDG(string MaDG)
        //{
        //    var sach = db.TDocGia.Find(MaDG);
        //    return View(sach);
        //}
        //[HttpPost]
        //[Route("SuaDG")]
        //public IActionResult SuaDG(TDocGium sach)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(sach).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(sach);
        //}

   //     [HttpGet]
   //     [Route("ChiTietSach")]
   //     public IActionResult ChiTietSach(string MaSach)
   //     {
   //         var sach = db.TSaches.Find(MaSach);
   //         return View(sach);
   //     }

   //     [HttpGet]
   //     [Route("XoaSach")]
   //     public IActionResult XoaSach(string MaSach)
   //     {
   //         var lstmabansao = db.TBanSaoSaches.AsNoTracking().
   //             Where(x => x.MaSach == MaSach).Select(x => x.MaBanSao).ToList();
			//var muonTras = db.TMuonTras
		 //       .Where(mt => lstmabansao.Contains(mt.MaBanSao)).ToList();
			//foreach (var muonTra in muonTras)
			//{
			//	db.TMuonTras.Remove(muonTra);
			//	db.SaveChanges();
			//}
			//foreach (var maBanSao in lstmabansao)
			//{
			//	var banSao = db.TBanSaoSaches.Find(maBanSao);
			//	if (banSao != null)
			//	{
			//		db.TBanSaoSaches.Remove(banSao);
			//		db.SaveChanges();
			//	}
			//}
			//// Xóa sách từ bảng TSaches
			//var sach = db.TSaches.Find(MaSach);
			//if (sach != null)
			//{
			//	db.TSaches.Remove(sach);
			//	db.SaveChanges();
			//}
   //         TempData["Message"] = "Sach da duoc xoa thanh cong";
   //         return RedirectToAction("Index", "Home");
   //     }

        public JsonResult GetData(string MaNxb)
        {
            // Lấy danh sách sách theo mã nhà xuất bản
            var sachList = (from s in db.TSaches
                            where s.MaNxb == MaNxb
                            select s).OrderBy(x => x.TenSach).ToList();
            return Json(sachList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
