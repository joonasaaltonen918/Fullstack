using EventPlan1.Models.Domain;
using EventPlan1.Repositories.Abstract;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlan1.Controllers
{
   //[Authorize("Admin")]
    public class eventController : Controller
    {
        private readonly IEventService _eventService;
        public eventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [Authorize(Policy = "AdminAccess")]
        public IActionResult Add()
        {
            return View();
        }
        //[Authorize("Admin")]
        [Authorize(Policy = "AdminAccess")]
        [HttpPost]
        public IActionResult Add(Event model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _eventService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on the server side";
                return View(model);
            }
        }
        //[Authorize("Admin")]
        [Authorize(Policy = "AdminAccess")]
        public IActionResult Edit(int id)
        {
            var data = _eventService.GetById(id);
            return View(data);
        }


        [Authorize(Policy = "AdminAccess")]
        [HttpPost]
        public IActionResult Update(Event model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _eventService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(EventList));
            }
            else
            {
                TempData["msg"] = "Error on the server side";
                return View(model);
            }
        }

        
        public IActionResult EventList()
        {
            var data = this._eventService.List().ToList();
            return View(data);
        }

        //[Authorize("Admin")]
        [Authorize(Policy = "AdminAccess")]
        public IActionResult Delete(int id)
        {
            var result = _eventService.Delete(id);
            return RedirectToAction(nameof(EventList));
        }



    }
}