namespace Exam_mvc.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    
   
    using Exam_mvc.Models;
    using Exam_mvc.Repositories;
    using Microsoft.AspNetCore.Mvc.Rendering;

    namespace Day8Demo_SD45.Controllers
    {
       
        public class TraineeController : Controller
        {
            private readonly ITraineeRepository _traineeRepository;
            private readonly ITrackRepository _trackRepository;


            public TraineeController(ITraineeRepository traineeRepository, ITrackRepository trackRepository)
            {
                _traineeRepository = traineeRepository;
                _trackRepository = trackRepository;
            }


            public IActionResult Index()
            {
                List<Trainee> trainees = _traineeRepository.GetAll();
                return View(trainees);
            }

            public IActionResult Details(int id)
            {
                Trainee trainee = _traineeRepository.GetDetails(id);
                if (trainee == null) return NotFound();
                return View(trainee);
            }
            // GET: Create Trainee Form
            public IActionResult Create()
            {
                ViewBag.Tracks = new SelectList(_trackRepository.GetAll(), "ID", "Name");
                return View();
            }

            // POST: Handle Form Submission
            [HttpPost]
            [ValidateAntiForgeryToken] // Prevent CSRF attacks
            public IActionResult Create(Trainee trainee)
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Tracks = new SelectList(_trackRepository.GetAll(), "ID", "Name");
                    return View(trainee);
                }

                trainee.Trk = _trackRepository.GetDetails(trainee.TrackID.Value);
                _traineeRepository.Insert(trainee);

                return RedirectToAction(nameof(Index));
            }


            public IActionResult Edit(int id)
            {
                ViewBag.tracks = new SelectList(_trackRepository.GetAll(), "ID", "Name");

                Trainee trainee = _traineeRepository.GetDetails(id);
                if (trainee == null) return NotFound();
                return View(trainee);
            }

            [HttpPost]
            public IActionResult Edit(Trainee trainee)
            {
                ViewBag.tracks = new SelectList(_trackRepository.GetAll(), "ID", "Name", trainee.TrackID);

                if (ModelState.IsValid)
                {
                    _traineeRepository.UpdateTrainee(trainee);
                    return RedirectToAction(nameof(Index));
                }
                return View(trainee);
            }

            public IActionResult Delete(int id)
            {
                Trainee trainee = _traineeRepository.GetDetails(id);
                if (trainee == null) return NotFound();
                return View(trainee);
            }

          
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(int id, IFormCollection collection)
            {
                try
                {
                    _traineeRepository.DeleteTrainee(id);
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
