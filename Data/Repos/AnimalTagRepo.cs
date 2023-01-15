using AnimalShelter.Context;
using AnimalShelter.Models.Animal;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class AnimalTagRepo : IAnimalTagRepo
    {
        private readonly AnimalShelterContext _animalShelterContext;

        public AnimalTagRepo(AnimalShelterContext animalShelterContext)
        {
            this._animalShelterContext = animalShelterContext;
        }

        public async Task<AnimalTag> GetById(int id)
        {
            return await _animalShelterContext.AnimalTag.FirstOrDefaultAsync(x => x.TagId == id);
        }
    }
}
