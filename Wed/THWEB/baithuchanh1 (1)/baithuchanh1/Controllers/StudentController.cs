using baithuchanh1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace baithuchanh1.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> students = new List<Student>();

        public StudentController()
        {
            students = new List<Student>()
            {
                new Student(){ Id = 1, Name = "Hai Nam", Branch = Branch.IT , Gender = Gender.male , Email = "nam@gmail.com", Address = "A1-2018", IsRegular = true, Diem = 8.5 },
                new Student(){ Id = 2, Name = "Minh Tu", Branch = Branch.BE , Gender = Gender.female , Email = "minhtu@gmail.com", Address = "A1-2019", IsRegular = true, Diem = 7.0 },
                new Student(){ Id = 3, Name = "Bui Giang", Branch = Branch.EE , Gender = Gender.male , Email = "giang@gmail.com", Address = "A1-2020", IsRegular = false, Diem = 9.0 },
                new Student(){ Id = 4, Name = "Thu Hang", Branch = Branch.CE , Gender = Gender.female , Email = "thuhang@gmail.com", Address = "A1-2021", IsRegular = false, Diem = 8.0 }
            };
        }

        public IActionResult Index()
        {
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student, IFormFile? avatarFile)
        {
            if (avatarFile != null && avatarFile.Length > 0)
            {
                // Lấy tên tệp và xác định đường dẫn lưu
                var fileName = Path.GetFileName(avatarFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                // Lưu tệp vào thư mục wwwroot/images
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    avatarFile.CopyTo(stream);
                }

                // Gán đường dẫn cho avatar của student
                student.Avatar = "/images/" + fileName;
            }
            else
            {
                // Nếu không tải lên tệp, dùng ảnh mặc định
                student.Avatar = "/images/default.png";
            }

            ModelState.Remove("avatarFile");

            if (!ModelState.IsValid)
            {
                ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
                ViewBag.AllBranches = new List<SelectListItem>()
        {
            new SelectListItem { Text = "IT", Value = "1" },
            new SelectListItem { Text = "BE", Value = "2" },
            new SelectListItem { Text = "CE", Value = "3" },
            new SelectListItem { Text = "EE", Value = "4" }
        };
                return View(student);
            }
            student.Id = students.Last().Id + 1;
            students.Add(student);

            return View("Index", students);
        }


    }
}
