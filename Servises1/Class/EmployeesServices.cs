using AnimalShelter.CastomExceptions.Animal;
using AnimalShelter.CastomExceptions.Employee;
using AnimalShelter.Data.Class;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;
using AnimalShelter.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace AnimalShelter.Services.Class
{
    public class EmployeesServices : IEmployeesServices
    {
        private readonly IEmployeesRepo _employeesRepo;

        public EmployeesServices(IEmployeesRepo employeesRepo)
        {
            this._employeesRepo = employeesRepo;
        }

        public async Task<Employee> Create(Employee employee)
        {
            if (employee.Name == null || employee.Surname == null || employee.Position == null)
                throw new EmployeeIsnotValidExceptoin();

            return await _employeesRepo.Create(employee);
        }

        public async Task<Employee> DeleteByID(int id)
        {
            var delEmployee = await _employeesRepo.GetById(id);

            if (delEmployee == null)
                throw new EmployeeNotFoundException();

            await _employeesRepo.Delete(delEmployee);

            return delEmployee;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employee = await _employeesRepo.GetAll();

            if (employee == null)
                throw new EmployeeNotFoundException();

            return employee;
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await _employeesRepo.GetById(id);

            if (employee==null)
                throw new EmployeeNotFoundException();

            return employee;
        }

        public async Task<Employee> Update(int id, JsonPatchDocument<Employee> jsonPatch)
        {
            var employee = await _employeesRepo.GetById(id);

            if (employee == null)
                throw new EmployeeNotFoundException();

            jsonPatch.ApplyTo(employee);

            await _employeesRepo.SaveChanges(); // Зберегти зміни в файлі

            return employee;
        }
    }
}
