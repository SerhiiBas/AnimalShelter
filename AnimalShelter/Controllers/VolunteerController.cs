using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;
using AnimalShelter.Models.Volunteer;
using AnimalShelter.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using AnimalShelter.Services.Class;

namespace AnimalShelter.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly IVolunteersServices _volunteersServices;

        public VolunteerController(IVolunteersServices volunteersServices)
        {
            this._volunteersServices = volunteersServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNewVolunteer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewVolunteer([FromForm] Volunteer volunteer)
        {
            var newVol = await _volunteersServices.Create(volunteer);

            return RedirectToAction("GetVolunteerById", new { id = newVol.VolunteerId });// Чому так запрацювало? як не створювати анонімний обєкт непрокидає в роут id
        }

        public async Task<IActionResult> GetAllVolunteer()
        {
            IEnumerable<Volunteer> volunteer = await _volunteersServices.GetAll();

            return View(volunteer);
        }

        public async Task<IActionResult> GetVolunteerById([FromRoute] int id)
        {
            Volunteer volunteer = await _volunteersServices.GetById(id);

            return View(volunteer);
        }

        public async Task<IActionResult> DeleteVolunteer([FromRoute] int id)
        {
            var delVolunteer = await _volunteersServices.DeleteByID(id);

            return View(delVolunteer);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateVolunteer([FromRoute] int id)
        {
            var volunteer = await _volunteersServices.GetById(id);
            return View(volunteer);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVolunteer([FromRoute] int id, [FromForm] JsonPatchDocument<Volunteer> jsonPatch)
        {
            await _volunteersServices.Update(id, jsonPatch);

            return RedirectToAction("GetAllVolunteer");
        }
    }
}
