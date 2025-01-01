using KtraLtweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            //var cauThu = (from tg in _context.TrandauCauthus
            //              join td in _context.Trandaus on tg.TranDauId equals td.TranDauId
            //              join ct in _context.Cauthus on tg.CauThuId equals ct.CauThuId
            //              where ct.CauLacBoId == "101"
            //              select ct).ToList();

            var cauThu = _context.Cauthus
            .Include(ct => ct.CauLacBo)
            .Where(ct => ct.CauLacBoId == "101")
            .ToList();
            return View(cauThu);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]

        public IActionResult SuaCauThu(string CauThuId)
        {
            ViewBag.CauLacBoId = new SelectList(_context.Caulacbos.ToList(), "CauLacBoId", "TenClb");
            var cauThu = _context.Trandaus.Find(CauThuId);
            return View(cauThu);
        }
        [HttpPost]
        public IActionResult SuaTranDau(Cauthu cauThu)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(cauThu).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cauThu);
        }
        [HttpGet]
        public JsonResult GetData(String TranDauId)
        {
            var cauThu = (from ct in _context.Cauthus
                          join tdct in _context.TrandauCauthus on ct.CauThuId equals tdct.CauThuId
                          join td in _context.Trandaus on tdct.TranDauId equals td.TranDauId
                          where td.TranDauId == TranDauId
                          select ct).ToList();
            return Json(cauThu);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
