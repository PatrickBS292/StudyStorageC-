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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = StudentRepository.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = StudentRepository.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            StudentRepository.AddStudent(student);

            return RedirectToAction("Index");

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
        if (!ModelState.IsValid)
        {
            return View(student);
        }

        if (!StudentRepository.UpdateStudent(student))
        {
            return NotFound();
        }

            return RedirectToAction(nameof(Index));
        }

        
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int studentId)
        {
            if (!StudentRepository.DeleteStudent(studentId))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
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
