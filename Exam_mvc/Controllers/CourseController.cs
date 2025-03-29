using Microsoft.AspNetCore.Mvc;
using Exam_mvc.Models;
using Exam_mvc.Repositories;


namespace Exam_mvc.Controllers
{


    namespace Day8Demo_SD45.Controllers
    {
        public class CourseController : Controller
        {
            private readonly ICourseRepository _courseRepository;

            public CourseController(ICourseRepository courseRepository)
            {
                _courseRepository = courseRepository;
            }

            public IActionResult Index()
            {
                List<Course> courses = _courseRepository.GetAll();
                return View(courses);
            }

            public IActionResult Details(int id)
            {
                Course course = _courseRepository.GetDetails(id);
                if (course == null) return NotFound();
                return View(course);
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(Course course)
            {
                if (ModelState.IsValid)
                {
                    _courseRepository.Insert(course);
                    return RedirectToAction(nameof(Index));
                }
                return View(course);
            }

            public IActionResult Edit(int id)
            {
                Course course = _courseRepository.GetDetails(id);
                if (course == null) return NotFound();
                return View(course);
            }

            [HttpPost]
            public IActionResult Edit(Course course)
            {
                if (ModelState.IsValid)
                {
                    _courseRepository.UpdateCourse(course);
                    return RedirectToAction(nameof(Index));
                }
                return View(course);
            }
            public IActionResult Delete(int id)
            {
                Course course = _courseRepository.GetDetails(id);
                if (course == null) return NotFound();
                return View(course);
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(int id, IFormCollection collection)
            {
                try
                {
                    _courseRepository.DeleteCourse(id);
                    return RedirectToAction(nameof(Index));

                }
                catch
                {
                    return View();
                }
            }
      
         
        }
    }

}