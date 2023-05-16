using AnimalShelter.Models.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servises.Interfaces
{
    public interface IAnimalTagsServices
    {
        Task<AnimalTag> GetById(int id);
        Task DeleteTag(int animalId, string tagName);
        Task AddAnimalTag(int animalId, string nameTag);
    }
}
