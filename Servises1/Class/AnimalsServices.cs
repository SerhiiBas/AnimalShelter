using AnimalShelter.CastomExceptions.Animal;
using AnimalShelter.Data.Class;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Models.Animal;
using AnimalShelter.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace AnimalShelter.Services.Class
{
    public class AnimalsServices : IAnimalsServices
    {
        private readonly IAnimalsRepo _animalsRepo;

        public AnimalsServices(IAnimalsRepo animalsRepo)
        {
            this._animalsRepo = animalsRepo;
        }

        public async Task<Animal> Create(Animal animal)
        {
            if (animal.Name == null || animal.Gender == null || animal.Age <= 0 || animal.Tags == null)
                throw new AnimalIsnotValidExceptoin();

            return await _animalsRepo.Create(animal);
        }

        public async Task<Animal> DeleteByID(int id)
        {
            var delAnimal = await _animalsRepo.GetById(id);

            if (delAnimal == null)
                throw new AnimalNotFoundException();

            await _animalsRepo.Delete(delAnimal);

            return delAnimal;
        }

        public async Task<IEnumerable<Animal>> GetAll()
        {
            var animals = await _animalsRepo.GetAll();

            if (animals == null)
                throw new AnimalNotFoundException();

            return animals;
        }

        public async Task<Animal> GetById(int id)
        {
            var animal = await _animalsRepo.GetById(id);

            if (animal == null)
                throw new AnimalNotFoundException();

            return animal;
        }

        public async Task<Animal> Update(int id, Animal animal)
        {
            var newAnimal = await _animalsRepo.Create(animal);
            await _animalsRepo.Delete(await _animalsRepo.GetById(id));
            return newAnimal;
        }
    }
}
