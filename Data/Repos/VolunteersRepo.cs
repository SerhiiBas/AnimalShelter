using AnimalShelter.Context;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Models.Volunteer;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Data.Class
{
    public class VolunteersRepo : IVolunteersRepo
    {
        private readonly AnimalShelterContext _volunteer;

        public VolunteersRepo(AnimalShelterContext volunteer)
        {
            this._volunteer = volunteer;
        }

        public async Task<Volunteer> Create(Volunteer volunteer)
        {
            await _volunteer.Volunteers.AddAsync(volunteer);

            await _volunteer.SaveChangesAsync();

            return volunteer;
        }

        public async Task Delete(Volunteer volunteer)
        {
            _volunteer.Remove(volunteer);

            await _volunteer.SaveChangesAsync();
        }

        public async Task<IEnumerable<Volunteer>> GetAll()
        {
            var AllVolunteers = await _volunteer.Volunteers.AsNoTracking().ToArrayAsync();

            return AllVolunteers;
        }

        public async Task<Volunteer> GetById(int id)
        {
            var volunteer = await _volunteer.Volunteers.FirstOrDefaultAsync(x => x.VolunteerId == id);

            return volunteer;
        }

        public async Task<Volunteer> Update(Volunteer volunteer)
        {
            _volunteer.Update(volunteer);

            await _volunteer.SaveChangesAsync();

            return volunteer;
        }
    }
}
