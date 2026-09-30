namespace StudentManager.Models
{
    public class StudentRepository
    {
        private static List<Student> students = new List<Student>();
    
        public static void AddStudent(Student student)
        {
            students.Add(student);
        }

        public static List<Student> GetAllStudents()
        {
            return students;
        }
    }
}
