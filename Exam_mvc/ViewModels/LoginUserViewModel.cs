using System.ComponentModel.DataAnnotations;

namespace Exam_mvc.ViewModels
{
    public class LoginUserViewModel
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
