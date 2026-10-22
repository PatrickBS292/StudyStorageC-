namespace StudentManager.Models
    {
    public interface IStudentRepository 
    {
        void AddStudent(Student student);

        List<Student> GetAllStudents();

        Student? GetStudentById(int id);

        bool UpdateStudent(Student updatedStudent);

        bool DeleteStudent(int id);
    }
}