using AnimalShelter.Models.Animal;

namespace AnimalShelter.Data.Interfaces
{
    public interface IAnimalsRepo
    {
        Task<IEnumerable<Animal>> GetAll();
        Task<Animal> GetById(int id);
        Task<Animal> Create(Animal animal);
        Task Delete(Animal Animal);
        Task SaveChanges();
    }
}
