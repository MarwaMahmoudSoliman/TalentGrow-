using Exam_mvc.Models;
using Exam_mvc.Controllers;
using Exam_mvc.Data;
using Exam_mvc.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using YourNamespace.Controllers;

namespace Exam_mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(conf =>
                conf.Filters.Add(new AuthorizeFilter())); // Global Authorization

            // Configure Database Context
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            // Register Repositories
            builder.Services.AddScoped<ITraineeRepository, TraineeRepoService>();
            builder.Services.AddScoped<ITrackRepository, TrackRepoService>();
            builder.Services.AddScoped<ICourseRepository, CourseRepoService>();
            builder.Services.AddScoped<ITraineeCourseRepository, TraineeCourseRepoService>();

            // Register Controllers
            builder.Services.AddScoped<TraineeCourseController>();

            // Configure Identity
            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders(); // Provides Token Support for Authentication

            // Configure Authentication with Facebook (Using Configuration)
            builder.Services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = builder.Configuration["Facebook:AppId"];
                options.AppSecret = builder.Configuration["Facebook:AppSecret"];
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();  // Serve static files (CSS, JS, images, etc.)

            app.UseRouting();       // Enables routing

            app.UseAuthentication(); // Enables authentication (should come before authorization)
            app.UseAuthorization();  // Enables authorization

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(); // Start the application

        }
    }
}
