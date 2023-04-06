using AnimalShelter.CastomExceptions.Animal;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Models.Animal;
using AnimalShelter.Services.Interfaces;
using Data.Interfaces;
using Filters.CastomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Services.Class
{
    public class AnimalsServices : IAnimalServices
    {
        private readonly IAnimalsRepo _animalsRepo;
        private readonly IAnimalTagRepo _animalTagRepo;


        public AnimalsServices(IAnimalsRepo animalsRepo, IAnimalTagRepo animalTagRepo)
        {
            this._animalsRepo = animalsRepo;
            this._animalTagRepo = animalTagRepo;
        }

        public async Task<Animal> Create(Animal animal)
        {
            if (animal.Name == null|| animal.Age!<0)
                throw new AnimalIsnotValidExceptoin();

            return await _animalsRepo.Create(animal);
        }

        public async Task<Animal> DeleteByID(int id)
        {
            var delAnimal = await _animalsRepo.GetById(id);

            if (delAnimal == null)
                throw new AnimalIsNotFoundException();

            await _animalsRepo.Delete(delAnimal);

            return delAnimal;
        }

        public async Task DeleteTag(int animalId, string nameTag)
        {
            var animal = await _animalsRepo.GetById(animalId);

            CheckingExceptions.CheckingAtNull(animal);

            CheckingExceptions.CheckingAtNull(nameTag);

            var tagToDelete = animal.Tags.FirstOrDefault(x => x.Name.Equals(nameTag, StringComparison.OrdinalIgnoreCase));

            animal.Tags.Remove(tagToDelete);

            await _animalsRepo.SaveAnimalChanges();
        }
        //
        public async Task AddAnimalTag(int animalId, string nameTag)
        {
            var animal = await _animalsRepo.GetById(animalId);

            CheckingExceptions.CheckingAtNull(animal);

            CheckingExceptions.CheckingAtNull(nameTag);

            if (!animal.Tags.Any(x=>x.Name == nameTag))
            {
                var newAnimaltag = await _animalTagRepo.GetByName(nameTag);
                animal.Tags.Add(newAnimaltag);
                await _animalsRepo.SaveAnimalChanges();
            }
            else
                throw new Exception("Animal has got this tag");

        }
        //

        public async Task<IEnumerable<Animal>> GetAll()
        {
            var animals = await _animalsRepo.GetAll();

            if (animals == null)
                throw new AnimalIsNotFoundException();

            return animals;
        }

        public async Task<Animal> GetById(int id)
        {
            var animal = await _animalsRepo.GetById(id);

            if (animal == null)
                throw new AnimalIsNotFoundException();

            return animal;
        }

        public async Task<Animal> Update(Animal Animal)
        {
            var animal = await _animalsRepo.Update(Animal);

            return animal;
        }
    }
}
