using AnimalShelter.Models.Animal;

namespace AnimalShelter.Services.Interfaces
{
    public interface IAnimalsPhotoServices
    {
        Task<AnimalPhoto> Add(AnimalPhoto animalPhoto);
        Task<AnimalPhoto> Delete(int id);
        Task<AnimalPhoto> GetByID(int Id);
    }
}
