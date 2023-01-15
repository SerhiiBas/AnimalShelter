using AnimalShelter.Models.Employee;
using AnimalShelter.Models.Volunteer;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelter.Services.Interfaces
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> Create(Employee Employee);
        Task<Employee> DeleteByID(int id);
        Task<Employee> Update( Employee Employee);
    }
}
