using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;

namespace AnimalShelter.Data.Interfaces
{
    public interface IAnimalsPhotoRepo
    {
        Task<AnimalPhoto> Add(AnimalPhoto animalPhoto);
        Task Delete(AnimalPhoto animalPhoto);
        Task<AnimalPhoto> GetByID(int Id);
    }
}
