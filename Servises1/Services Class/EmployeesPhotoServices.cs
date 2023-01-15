using AnimalShelter.CastomExceptions.Animal;
using AnimalShelter.Data.Class;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;
using AnimalShelter.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Services.Class
{
    public class EmployeesPhotoServices : IEmployeePhotoServices
    {
        private readonly IEmployeesPhotoRepo _employeesPhotoRepo;

        public EmployeesPhotoServices(IEmployeesPhotoRepo employeesPhotoRepo)
        {
            this._employeesPhotoRepo = employeesPhotoRepo;
        }

        public async Task<EmployeePhoto> Add(EmployeePhoto employeePhoto)
        {
            if (employeePhoto.Id == null)
                throw new FormatException();

            return await _employeesPhotoRepo.Add(employeePhoto);
        }

        public async Task<EmployeePhoto> Delete(int Id)
        {
            var employeePhoto = await _employeesPhotoRepo.GetByID(Id);

            if (employeePhoto == null)
                throw new NullReferenceException();

            await _employeesPhotoRepo.Delete(employeePhoto);

            return employeePhoto;
        }

        public async Task<IEnumerable<EmployeePhoto>> GetAll()
        {
            var employeesPhoto = await _employeesPhotoRepo.GetAll();

            if (employeesPhoto == null)
                throw new AnimalIsNotFoundException();

            return employeesPhoto;
        }

        public async Task<EmployeePhoto> GetByID(int Id)
        {
            var employeePhoto = await _employeesPhotoRepo.GetByID(Id);

            if (employeePhoto == null)
                throw new NullReferenceException();

            return employeePhoto;
        }
    }
}
