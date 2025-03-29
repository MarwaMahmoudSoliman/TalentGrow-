using Exam_mvc.Data;
using Exam_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam_mvc.Repositories
{
    public class TrackRepoService : ITrackRepository
    {
        private readonly AppDbContext _context;

        public TrackRepoService(AppDbContext context)
        {
            _context = context;
        }

        public List<Track> GetAll()
        {
            return _context.Tracks.Include(t => t.Trainees).ToList();
        }

        public Track GetDetails(int id)
        {
            return _context.Tracks.Include(t => t.Trainees).FirstOrDefault(t => t.ID == id);
        }

        public void Insert(Track track)
        {
            if (track != null)
            {
                _context.Tracks.Add(track);
                _context.SaveChanges();
            }
        }

        public void UpdateTrack(Track track)
        {
            var trackUpdated = _context.Tracks.Find(track.ID);
            if (trackUpdated != null)
            {
                trackUpdated.Name = track.Name;
                trackUpdated.Description = track.Description;
                _context.SaveChanges();
            }
        }

        public void DeleteTrack(int id)
        {
            var track = _context.Tracks.Find(id);
            if (track != null)
            {
                _context.Tracks.Remove(track);
                _context.SaveChanges();
            }
        }
    }
}