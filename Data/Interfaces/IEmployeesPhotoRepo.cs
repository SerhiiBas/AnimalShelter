using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;

namespace AnimalShelter.Data.Interfaces
{
    public interface IEmployeesPhotoRepo
    {
        Task<EmployeePhoto> Add(EmployeePhoto employeePhoto);
        Task Delete(EmployeePhoto employeePhoto);
        Task<EmployeePhoto> GetByID(int Id);
    }
}
