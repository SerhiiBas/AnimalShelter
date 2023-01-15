using AnimalShelter.Models.Volunteer;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Services.Interfaces
{
    public interface IVolunteerServices
    {
        Task<IEnumerable<Volunteer>> GetAll();
        Task<Volunteer> GetById(int id);
        Task<Volunteer> Create(Volunteer volunteer);
        Task<Volunteer> DeleteByID(int id);
        Task<Volunteer> Update(Volunteer volunteer);
    }
}
