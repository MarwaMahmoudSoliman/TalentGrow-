using Microsoft.AspNetCore.Identity;

namespace Exam_mvc.Models
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Job { get; set; }
    }
}
