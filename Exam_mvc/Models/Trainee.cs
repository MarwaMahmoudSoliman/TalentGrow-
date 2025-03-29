using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Exam_mvc.Models
{
    public enum Gender { Male, Female }

    public class Trainee
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a gender.")]
        public Gender? Gender { get; set; } 

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [StringLength(15, ErrorMessage = "Mobile number cannot exceed 15 characters.")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Birthdate is required.")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Please select a track.")]
        [ForeignKey("Trk")]
        public int? TrackID { get; set; }  

        [BindNever]
        public Track? Trk { get; set; }
    }
}
