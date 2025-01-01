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
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = students.Last<Student>().Id + 1;
                students.Add(s);
                return View("Index", students);
            }

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
    }
}
