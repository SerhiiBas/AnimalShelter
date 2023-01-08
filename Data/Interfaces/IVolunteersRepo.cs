using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Volunteer;

namespace AnimalShelter.Data.Interfaces
{
    public interface IVolunteersRepo
    {
        Task<IEnumerable<Volunteer>> GetAll();
        Task<Volunteer> GetById(int id);
        Task<Volunteer> Create(Volunteer volunteer);
        Task Delete(Volunteer Volunteer);
        Task SaveChanges();
    }
}
