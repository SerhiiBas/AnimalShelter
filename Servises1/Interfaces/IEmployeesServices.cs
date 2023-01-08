using AnimalShelter.Models.Employee;
using AnimalShelter.Models.Volunteer;
using Microsoft.AspNetCore.JsonPatch;

namespace AnimalShelter.Services.Interfaces
{
    public interface IEmployeesServices
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> Create(Employee Employee);
        Task<Employee> DeleteByID(int id);
        Task<Employee> Update(int id, JsonPatchDocument<Employee> jsonPatch);
    }
}
