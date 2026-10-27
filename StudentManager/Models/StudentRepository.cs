using Microsoft.EntityFrameworkCore;
using StudentManager.Data;

namespace StudentManager.Models {
    public class StudentRepository : IStudentRepository {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context) {
            _context = context;
        }

        public void AddStudent(Student student) {
            _context.Student.Add(student);
            _context.SaveChanges();
        }

        public List<Student> GetAllStudents() {
            return _context.Student.AsNoTracking().ToList();
        }

        public Student? GetStudentById(int id) {
            return _context.Student.AsNoTracking().FirstOrDefault(s => s.StudentId == id);
        }

        public bool UpdateStudent(Student updatedStudent) {
            var student = _context.Student.Find(updatedStudent.StudentId);

            if (student == null) {
                return false;
            }

            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.Education = updatedStudent.Education;
            student.Semester = updatedStudent.Semester;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteStudent(int id) {
            var student = _context.Student.Find(id);

            if (student == null) {
                return false;
            }

            _context.Student.Remove(student);
            _context.SaveChanges();
            return true;
        }
    }
}