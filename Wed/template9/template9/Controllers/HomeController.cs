using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using template9.Models;

namespace template9.Controllers
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
			var trongTai = db.Trongtais.ToList();
			return View(trongTai);
		}

        public IActionResult Privacy()
        {
            return View();
        }
		//ajax
		public JsonResult GetData(String TranDauID)
		{
			// Lấy danh sách trận đấu mà cầu thủ tham gia
			var trongTais = (from tt in db.TrongtaiTrandaus
							join td in db.Trongtais on tt.TrongTaiId equals td.TrongTaiId
							 where tt.TranDauId == TranDauID
							select td).ToList();


			return Json(trongTais);
		}
		[Route("CapNhatTrongTai")]
		[HttpGet]
		public IActionResult CapNhatTrongTai(string? idTrongTai)
		{
			var trongTai = db.Trongtais.Where(c => c.TrongTaiId == idTrongTai).FirstOrDefault();
			return View(trongTai);
		}
		[Route("CapNhatTrongTai")]
		[HttpPost]
		public IActionResult CapNhatTrongTai(Trongtai trongtai)
		{
			if (ModelState.IsValid)
			{   //cach1
				db.Update(trongtai);
				//cach2  db.Entry(sanPham).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index", "Home");
			}
			return View(trongtai);

		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
