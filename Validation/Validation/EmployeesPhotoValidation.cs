using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;
using FluentValidation;

namespace AnimalShelter.Validation
{
    public class EmployeesPhotoValidation: AbstractValidator<EmployeePhoto>
    {
        public EmployeesPhotoValidation()
        {
            RuleFor(x => x.Employee_Id).NotEmpty().NotNull();
        }
    }
}
