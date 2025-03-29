using Exam_mvc.Repositories;
using Exam_mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exam_mvc.Data;
using Exam_mvc.Models;

namespace YourNamespace.Controllers
{
    public class TraineeCourseController : Controller
    {
        private readonly ITraineeCourseRepository _repo;
        private readonly ITraineeRepository _Trepo;

        public TraineeCourseController(ITraineeCourseRepository repo , ITraineeRepository Trepo)
        {
            _repo = repo;
            _Trepo = Trepo;
        }

        // عرض جميع البيانات
        public IActionResult Index()
        {
            var traineeCourses = _repo.GetAll();
            return View(traineeCourses);
        }



        public IActionResult Create()
        {
            ViewData["Trainees"] = new SelectList(_repo.GetTrainees(), "ID", "Name");
            ViewData["Courses"] = new MultiSelectList(_repo.GetCourses(), "ID", "Topic");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int traineeId, List<int> courseIds)
        {
            if (courseIds == null || courseIds.Count == 0)
            {
                ModelState.AddModelError("", "يجب اختيار دورة واحدة على الأقل.");
                return View();
            }

            foreach (var courseId in courseIds)
            {
                var traineeCourse = new TraineeCourse
                {
                    TraineeID = traineeId,
                    CourseID = courseId
                };
                _repo.Add(traineeCourse);
            }

            return RedirectToAction(nameof(Index));
        }

       
        public IActionResult Edit(int traineeId)
        {
            var traineeCourses = _repo.GetByTraineeId(traineeId); // ✅ Now returns a list
            if (traineeCourses == null || !traineeCourses.Any()) return NotFound(); // ✅ Now `.Any()` works!

            var selectedCourses = traineeCourses.Select(tc => tc.CourseID).ToList();

            var courses = _repo.GetCourses().Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Topic,
                Selected = selectedCourses.Contains(c.ID)
            }).ToList();

            ViewData["Trainee"] = traineeCourses.FirstOrDefault()?.Trainee; // ✅ Now safe to use `FirstOrDefault()`
            ViewData["Courses"] = courses;
           
        
            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int traineeId, List<int> courseIds)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(traineeId, courseIds); // ✅ Save changes
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        [HttpPost]
        public IActionResult DeleteCourse(int traineeId, int courseId)
        {
            _repo.Delete(traineeId, courseId);

       
            return RedirectToAction("index");
        }
     
            public IActionResult Details(int traineeId)
        {
           
            var trainee = _Trepo.GetDetails(traineeId);
                if (trainee == null)
                {
                    return NotFound();
                }
            var traineeCourses = _repo.GetByTraineeId(traineeId);
            Console.WriteLine($"Courses Count: {traineeCourses.Count()}");

            ViewData["courses Count"] = traineeCourses.Count();


                ViewData["Trainee"] = trainee;
                ViewData["TraineeCourses"] = traineeCourses;

                return View();
            }
        }


   }