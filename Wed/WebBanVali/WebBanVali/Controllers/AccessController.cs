using Microsoft.AspNetCore.Mvc;
using WebBanVali.Models;

namespace WebBanVali.Controllers
{
    public class AccessController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [HttpGet]
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Login(TUser user) 
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u = db.TUsers.Where(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirstOrDefault();
                if(u!= null)
                {
                    HttpContext.Session.SetString("Username", u.Username.ToString());
                    if(u.LoaiUser == 1)
                    {
                        return RedirectToAction("Index", "HomeAdmin", new { Area = "Admin" });
                    }
                    else return RedirectToAction("Index", "Home");

                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
       
        public ActionResult Register(TUser _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.TUsers.FirstOrDefault(s => s.Username == _user.Username);
                if (check == null)
                {

                    _user.LoaiUser = 0;  // hoặc giá trị mặc định bạn mong muốn

                    
                    db.TUsers.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Login","Access");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login", "Access");
        }
    }
}
