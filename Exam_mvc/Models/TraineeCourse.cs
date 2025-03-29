namespace Exam_mvc.Models
{

    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Exam_mvc.Models;

        public class TraineeCourse
        {
            [ForeignKey("Trainee")]
            public int TraineeID { get; set; }
            public Trainee? Trainee { get; set; }

            [ForeignKey("Course")]
            public int CourseID { get; set; }
            public Course? Course { get; set; }

            [Range(0, 100)]
            public float Grade { get; set; }

        }

    }

