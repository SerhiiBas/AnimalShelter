using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;
using FluentValidation;
using System.Text.RegularExpressions;

namespace AnimalShelter.Validation
{
    public class EmployeeValidation: AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(20).Matches(new Regex(@"^[A-Za-zA-Яа-яії\s]*$")).WithMessage("'{PropertyName}' should only contain letters.");
            RuleFor(x => x.Surname).NotNull().MaximumLength(20).Matches(new Regex(@"^[A-Za-zA-Яа-яїі\s]*$")).WithMessage("'{PropertyName}' should only contain letters.");
            RuleFor(x => x.Position).NotNull().MaximumLength(20);
            RuleFor(x => x.Description).MaximumLength(250);
        }
    }
}
