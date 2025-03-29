namespace Exam_mvc.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Track
    {
        public int ID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public ICollection<Trainee>? Trainees { get; set; }
    }

}
