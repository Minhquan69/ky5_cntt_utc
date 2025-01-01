using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebBanVali.Models;
using WebBanVali.Models.Authentication;
using X.PagedList;

namespace WebBanVali.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QlbanVaLiContext db = new QlbanVaLiContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
     
        public IActionResult Index(int ? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;  
            var listsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x=>x.TenSp);
            PagedList<TDanhMucSp>list = new PagedList<TDanhMucSp>(listsanpham, pageNumber, pageSize);
            return View(list);
        }
        public IActionResult SanPhamTheoLoai(string maloai, int? page)
        {
            int pageSize = 4;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            ViewBag.MaLoai = maloai;
            var listsp= db.TDanhMucSps.AsNoTracking().Where(x => x.MaLoai == maloai).OrderBy(x => x.TenSp);
            PagedList <TDanhMucSp> listsanpham = new PagedList<TDanhMucSp>(listsp, pageNumber, pageSize);
            return View(listsanpham);
        }
        public IActionResult ChiTietSanPham(string maSp)
        {
            var sanpham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
            var imgsp = db.TAnhSps.Where(x =>x.MaSp == maSp).ToList();
            ViewBag.imgsp = imgsp;
            return View(sanpham);
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
