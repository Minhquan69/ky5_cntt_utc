using Azure;
using DeMau.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace DeMau.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		QlhangHoaContext db = new QlhangHoaContext();
		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var list = db.HangHoas.Where(x => x.Gia >= 100).ToList();
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
        public IActionResult ThemHangHoa()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult ThemHangHoa(HangHoa h)
        {
            // Kiểm tra xem ModelState có hợp lệ không
            if (ModelState.IsValid)
            {
                // Kiểm tra validate các thuộc tính tùy chỉnh của đối tượng HangHoa
                var validationResults = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(h, new ValidationContext(h), validationResults, true);

                if (isValid)
                {
                    db.HangHoas.Add(h);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    // Nếu có lỗi validate thuộc tính, thêm lỗi vào ModelState để thông báo cho người dùng
                    foreach (var validationResult in validationResults)
                    {
                        ModelState.AddModelError(string.Empty, validationResult.ErrorMessage);
                    }
                }
            }

            // Nếu ModelState không hợp lệ, hoặc validate thuộc tính không hợp lệ, tái hiện lại View với lỗi
            ViewBag.MaLoai = new SelectList(db.LoaiHangs.ToList(), "MaLoai", "TenLoai");
            return View(h);
        }

        public JsonResult GetData(int MaLoai)
        {
            // Lấy danh sách sách theo mã nhà xuất bản
            var List = (from h in db.HangHoas
                            where h.MaLoai == MaLoai
                            select h).ToList();
            return Json(List);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
