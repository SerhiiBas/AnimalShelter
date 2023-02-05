using AnimalShelter.Context;
using AnimalShelter.Data.Class;
using AnimalShelter.Models.Animal;
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalShelter.Models.Employee;

namespace Tests.IntegrationTest
{
    [TestClass]
    public class EmployeeRepoTests
    {
        private EmployeesRepo _employeesRepo;
        private AnimalShelterContext _animalShelterContext;

        private EmployeesRepo GetEmployeeRepo()
        {
            return new EmployeesRepo(_animalShelterContext);
        }

        [TestInitialize]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<AnimalShelter.Context.AnimalShelterContext>().UseInMemoryDatabase("TestDB").Options;// конфігуруємо опшини(таблиці зв'язки і тд) такі як в нашого базового контексту.

            _animalShelterContext = new AnimalShelterContext(options);// створюємо новий контекст, базу даних, при ініціалізації якої в параметри прокидаємо новий шлях до тестової БД. в ін меморі
        }

        [TestCleanup]
        public void CleanUp()
        {
            _animalShelterContext.Database.EnsureDeleted();
        }

        [TestMethod]
        public async Task Create_ValidEmployee_EmployeeCreated()
        {
            //arrange
            _employeesRepo = GetEmployeeRepo();
            var employees =  new Employee() { Name = "TestName1", Surname = "TestSurname1", Position = "TestPosition1", Description = "TestDescription1" };
            //act
            await _employeesRepo.Create(employees);
            //assert
            Assert.IsTrue(_animalShelterContext.Employees.Any());
        }

        //todo виправити адд зробити методами асинхронними
        [TestMethod]
        public async Task Delete_ValidEmployee_EmployeeDeleted()// Перевірити
        {
            //arrange

            _employeesRepo = GetEmployeeRepo();

            var employee = new Employee() { Name = "TestName1", Surname = "TestSurname1", Position = "TestPosition1", Description = "TestDescription1" };

            _animalShelterContext.Employees.Add(employee);
            await _animalShelterContext.SaveChangesAsync();
            //act

            if (_animalShelterContext.Employees.Any())
                await _employeesRepo.Delete(employee);

            //Assert

            Assert.IsFalse(_animalShelterContext.Employees.Any());
        }

        [TestMethod]
        public async Task GetAll_ListWithFourEmployees_ListWithFourEmployees()
        {
            //arrange

            int countOflist = 4;

            _employeesRepo = GetEmployeeRepo();

            List<Employee> EmployeesList = new List<Employee>() {
               new Employee() { Name = "TestName1", Surname = "TestSurname1", Position = "TestPosition1", Description = "TestDescription1" },
               new Employee() { Name = "TestName2", Surname = "TestSurname2", Position = "TestPosition2", Description = "TestDescription2" },
               new Employee() { Name = "TestName3", Surname = "TestSurname3", Position = "TestPosition3", Description = "TestDescription3" },
               new Employee() { Name = "TestName4", Surname = "TestSurname4", Position = "TestPosition4", Description = "TestDescription4" }
            };

            _animalShelterContext.Employees.AddRange(EmployeesList);
            await _animalShelterContext.SaveChangesAsync();

            //act

            var employees = await _employeesRepo.GetAll();

            //assert

            Assert.IsTrue(countOflist == employees.Count());
        }

        [TestMethod]
        public async Task GetById_ListOfEmployees_EmployeeWithId2()
        {
            //aeeange
            _employeesRepo = GetEmployeeRepo();

            List<Employee> EmployeesList = new List<Employee>() {
               new Employee() { Name = "TestName1", Surname = "TestSurname1", Position = "TestPosition1", Description = "TestDescription1" },
               new Employee() { Name = "TestName2", Surname = "TestSurname2", Position = "TestPosition2", Description = "TestDescription2" },
               new Employee() { Name = "TestName3", Surname = "TestSurname3", Position = "TestPosition3", Description = "TestDescription3" },
               new Employee() { Name = "TestName4", Surname = "TestSurname4", Position = "TestPosition4", Description = "TestDescription4" }
            };

            int id = 2;

            _animalShelterContext.Employees.AddRange(EmployeesList);
            await _animalShelterContext.SaveChangesAsync();
            //act

            var employee = await _employeesRepo.GetById(id);

            //Assert

            Assert.IsTrue(id == employee.EmployeeId);
        }
    }
}
 