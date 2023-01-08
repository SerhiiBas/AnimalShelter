using AnimalShelter.Context;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Models.Employee;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Data.Class
{
    public class EmployeesRepo : IEmployeesRepo
    {
        private readonly AnimalShelterContext _employee;

        public EmployeesRepo(AnimalShelterContext employee)
        {
            this._employee = employee;
        }

        public async Task<Employee> Create(Employee Employee)
        {
            await _employee.Employees.AddAsync(Employee);

            await _employee.SaveChangesAsync();

            return Employee;
        }

        public async Task Delete(Employee Employee)
        {
            _employee.Remove(Employee);

            await _employee.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var allEmployee = await _employee.Employees.AsNoTracking().ToListAsync();

            return allEmployee;
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await _employee.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);

            return employee;
        }

        public async Task SaveChanges()
        {
            await _employee.SaveChangesAsync();
        }
    }
}
