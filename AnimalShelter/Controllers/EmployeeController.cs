using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;
using AnimalShelter.Services.Class;
using AnimalShelter.Services.Interfaces;
using Filters.CastomExceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeesServices;
        private readonly IEmployeePhotoServices _employeesPhotoServices;

        public EmployeeController(IEmployeeServices employeesServices, IEmployeePhotoServices employeesPhotoServices)
        {
            this._employeesServices = employeesServices;
            this._employeesPhotoServices = employeesPhotoServices;
        }

        [HttpGet]
        public IActionResult AddNewEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEmployee([FromForm] Employee employee)
        {
            var newEmployee = await _employeesServices.Create(employee);

            CheckingExceptions.CheckingAtNull(newEmployee);

            return RedirectToAction("GetEmployeeById", new { id = newEmployee.EmployeeId });
        }

        public async Task<IActionResult> GetAllEmployee()
        {
            IEnumerable<Employee> employee = await _employeesServices.GetAll();

            CheckingExceptions.CheckingAtNull(employee);

            return View(employee);
        }

        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            Employee employee = await _employeesServices.GetById(id);

            CheckingExceptions.CheckingAtNull(employee);

            return View(employee);
        }

        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var delEmployee = await _employeesServices.DeleteByID(id);

            CheckingExceptions.CheckingAtNull(delEmployee);

            return View(delEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id)
        {
            var employee = await _employeesServices.GetById(id);

            CheckingExceptions.CheckingAtNull(employee);

            return View(employee);
        }

        [HttpPost]
        public IActionResult UpdateEmployee([FromForm] Employee employee)
        {
            _employeesServices.Update(employee);

            return RedirectToAction("GetAllEmployee");
        }


        //Photos

        //Add AnimalPhotos

        public async Task<IActionResult> GetAllEmployeePhoto()
        {
            IEnumerable<EmployeePhoto> employeePhoto = await _employeesPhotoServices.GetAll();

            CheckingExceptions.CheckingAtNull(employeePhoto);

            return View(employeePhoto);
        }

        [HttpGet]
        public IActionResult AddPhotoEmployee([FromRoute] int id)
        {
            return View("AddPhotoEmployee", new EmployeePhoto() { EmployeeId = id });
        }

        [HttpPost]
        public IActionResult AddPhotoEmployee([FromForm] EmployeePhoto EmployeePhoto)
        {
            _employeesPhotoServices.Add(EmployeePhoto);

            return RedirectToAction("GetAllEmployee");
        }

        public async Task<IActionResult> DeleteEmployeePhoto([FromRoute] int id)
        {
            var employeePhoto = await _employeesPhotoServices.Delete(id);

            CheckingExceptions.CheckingAtNull(employeePhoto);

            return View(employeePhoto);
        }

    }
}
