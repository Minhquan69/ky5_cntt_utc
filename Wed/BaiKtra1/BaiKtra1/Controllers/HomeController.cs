using BaiKtra1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BaiKtra1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QlgiaiBongDaContext _context = new QlgiaiBongDaContext();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var tranDau = (from td in _context.Trandaus
                           join svd in _context.Sanvandongs on td.SanVanDongId equals svd.SanVanDongId
                           join clb in _context.Caulacbos on svd.SanVanDongId equals clb.SanVanDongId
                           where clb.CauLacBoId == "101" 
                           select td
                          ).ToList();
            return View(tranDau);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ChitietTranDau(string CauThuId)
        {
            // Lấy thông tin của cầu thủ
            var cauThu = _context.Cauthus.SingleOrDefault(x => x.CauThuId == CauThuId);

            if (cauThu == null)
            {
                return NotFound();
            }

            // Lấy danh sách trận đấu mà cầu thủ tham gia
            var tranDaus = (from tg in _context.TrandauCauthus
                            join td in _context.Trandaus on tg.TranDauId equals td.TranDauId
                            where tg.CauThuId == CauThuId
                            select td).ToList();

            // Truyền thông tin cầu thủ và danh sách trận đấu qua ViewBag
            ViewBag.CauThu = cauThu;
            return View(tranDaus);
        }


        [HttpPost]
        public IActionResult ThemTranDau(Trandau tranDau)
        {
            if (ModelState.IsValid)
            {
                // Thêm trận đấu mới vào cơ sở dữ liệu
                _context.Trandaus.Add(tranDau);
                _context.SaveChanges();

                // Sau khi thêm, chuyển hướng về trang danh sách hoặc trang chính
                return RedirectToAction("Index");
            }

            // Nếu có lỗi, giữ lại dữ liệu và hiển thị form lại
            ViewBag.SanVanDongs = _context.Sanvandongs.ToList();
            ViewBag.CauLacBos = _context.Caulacbos.ToList();
            return View(tranDau);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
