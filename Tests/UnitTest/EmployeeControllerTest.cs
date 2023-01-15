using AnimalShelter.Services.Interfaces;
using AnimalShelterMVC.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AnimalShelter.Models.Employee;

namespace Test.IntegrationTest
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private Mock<IEmployeeServices> _employeeServices;
        private Mock<IEmployeePhotoServices> _employeePhotoServices;
        private EmployeeController _employeeController;

        public EmployeeController GetEmployeeController()
        {
            return new EmployeeController(_employeeServices.Object, _employeePhotoServices.Object);
        }

        [TestInitialize]
        public void SetUp()
        {
            _employeeServices = new Mock<IEmployeeServices>();

            _employeePhotoServices = new Mock<IEmployeePhotoServices>();
        }

        [TestMethod]
        public void AddNewEmployee_ServisesReturnNull_VerifyNullException()
        {
            //arrange
            _employeeController = GetEmployeeController();
            //act
            _employeeServices.Setup(x => x.Create(new Employee())).Returns(Task.FromResult<Employee>(null));
            //assert
            Assert.ThrowsExceptionAsync<NullReferenceException>(() => _employeeController.AddNewEmployee(new Employee() {Name = "TestName1", Surname = "TestSurname1", Position = "TestPosition1", Description="TestDescription1"}));
        }

        [TestMethod]
        public void UpdateEmployee_ServisesReturnNull_VerifyNullException()
        {
            //arrange
            _employeeController = GetEmployeeController();
            //act
            _employeeServices.Setup(x => x.Update(new Employee())).Returns(Task.FromResult<Employee>(null));
            //assert
            Assert.ThrowsExceptionAsync<NullReferenceException>(() => _employeeController.AddNewEmployee(new Employee() { Name = "TestName1", Surname = "TestSurname1", Position = "TestPosition1", Description = "TestDescription1" }));
        }

        [TestMethod]
        public async Task GetAllEmployee_VerifyReturnType()
        {
            //arrange
            _employeeController = GetEmployeeController();

            IEnumerable<Employee> newEmployeeList = new List<Employee> {
                new Employee() {Name = "TestName1", Surname = "TestSurname1", Position = "TestPosition1", Description="TestDescription1"},
                new Employee() {Name = "TestName2", Surname = "TestSurname2", Position = "TestPosition2", Description="TestDescription2"},
                new Employee() {Name = "TestName3", Surname = "TestSurname3", Position = "TestPosition3", Description="TestDescription3"},
                new Employee() {Name = "TestName4", Surname = "TestSurname4", Position = "TestPosition4", Description="TestDescription4"}
            };

            _employeeServices.Setup(x => x.GetAll()).Returns(Task.FromResult(newEmployeeList));

            //act
            var resalt = await _employeeController.GetAllEmployee();
            //assert
            Assert.IsTrue(resalt is ViewResult);

            Assert.AreEqual(newEmployeeList, ((ViewResult)resalt).Model);
        }

        [TestMethod]
        public async Task GetEmployeeById_id_VerifyId()
        {
            //arrange
            _employeeController = GetEmployeeController();

            int testId = 12;

            var newEmployee = new Employee() { Name = "TestName4", Surname = "TestSurname4", Position = "TestPosition4", Description = "TestDescription4" };

            _employeeServices.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(newEmployee));

            //act

            var resalt = await _employeeController.GetEmployeeById(testId);

            //assert
            _employeeServices.Verify(x => x.GetById(testId), Times.Once);
        }

        [TestMethod]
        public void DeleteEmployee_ServisesReturnNull_VerifyNullException()
        {
            //arrange
            _employeeController = GetEmployeeController();
            //act
            _employeeServices.Setup(x => x.DeleteByID(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));
            //assert
            Assert.ThrowsExceptionAsync<NullReferenceException>(() => _employeeController.DeleteEmployee(It.IsAny<int>()));
        }
    }
}
