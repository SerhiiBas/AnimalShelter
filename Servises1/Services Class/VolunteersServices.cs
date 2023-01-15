using AnimalShelter.CastomExceptions.Volunteer;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Models.Volunteer;
using AnimalShelter.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Services.Class
{
    public class VolunteersServices : IVolunteerServices
    {
        private readonly IVolunteersRepo _volunteersRepo;

        public VolunteersServices(IVolunteersRepo volunteersRepo)
        {
            this._volunteersRepo = volunteersRepo;
        }

        public async Task<Volunteer> Create(Volunteer volunteer)
        {
            if (volunteer.FirstName == null || volunteer.Surname == null)
                throw new VolunteerIsnotValidExceptoin();

            return await _volunteersRepo.Create(volunteer);
        }

        public async Task<Volunteer> DeleteByID(int id)
        {
            var volunteer = await _volunteersRepo.GetById(id);

            if (volunteer == null)
                throw new VolunteerIsNotFoundException();

            await _volunteersRepo.Delete(volunteer);

            return volunteer;
        }

        public async Task<IEnumerable<Volunteer>> GetAll()
        {
            var volunteer = await _volunteersRepo.GetAll();

            if (volunteer == null)
                throw new VolunteerIsNotFoundException();

            return volunteer;
        }

        public async Task<Volunteer> GetById(int id)
        {
            var volunteer = await _volunteersRepo.GetById(id);

            if(volunteer == null)
                throw new VolunteerIsNotFoundException();

            return volunteer;
        }

        public async Task<Volunteer> Update(Volunteer volunteer)
        {
            var newVolunteer = await _volunteersRepo.Update(volunteer);

            if(volunteer==null)
                throw new VolunteerIsNotFoundException();

            return newVolunteer;
        }
    }
}
