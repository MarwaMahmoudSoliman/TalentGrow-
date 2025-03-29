using Exam_mvc.Data;
using Exam_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam_mvc.Repositories
{
    
        public class TraineeRepoService : ITraineeRepository
        {
            private readonly AppDbContext _context;

            public TraineeRepoService(AppDbContext context)
            {
                _context = context;
            }

            public List<Trainee> GetAll()
            {
                return _context.Trainees.Include(t => t.Trk).ToList();
            }

            public Trainee GetDetails(int id)
            {
                return _context.Trainees.Include(t => t.Trk).FirstOrDefault(t => t.ID == id);
            }

            public void Insert(Trainee trainee)
            {
                if (trainee != null)
                {
                    _context.Trainees.Add(trainee);
                    _context.SaveChanges();
                }
            }

            public void UpdateTrainee(Trainee trainee)
            {
                var traineeUpdated = _context.Trainees.Find(trainee.ID);
                if (traineeUpdated != null)
                {
                    traineeUpdated.Name = trainee.Name;
                    traineeUpdated.Gender = trainee.Gender;
                    traineeUpdated.Email = trainee.Email;
                    traineeUpdated.MobileNo = trainee.MobileNo;
                    traineeUpdated.Birthdate = trainee.Birthdate;
                    traineeUpdated.TrackID = trainee.TrackID;

                    _context.SaveChanges();
                }
            }

            public void DeleteTrainee(int id)
            {
                var trainee = _context.Trainees.Find(id);
                if (trainee != null)
                {
                    _context.Trainees.Remove(trainee);
                    _context.SaveChanges();
                }
            }
        }
    }