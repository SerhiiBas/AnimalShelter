using AnimalShelter.Models.Animal;
using AnimalShelter.Services.Class;
using AnimalShelter.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterMVC.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalsServices _animalsServices;
        private readonly IAnimalsPhotoServices _animalsPhotoServices;

        public AnimalController(IAnimalsServices animalsServices,IAnimalsPhotoServices animalsPhotoServices)
        {
            this._animalsServices = animalsServices;
            this._animalsPhotoServices = animalsPhotoServices;
        }
        //Animal

        // ADD Animal
        [HttpGet]
        public IActionResult AddNewAnimal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAnimal([FromForm] Animal Animal)
        {
            var animal = await _animalsServices.Create(Animal);

            return RedirectToAction("GetAnimalById", new { id = animal.AnimalId });
        }

        //Get Animal

        public async Task<IActionResult> GetAllAnimal()
        {
            IEnumerable<Animal> animal = await _animalsServices.GetAll();// Не розумію чому Var не працєює а IEnumerable<Animal> працює

            return View(animal);
        }

        public async Task<IActionResult> GetAnimalById([FromRoute] int id)
        {
            Animal animal = await _animalsServices.GetById(id);

            return View(animal);
        }

        //Update Animal

        [HttpGet]
        public async Task<IActionResult> UpdateAnimal([FromRoute] int id)
        {
            var animal = await _animalsServices.GetById(id);
            return View(animal);
        }

        [HttpPost]
        public IActionResult UpdateAnimal([FromRoute]int id, [FromForm] Animal animal)
        {
            _animalsServices.Update(id,animal);

            return RedirectToAction("GetAllAnimal");
        }

        //Delete Animal

        public async Task<IActionResult> DeleteAnimal([FromRoute] int id)
        {
            var delAnimal = await _animalsServices.DeleteByID(id);

            return View(delAnimal);
        }

        // AnimalPhoto
        [HttpGet]
        public IActionResult AddPhotoAnimal([FromRoute] int id)
        {
            return View("AddPhotoAnimal", new AnimalPhoto() { Animal_Id = id });
        }
        [HttpPost]
        public IActionResult AddPhotoAnimal([FromForm] AnimalPhoto animalsPhotos)
        {
            _animalsPhotoServices.Add(animalsPhotos);

            return RedirectToAction("GetAllAnimal");
        }

        public async Task<IActionResult> DeleteAnimalPhoto([FromRoute] int id)
        {
            var animalPhoto = await _animalsPhotoServices.Delete(id);

            return View(animalPhoto);
        }
    }
}
