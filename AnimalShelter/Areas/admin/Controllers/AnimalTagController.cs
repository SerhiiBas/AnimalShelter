using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servises.Interfaces;

namespace AnimalShelterMVC.Areas.admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class AnimalTagController : Controller
    {
        private readonly IAnimalTagsServices _animalTagsServices;

        public AnimalTagController(IAnimalTagsServices animalTagsServices)
        {
            _animalTagsServices = animalTagsServices;
        }

        [HttpGet]
        public async Task<IActionResult> AddAnimalTag()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimalTag([FromForm] string Name, [FromRoute] int id)
        {
            await _animalTagsServices.AddAnimalTag(id, Name.ToString());

            return RedirectToAction("GetAllAnimal", "Animal");
        }


        [HttpGet]
        public async Task<IActionResult> DeleteAnimalTag()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAnimalTag([FromForm] string Name, [FromRoute] int id)
        {
            await _animalTagsServices.DeleteTag(id, Name.ToString());

            return RedirectToAction("GetAllAnimal", "Animal");
        }

    }
}
