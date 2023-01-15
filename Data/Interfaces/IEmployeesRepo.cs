using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;

namespace AnimalShelter.Data.Interfaces
{
    public interface IEmployeesRepo
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> Create(Employee Employee);
        Task Delete(Employee Employee);
        Task<Employee> Update(Employee Employee);
    }
}
