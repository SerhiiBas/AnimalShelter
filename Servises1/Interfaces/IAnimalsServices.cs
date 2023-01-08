using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;
using Microsoft.AspNetCore.JsonPatch;

namespace AnimalShelter.Services.Interfaces
{
    public interface IAnimalsServices
    {
        Task<IEnumerable<Animal>> GetAll();
        Task<Animal> GetById(int id);
        Task<Animal> Create(Animal animal);
        Task<Animal> DeleteByID(int id);
        Task<Animal> Update(int id, Animal animal);
    }
}
