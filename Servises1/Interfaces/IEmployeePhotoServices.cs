using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Services.Interfaces
{
    public interface IEmployeePhotoServices
    {
        Task<EmployeePhoto> Add(EmployeePhoto employeePhoto);
        Task<IEnumerable<EmployeePhoto>> GetAll();
        Task<EmployeePhoto> Delete(int Id);
        Task<EmployeePhoto> GetByID(int Id);
    }
}
