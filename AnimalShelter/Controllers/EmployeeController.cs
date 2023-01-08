using AnimalShelter.Models.Employee;
using AnimalShelter.Services.Class;
using AnimalShelter.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeesServices _employeesServices;
        private readonly IEmployeesPhotoServices _employeesPhotoServices;

        public EmployeeController(IEmployeesServices employeesServices, IEmployeesPhotoServices employeesPhotoServices)
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

            return RedirectToAction("GetEmployeeById", new { id = newEmployee.EmployeeId });
        }

        public async Task<IActionResult> GetAllEmployee()
        {
            IEnumerable<Employee> employee = await _employeesServices.GetAll();

            return View(employee);
        }

        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            Employee employee = await _employeesServices.GetById(id);

            return View(employee);
        }

        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var delEmployee = await _employeesServices.DeleteByID(id);

            return View(delEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id)
        {
            var employee = await _employeesServices.GetById(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult UpdateEmployee([FromRoute] int id, [FromForm] JsonPatchDocument<Employee> jsonPatch)
        {
            _employeesServices.Update(id, jsonPatch);

            return RedirectToAction("GetAllEmployee");
        }


        //Photos

        //Add Photo

        [HttpGet]
        public IActionResult AddPhotoEmployee([FromRoute] int id)
        {
            return View("AddPhotoEmployee", new EmployeePhoto() { Employee_Id = id });
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

            return View(employeePhoto);
        }

    }
}
