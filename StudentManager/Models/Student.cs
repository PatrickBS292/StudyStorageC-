using System.ComponentModel.DataAnnotations;

namespace StudentManager.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Navn er påkrævet")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Navnet skal være mellem 2 og 100 tegn")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Uddannelsen er påkrævet")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Uddannelsen skal være mellem 2 og 100 tegn")]
        public string? Education { get; set; }
        [Required(ErrorMessage = "Email er påkrævet")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Email skal være mellem 2 og 100 tegn")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Semester er påkrævet")]
        public int? Semester { get; set; }

    }
}
