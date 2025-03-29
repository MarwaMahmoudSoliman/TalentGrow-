using Exam_mvc.Models;


namespace Exam_mvc.Repositories
{
    public interface ITraineeCourseRepository
    {
        IEnumerable<TraineeCourse> GetAll();
        public TraineeCourse GetById(int traineeId, int courseId);
        //public TraineeCourse GetById(int traineeId);
        public IEnumerable<TraineeCourse> GetByTraineeId(int traineeId);
        IEnumerable<Trainee> GetTrainees();
        IEnumerable<Course> GetCourses();
        void Add(TraineeCourse traineeCourse);
        void Update(int traineeId, List<int> courseIds);

        void Delete(int traineeId, int courseId);
    }

}
