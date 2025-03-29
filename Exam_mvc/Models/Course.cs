using System.ComponentModel.DataAnnotations;

namespace Exam_mvc.Models
{
   

    public class Course
    {
        public int ID { get; set; }

        [Required, StringLength(100)]
        public string Topic { get; set; }

        [Range(0, 100)]
        public float Grade { get; set; }
    }

}
