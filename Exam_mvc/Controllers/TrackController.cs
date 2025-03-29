using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Exam_mvc.Models;
using Exam_mvc.Repositories;

namespace Exam_mvc.Controllers
{

    public class TrackController : Controller
    {
        private readonly ITrackRepository _trackRepository;

        public TrackController(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

     
     
        public IActionResult Index()
        {
            List<Track> tracks = _trackRepository.GetAll();
            return View(tracks);
        }
      



        
        public IActionResult Details(int id)
        {
            Track track = _trackRepository.GetDetails(id);
            if (track == null) return NotFound();
            return View(track);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Track track)
        {
            if (ModelState.IsValid)
            {
                _trackRepository.Insert(track);
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

      
       
        public IActionResult Edit(int id)
        {
            Track track = _trackRepository.GetDetails(id);
            if (track == null) return NotFound();
            return View(track);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Track track)
        {
            if (ModelState.IsValid)
            {
                _trackRepository.UpdateTrack(track);
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var track = _trackRepository.GetDetails(id);
            if (track == null) return NotFound();

            return View(track);
        }
    
        [HttpPost()]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var track = _trackRepository.GetDetails(id);
            if (track == null) return NotFound();

            _trackRepository.DeleteTrack(id);
            return RedirectToAction(nameof(Index));
        }

    }
       }

