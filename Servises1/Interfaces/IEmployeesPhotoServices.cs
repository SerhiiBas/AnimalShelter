using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;

namespace AnimalShelter.Services.Interfaces
{
    public interface IEmployeesPhotoServices
    {
        Task<EmployeePhoto> Add(EmployeePhoto employeePhoto);
        Task<EmployeePhoto> Delete(int Id);
        Task<EmployeePhoto> GetByID(int Id);
    }
}
