using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Services.Interfaces
{
    public interface IAnimalServices
    {
        Task<IEnumerable<Animal>> GetAll();
        Task<Animal> GetById(int id);
        Task<Animal> Create(Animal animal);
        Task<Animal> DeleteByID(int id);
        Task DeleteTag(int animalId, string tagName);
        Task<Animal> Update(Animal animal);
    }
}
