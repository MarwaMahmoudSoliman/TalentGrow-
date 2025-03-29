using Exam_mvc.Models;

using Exam_mvc.Data;
using Microsoft.EntityFrameworkCore;

namespace Exam_mvc.Repositories
{
    public class TraineeCourseRepoService : ITraineeCourseRepository
    {
        private readonly AppDbContext _context;

        public TraineeCourseRepoService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TraineeCourse> GetAll()
        {
            return _context.TraineeCourses
                .Include(tc => tc.Trainee)
                .Include(tc => tc.Course)
                .ToList();
        }
        public IEnumerable<TraineeCourse> GetByTraineeId(int traineeId)
        {
            return _context.TraineeCourses
                .Include(tc => tc.Trainee)
                .Include(tc => tc.Course)
                .Where(tc => tc.TraineeID == traineeId)
                .ToList();
        }


        public Models.TraineeCourse GetById(int traineeId, int courseId)
        {
            return _context.TraineeCourses
                .Include(tc => tc.Trainee)
                .Include(tc => tc.Course)
                .FirstOrDefault(tc => tc.TraineeID == traineeId && tc.CourseID == courseId);
        }

        public IEnumerable<Trainee> GetTrainees()
        {
            return _context.Trainees.ToList();
        }

        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public void Add(TraineeCourse traineeCourse)
        {
            _context.TraineeCourses.Add(traineeCourse);
            _context.SaveChanges();
        }

        public void Update(TraineeCourse traineeCourse)
        {
            _context.TraineeCourses.Update(traineeCourse);
            _context.SaveChanges();
        }

        //public void Delete(int traineeId, int courseId)
        //{
        //    var traineeCourse = GetById(traineeId, courseId);
        //    if (traineeCourse != null)
        //    {
        //        _context.TraineeCourses.Remove(traineeCourse);
        //        _context.SaveChanges();
        //    }
        //}
        public void Delete(int traineeId, int courseId)
        {
            var traineeCourse = _context.TraineeCourses
                .FirstOrDefault(tc => tc.TraineeID == traineeId && tc.CourseID == courseId);

            if (traineeCourse != null)
            {
                _context.TraineeCourses.Remove(traineeCourse); // ✅ Remove course
                _context.SaveChanges(); // ✅ Save changes
            }
        }


        public void Update(int traineeId, List<int> courseIds)
        {
            var existingCourses = _context.TraineeCourses.Where(tc => tc.TraineeID == traineeId).ToList();
            _context.TraineeCourses.RemoveRange(existingCourses);

            var newCourses = courseIds.Select(courseId => new TraineeCourse { TraineeID = traineeId, CourseID = courseId });
            _context.TraineeCourses.AddRange(newCourses);

            _context.SaveChanges();
        }

    }
}
