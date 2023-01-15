using AnimalShelter.Context;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Data.Class
{
    public class EmployeesPhotoRepo : IEmployeesPhotoRepo
    {
        private readonly AnimalShelterContext _animalShelterContext;

        public EmployeesPhotoRepo(AnimalShelterContext animalShelterContext)
        {
            this._animalShelterContext = animalShelterContext;
        }

        public async Task<EmployeePhoto> Add(EmployeePhoto employeePhoto)
        {
            await _animalShelterContext.EmployeesPhotos.AddAsync(employeePhoto);

            await _animalShelterContext.SaveChangesAsync();

            return employeePhoto;
        }

        public async Task Delete(EmployeePhoto employeePhoto)
        {
            _animalShelterContext.Remove(employeePhoto);

            await _animalShelterContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeePhoto>> GetAll()
        {
            var EmployeesPhotolList = await _animalShelterContext.EmployeesPhotos.AsNoTracking().ToListAsync();

            return EmployeesPhotolList;
        }

        public async Task<EmployeePhoto> GetByID(int Id)
        {
            var employeePhoto = await _animalShelterContext.EmployeesPhotos.FirstOrDefaultAsync(x => x.Id == Id);

            return employeePhoto;
        }
    }
}
