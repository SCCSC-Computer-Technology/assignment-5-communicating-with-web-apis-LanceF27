using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsumeWebAPI.Models
{
    public class StudentModel
    {
        public long Id { get; set; }
        [Required]
        [DisplayName("Student ID")]
        public string? Name { get; set; }
        [Required]
        [DisplayName("Student Name")]
        public double GPA { get; set; }
        [Required]
        [DisplayName("GPA")]
        public string? StudentEmail { get; set; }
        [Required]
        [DisplayName("Student Email")]
        public string? Major { get; set; }
        [Required]
        [DisplayName("Major")]
        public string? PhoneNumber { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        public string? StudentUserName { get; set; }
        [Required]
        [DisplayName("Username")]
        public string? password { get; set; }
        [Required]
        [DisplayName("Student ID")]
        public string? hashedPassword { get; set; }
        public Boolean isVerified { get; set; }
    }
}
