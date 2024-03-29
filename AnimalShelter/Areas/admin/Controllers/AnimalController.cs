﻿using AnimalShelter.Models.Animal;
using AnimalShelter.Services.Interfaces;
using Filters.CastomExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servises.Interfaces;

namespace AnimalShelterMVC.Areas.admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class AnimalController : Controller
    {
        private readonly IAnimalServices _animalsServices;
        private readonly IAnimalTagsServices _animalTagsServices;

        public AnimalController(IAnimalServices animalsServices, IAnimalTagsServices animalTagsServices)
        {
            _animalsServices = animalsServices;
            _animalTagsServices = animalTagsServices;
        }

        // ADD Animal
        [HttpGet]
        public IActionResult AddNewAnimal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAnimal([FromForm] Animal Animal, [FromForm] int[] Tags)
        {
            if (!ModelState.IsValid)
                return View("AddNewAnimal", Animal);

            List<AnimalTag> animalTags = new List<AnimalTag>();

            foreach (int tagId in Tags)
            {
                animalTags.Add(await _animalTagsServices.GetById(tagId));
            }

            var animal = await _animalsServices.Create(Animal);

            animal.Tags = animalTags;

            await _animalsServices.Update(animal);

            CheckingExceptions.CheckingAtNull(animal);

            return RedirectToAction("GetAnimalById", new { id = animal.AnimalId });
        }

        //Get Animal

        public async Task<IActionResult> GetAllAnimal()
        {
            IEnumerable<Animal> animal = await _animalsServices.GetAll();

            CheckingExceptions.CheckingAtNull(animal);

            return View(animal);
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimalById([FromRoute] int id, [FromForm] object obj)
        {
            var ob = obj;
            Animal animal = await _animalsServices.GetById(id);

            CheckingExceptions.CheckingAtNull(animal);

            return View(animal);
        }

        //Update Animal

        [HttpGet]
        public async Task<IActionResult> UpdateAnimal([FromRoute] int id)
        {
            var animal = await _animalsServices.GetById(id);

            CheckingExceptions.CheckingAtNull(animal);

            return View(animal);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAnimal([FromForm] Animal animal)
        {
            CheckingExceptions.CheckingAtNull(animal);

            if (!ModelState.IsValid)
                return View("UpdateAnimal", animal);

            CheckingExceptions.CheckingAtNull(animal);

            await _animalsServices.Update(animal);

            return RedirectToAction("GetAllAnimal");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAnimal([FromRoute] int id)
        {
            var delAnimal = await _animalsServices.DeleteByID(id);

            CheckingExceptions.CheckingAtNull(delAnimal);

            return View(delAnimal);
        }

    }
}
