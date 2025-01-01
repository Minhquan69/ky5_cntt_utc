using ltweb20_8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ltweb20_8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var user = new User();
            user.name = "hai dao minh";
            user.address = "dai hoc gtvt";
            user.email = "h@gmail.com";


            ViewBag.user = user;

            return View();
        }
        [HttpGet]
        public ActionResult Login() { return View(); }

      
        [HttpPost]
        public ActionResult Login(string userName,
        string password)
        {
            if (userName == "1" && password ==
            "1")
            {
                string msg = "Welcome " + userName;
                return Content(msg);
            }
            else { return View(); }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
