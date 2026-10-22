using Microsoft.AspNetCore.Mvc;
using StudentManager.Models;

namespace StudentManager.Controllers {
    public class HomeController : Controller {
        private readonly IStudentRepository _repository;

        public HomeController(IStudentRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult CreateStudent() {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            var student = _repository.GetStudentById(id);

            if (student == null) {
                return NotFound();
            }

            return View(student);
        }

        public IActionResult Delete(int id) {
            var student = _repository.GetStudentById(id);

            if (student == null) {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student) {
            if (!ModelState.IsValid) {
                return View(student);
            }

            _repository.AddStudent(student);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student) {
            if (!ModelState.IsValid) {
                return View(student);
            }

            if (!_repository.UpdateStudent(student)) {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int studentId) {
            if (!_repository.DeleteStudent(studentId)) {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ListStudents() {
            var students = _repository.GetAllStudents();
            return View(students);
        }

        public IActionResult Index() {
            var students = _repository.GetAllStudents();
            return View(students);
        }
    }
}