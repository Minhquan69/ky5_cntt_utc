using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using temp18.Models;
using X.PagedList;

namespace temp18.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		QliGiaiBongDaContext db = new QliGiaiBongDaContext();

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			var listtrongtai = db.Trongtais.OrderBy(x => x.TrongTaiId).Take(8).ToList();
			return View(listtrongtai);
		}

		public IActionResult Privacy()
		{
			return View();
		}
        public IActionResult ChiTiet()
        {
            return View();
        }

        [HttpGet]
		[Route("SuaTrongTai")]
		public IActionResult SuaTrongTai(string TrongTaiId)
		{
			var trongtai = db.Trongtais.Find(TrongTaiId);
			return View(trongtai);
		}
		[HttpPost]
		[Route("SuaTrongTai")]
		public IActionResult SuaTrongTai(Trongtai trongtai)
		{
			if (ModelState.IsValid)
			{
				db.Entry(trongtai).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(trongtai);
		}
		[HttpGet]
		[Route("ChiTiet")]
		public IActionResult ChiTiet(string TrongTaiId)
		{
			var tt = db.Trongtais.Find(TrongTaiId);
			return View(tt);
		}

		public JsonResult GetData(string TranDauId)
        {
            
			var sachList = (from tg in db.TrongtaiTrandaus
							join td in db.Trongtais on tg.TrongTaiId equals td.TrongTaiId
							where tg.TranDauId == TranDauId
							select td).ToList();
			return Json(sachList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
