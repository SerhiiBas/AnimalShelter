using AnimalShelter.Models.Animal;
using Data.Interfaces;
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

        public AnimalTagsServices(IAnimalTagRepo animalTagRepo)
        {
            this._animalTagRepo = animalTagRepo;
        }
        public async Task<AnimalTag> GetById(int id)
        {
            var animalTag = await _animalTagRepo.GetById(id);

            if (animalTag==null)
                throw new NullReferenceException();

            return animalTag;
        }
    }
}
