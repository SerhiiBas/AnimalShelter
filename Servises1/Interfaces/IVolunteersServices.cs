using AnimalShelter.Models.Volunteer;
using Microsoft.AspNetCore.JsonPatch;

namespace AnimalShelter.Services.Interfaces
{
    public interface IVolunteersServices
    {
        Task<IEnumerable<Volunteer>> GetAll();
        Task<Volunteer> GetById(int id);
        Task<Volunteer> Create(Volunteer volunteer);
        Task<Volunteer> DeleteByID(int id);
        Task<Volunteer> Update(int id, JsonPatchDocument<Volunteer> jsonPatch);
    }
}
