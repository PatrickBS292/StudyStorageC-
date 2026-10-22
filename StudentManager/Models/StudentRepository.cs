using System.Collections.Generic;
using System.Linq;

namespace StudentManager.Models {
    public class StudentRepository : IStudentRepository {
        private readonly List<Student> students = new List<Student>();
        private int nextId = 1;

        public void AddStudent(Student student) {
            student.StudentId = nextId++;
            students.Add(student);
        }

        public List<Student> GetAllStudents() {
            return students;
        }

        public Student? GetStudentById(int id) {
            return students.FirstOrDefault(s => s.StudentId == id);
        }

        public bool UpdateStudent(Student updatedStudent) {
            var student = GetStudentById(updatedStudent.StudentId);

            if (student == null) {
                return false;
            }

            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.Education = updatedStudent.Education;
            student.Semester = updatedStudent.Semester;

            return true;
        }

        public bool DeleteStudent(int id) {
            var student = GetStudentById(id);

            if (student == null) {
                return false;
            }

            students.Remove(student);
            return true;
        }
    }
}