using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanVali.Models;

namespace WebBanVali.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/home")]
    public class HomeAdminController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();

        // Default route for index
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        // Route for DanhMucSanPham
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham()
        {
            var listsp = db.TDanhMucSps.ToList();
            return View(listsp);
        }

        // Route for displaying the Create form
        [Route("themsanpham")]
        [HttpGet]
        public IActionResult Create1()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            return View();
        }

        // Route for submitting the Create form (POST)
        [Route("themsanpham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create1(TDanhMucSp sp)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sp);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View();
        }

        // Route for displaying the Edit form
        [Route("edit")]
        [HttpGet]
        public IActionResult Edit(string id)
        {

            //ViewBag.Maloai = new SelectList(db.TLoaiSps, "Maloai", "Loai");
            //ViewBag.MaDt = new SelectList(db.TLoaiDts, "MaDt", "TenLoai");
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");

            var sp = db.TDanhMucSps.Find(id);
            
            return View(sp);
        }

        // Route for subitting the Edit form (POST)
        [Route("edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TDanhMucSp sp)
        { 
            if (ModelState.IsValid)
            {
               db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            return View(sp);
        }

       

        // Route for displaying the delete confirmation page (GET)
        [Route("delete")]
        public IActionResult Delete(string id)
        {
            TempData["Message"] = "";
            var chiTietSanPham= db.TChiTietSanPhams.Where(x =>x.MaSp==id).ToList();
            if (chiTietSanPham.Count() > 0)
            {
                TempData["Message"] = "Khong xoa duoc san pham";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");

            }
            var img = db.TAnhSps.Where(x => x.MaSp==id);
            if(img.Any()) db.RemoveRange(img);
            db.Remove(db.TDanhMucSps.Find(id));
            db.SaveChanges();
            TempData["Message"] = "San pahm da duoc xoa";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");

        }
    }
}
