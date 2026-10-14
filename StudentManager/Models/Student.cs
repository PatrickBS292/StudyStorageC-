using System.ComponentModel.DataAnnotations;

namespace StudentManager.Models
{
    public class Student
    {
        
        public string Name { get; set; }
        
        public string Education { get; set; }
       
        public string Email { get; set; }
        
        public int Semester { get; set; }

    }
}
