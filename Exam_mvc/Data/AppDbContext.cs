using Exam_mvc.Models;
using Exam_mvc.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Exam_mvc.Data
{


    public class AppDbContext :IdentityDbContext<AppUser> 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TraineeCourse> TraineeCourses { get; set; }= default!;
        public DbSet<Exam_mvc.ViewModels.RegisterUserViewModel> RegisterUserViewModel { get; set; } = default!;
        public DbSet<Exam_mvc.ViewModels.LoginUserViewModel> LoginUserViewModel { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TraineeCourse>()
                .HasKey(tc => new { tc.TraineeID, tc.CourseID });

            base.OnModelCreating(modelBuilder);
        }
    }

}
