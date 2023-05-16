using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;
using AnimalShelter.Models.Volunteer;
using AnimalShelter.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using AnimalShelter.Services.Class;
using Filters.CastomExceptions;

namespace AnimalShelter.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly IVolunteerServices _volunteersServices;

        public VolunteerController(IVolunteerServices volunteersServices)
        {
            this._volunteersServices = volunteersServices;
        }

        [HttpGet]
        public IActionResult AddNewVolunteer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewVolunteer([FromForm] Volunteer volunteer)
        {
            if (!ModelState.IsValid)
                return View("AddNewVolunteer", volunteer);

            var newVol = await _volunteersServices.Create(volunteer);

            CheckingExceptions.CheckingAtNull(newVol);

            return RedirectToAction("GetVolunteerById", new { id = newVol.VolunteerId });
        }

        public async Task<IActionResult> GetAllVolunteer()
        {
            IEnumerable<Volunteer> volunteer = await _volunteersServices.GetAll();

            return View(volunteer);
        }

        public async Task<IActionResult> GetVolunteerById([FromRoute] int id)
        {
            Volunteer volunteer = await _volunteersServices.GetById(id);

            CheckingExceptions.CheckingAtNull(volunteer);

            return View(volunteer);
        }

        public async Task<IActionResult> DeleteVolunteer([FromRoute] int id)
        {
            var delVolunteer = await _volunteersServices.DeleteByID(id);

            CheckingExceptions.CheckingAtNull(delVolunteer);

            return View(delVolunteer);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateVolunteer([FromRoute] int id)
        {
            var volunteer = await _volunteersServices.GetById(id);

            CheckingExceptions.CheckingAtNull(volunteer);

            return View(volunteer);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVolunteer([FromForm] Volunteer volunteer)
        {
            if (!ModelState.IsValid)
                return View("UpdateVolunteer", volunteer);

            await _volunteersServices.Update(volunteer);

            return RedirectToAction("GetAllVolunteer");
        }
    }
}
