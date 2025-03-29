using Exam_mvc.Data;
using Exam_mvc.Models;
using Exam_mvc.Repositories;

namespace Exam_mvc.Repositories
{
        public class CourseRepoService : ICourseRepository
        {
            private readonly AppDbContext _context;

            public CourseRepoService(AppDbContext context)
            {
                _context = context;
            }

            public List<Course> GetAll()
            {
                return _context.Courses.ToList();
            }

            public Course GetDetails(int id)
            {
                return _context.Courses.Find(id);
            }

            public void Insert(Course course)
            {
                if (course != null)
                {
                    _context.Courses.Add(course);
                    _context.SaveChanges();
                }
            }

            public void UpdateCourse(Course course)
            {
                var courseUpdated = _context.Courses.Find(course.ID);
                if (courseUpdated != null)
                {
                    courseUpdated.Topic = course.Topic;
                    courseUpdated.Grade = course.Grade;
                    _context.SaveChanges();
                }
            }

            public void DeleteCourse(int id)
            {
                var course = _context.Courses.Find(id);
                if (course != null)
                {
                    _context.Courses.Remove(course);
                    _context.SaveChanges();
                }
            }
        }
    }

