using AnimalShelter.CastomExceptions.Volunteer;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Models.Volunteer;
using AnimalShelter.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace AnimalShelter.Services.Class
{
    public class VolunteersServices : IVolunteersServices
    {
        private readonly IVolunteersRepo _volunteersRepo;

        public VolunteersServices(IVolunteersRepo volunteersRepo)
        {
            this._volunteersRepo = volunteersRepo;
        }

        public async Task<Volunteer> Create(Volunteer volunteer)
        {
            if (volunteer.FirstName == null || volunteer.Surname == null || volunteer.LastName == null)
                throw new VolunteerIsnotValidExceptoin();

            return await _volunteersRepo.Create(volunteer);
        }

        public async Task<Volunteer> DeleteByID(int id)
        {
            var volunteer = await _volunteersRepo.GetById(id);

            if (volunteer == null)
                throw new VolunteerNotFoundException();

            await _volunteersRepo.Delete(volunteer);

            return volunteer;
        }

        public async Task<IEnumerable<Volunteer>> GetAll()
        {
            var volunteer = await _volunteersRepo.GetAll();

            if (volunteer == null)
                throw new VolunteerNotFoundException();

            return volunteer;
        }

        public async Task<Volunteer> GetById(int id)
        {
            var volunteer = await _volunteersRepo.GetById(id);

            if(volunteer == null)
                throw new VolunteerNotFoundException();

            return volunteer;
        }

        public async Task<Volunteer> Update(int id, JsonPatchDocument<Volunteer> jsonPatch)
        {
            var volunteer = await _volunteersRepo.GetById(id);

            if(volunteer==null)
                throw new VolunteerNotFoundException();

            jsonPatch.ApplyTo(volunteer);

            await _volunteersRepo.SaveChanges();

            return volunteer;
        }
    }
}
