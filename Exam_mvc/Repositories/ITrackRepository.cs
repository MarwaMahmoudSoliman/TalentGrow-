using Exam_mvc.Models;

namespace Exam_mvc.Repositories
{
    public interface ITrackRepository
    {
        List<Track> GetAll();
        Track GetDetails(int id);
        void Insert(Track track);
        void UpdateTrack(Track track);
        void DeleteTrack(int id);
    }
}
