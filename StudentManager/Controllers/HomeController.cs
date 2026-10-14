using Microsoft.AspNetCore.Mvc;
using StudentManager.Models;


namespace StudentManager.Controllers
{
    public class HomeController: Controller
    {
        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            StudentRepository.AddStudent(student);
            return View("StudentCreated", student);
        }

        public IActionResult ListStudents()
        {
            var students = StudentRepository.GetAllStudents();
            return View(students);
        }

        public IActionResult Index()
        {
            var students = StudentRepository.GetAllStudents();
            return View(students);
        }

    }
}
