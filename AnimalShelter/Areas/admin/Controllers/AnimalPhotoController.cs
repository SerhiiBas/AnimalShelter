using AnimalShelter.Models.Animal;
using AnimalShelter.Services.Interfaces;
using Filters.CastomExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterMVC.Areas.admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class AnimalPhotoController : Controller
    {
        private readonly IAnimalPhotoServices _animalsPhotoServices;

        public AnimalPhotoController(IAnimalPhotoServices animalPhotoServices)
        {
            _animalsPhotoServices = animalPhotoServices;
        }

        public async Task<IActionResult> GetAllAnimalPhotos()
        {
            IEnumerable<AnimalPhoto> animalPhoto = await _animalsPhotoServices.GetAll();

            CheckingExceptions.CheckingAtNull(animalPhoto);

            return View(animalPhoto);
        }

        [HttpGet]
        public IActionResult AddPhotoAnimal([FromRoute] int id)
        {
            return View("AddPhotoAnimal", new AnimalPhoto() { AnimalId = id });
        }
        [HttpPost]
        public IActionResult AddPhotoAnimal([FromForm] AnimalPhoto animalsPhotos)
        {
            _animalsPhotoServices.Add(animalsPhotos);

            return RedirectToAction("GetAllAnimal", "Animal");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAnimalPhoto([FromRoute] int id)
        {
            var animal = await _animalsPhotoServices.GetByID(id);

            return View(animal);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAnimalPhoto([FromForm] AnimalPhoto AnimalPhoto, [FromRoute] int id)
        {
            var animalPhoto = await _animalsPhotoServices.Delete(id);

            CheckingExceptions.CheckingAtNull(animalPhoto);

            return RedirectToAction("GetAllAnimalPhotos", "Animal");
        }
    }
}
