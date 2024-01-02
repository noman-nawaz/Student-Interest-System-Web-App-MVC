using System.ComponentModel.DataAnnotations;

namespace Student_Interest_System_Mvc.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        [MaxLength(100, ErrorMessage = "Full Name cannot exceed 100 characters")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Roll Number is required")]
        [MaxLength(20, ErrorMessage = "Roll Number cannot exceed 20 characters")]
        public string? RollNumber { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? EmailAddress { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Interest is required")]
        public string? Interest { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string? Department { get; set; }

        [Required(ErrorMessage = "Degree Title is required")]
        public string? DegreeTitle { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }




    }
}
