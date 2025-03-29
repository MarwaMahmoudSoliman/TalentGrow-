using System.Collections.Generic;

using Exam_mvc.Models;
namespace Exam_mvc.Repositories
{


        public interface ICourseRepository
        {
            List<Course> GetAll();
            Course GetDetails(int id);
            void Insert(Course course);
            void UpdateCourse(Course course);
            void DeleteCourse(int id);
        }
    }
