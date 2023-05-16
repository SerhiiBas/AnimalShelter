using AnimalShelter.Data.Interfaces;
using AnimalShelter.Models.Animal;
using Data.Interfaces;
using Filters.CastomExceptions;
using Servises.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servises.Services_Class
{
    public class AnimalTagsServices : IAnimalTagsServices
    {
        private readonly IAnimalTagRepo _animalTagRepo;
        private readonly IAnimalsRepo _animalsRepo;

        public AnimalTagsServices(IAnimalTagRepo animalTagRepo, IAnimalsRepo animalsRepo)
        {
            this._animalTagRepo = animalTagRepo;
            this._animalsRepo = animalsRepo;
        }
        public async Task<AnimalTag> GetById(int id)
        {
            var animalTag = await _animalTagRepo.GetById(id);

            if (animalTag==null)
                throw new NullReferenceException();

            return animalTag;
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

            if (!animal.Tags.Any(x => x.Name == nameTag))
            {
                var newAnimaltag = await _animalTagRepo.GetByName(nameTag);
                animal.Tags.Add(newAnimaltag);
                await _animalsRepo.SaveAnimalChanges();
            }
            else
                throw new Exception("Animal has got this tag");

        }
    }
}
