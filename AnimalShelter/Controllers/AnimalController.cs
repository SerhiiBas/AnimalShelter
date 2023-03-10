using AnimalShelter.Context;
using AnimalShelter.Models.Animal;
using AnimalShelter.Services.Class;
using AnimalShelter.Services.Interfaces;
using Data.Interfaces;
using Filters.CastomExceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Servises.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelterMVC.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalServices _animalsServices;
        private readonly IAnimalPhotoServices _animalsPhotoServices;
        private readonly IAnimalTagsServices _animalTagsServices;

        public AnimalController(IAnimalServices animalsServices, IAnimalPhotoServices animalsPhotoServices, IAnimalTagsServices animalTagsServices)
        {
            this._animalsServices = animalsServices;
            this._animalsPhotoServices = animalsPhotoServices;
            this._animalTagsServices = animalTagsServices;
        }
        //Animal

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
                return View("AddNewAnimal", Animal);// якщо невалідні поля заново повертає форму з винятками

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

        public async Task<IActionResult> GetAnimalById([FromRoute] int id)
        {
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

        //todo зробити щоб не додавало статусів яких немає
        [HttpPost]
        public async Task<IActionResult> UpdateAnimal([FromForm] Animal animal, [FromForm] int[] Tags)
        {
            CheckingExceptions.CheckingAtNull(animal);

            if (!ModelState.IsValid)
                return View("UpdateAnimal", animal);

            CheckingExceptions.CheckingAtNull(animal);
           
            await _animalsServices.Update(animal);

            return RedirectToAction("GetAllAnimal");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAnimalTag()
        {
            return View();
        }

        [HttpPost]
        //todo зробити адекватне видалення з форми не береться значення
        public async Task<IActionResult> DeleteAnimalTag([FromForm] string Name, [FromRoute] int id)
        {
            await _animalsServices.DeleteTag(id, Name.ToString());

            return RedirectToAction("GetAllAnimal");
        }

        //Delete Animal
        public async Task<IActionResult> DeleteAnimal([FromRoute] int id)
        {
            var delAnimal = await _animalsServices.DeleteByID(id);

            CheckingExceptions.CheckingAtNull(delAnimal);

            return View(delAnimal);
        }

        // AnimalPhotos

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

            return RedirectToAction("GetAllAnimal");
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

            return RedirectToAction("GetAllAnimalPhotos");
        }
    }
}
