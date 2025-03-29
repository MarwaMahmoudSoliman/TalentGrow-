using Exam_mvc.Models;

namespace Exam_mvc.Repositories
{
    public interface ITraineeRepository
    {
        List<Trainee> GetAll();
        Trainee GetDetails(int id);
        void Insert(Trainee trainee);
        void UpdateTrainee(Trainee trainee);
        void DeleteTrainee(int id);
    }
}
