using System.ComponentModel.DataAnnotations;

namespace Exam_mvc.ViewModels
{
    public class RegisterUserViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Job { get; set; }
    }
}
