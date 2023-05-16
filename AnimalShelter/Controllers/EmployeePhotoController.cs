using AnimalShelter.Models.Employee;
using AnimalShelter.Services.Interfaces;
using Filters.CastomExceptions;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterMVC.Controllers
{
    public class EmployeePhotoController : Controller
    {
        private readonly IEmployeePhotoServices _employeesPhotoServices;

        public EmployeePhotoController(IEmployeePhotoServices employeePhotoServices)
        {
            this._employeesPhotoServices = employeePhotoServices;
        }
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

            return RedirectToAction("GetAllEmployee","Employee");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployeePhoto([FromRoute] int id)
        {
            var delEmployee = await _employeesPhotoServices.GetByID(id);

            return View(delEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployeePhoto([FromForm] EmployeePhoto EmployeePhoto, [FromRoute] int id)
        {
            var employeePhoto = await _employeesPhotoServices.Delete(id);

            CheckingExceptions.CheckingAtNull(employeePhoto);

            return RedirectToAction("GetAllEmployeePhoto");
        }

    }
}
