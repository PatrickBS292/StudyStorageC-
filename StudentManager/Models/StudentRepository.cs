
using System.Collections.Generic;
using System.Linq;

namespace StudentManager.Models
{
    public class StudentRepository
    {
        private static List<Student> students = new List<Student>();
        private static int nextId = 1;

        public static void AddStudent(Student student)
        {
            student.StudentId = nextId++;
            students.Add(student);
        }

        public static List<Student> GetAllStudents()
        {
            return students;
        }

        public static Student? GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.StudentId == id);
        }

        public static bool UpdateStudent(Student updatedStudent)
        {
            var student = GetStudentById(updatedStudent.StudentId);

            if (student == null)
            {
                return false;
            }

            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.Education = updatedStudent.Education;
            student.Semester = updatedStudent.Semester;

            return true;
        }

        public static bool DeleteStudent(int id)
        {
            var student = GetStudentById(id);

            if (student == null)
            {
                return false;
            }

            students.Remove(student);
            return true;
        }
    }
}
