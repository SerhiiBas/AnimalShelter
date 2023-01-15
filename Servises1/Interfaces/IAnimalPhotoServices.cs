using AnimalShelter.Models.Animal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Services.Interfaces
{
    public interface IAnimalPhotoServices
    {
        Task<AnimalPhoto> Add(AnimalPhoto animalPhoto);
        Task<IEnumerable<AnimalPhoto>> GetAll();
        Task<AnimalPhoto> Delete(int id);
        Task<AnimalPhoto> GetByID(int Id);
    }
}
