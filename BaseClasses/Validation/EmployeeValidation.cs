using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;
using FluentValidation;

namespace AnimalShelter.Validation
{
    public class EmployeeValidation: AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(20).Must(x => x.All(Char.IsLetter)).WithMessage("The name can not contain the naumber");
            RuleFor(x => x.Surname).NotNull().MaximumLength(20).Must(x => x.All(Char.IsLetter)).WithMessage("The Surname can not contain the naumber");
            RuleFor(x => x.Position).NotNull().MaximumLength(20);
            RuleFor(x => x.Description).MaximumLength(250);
        }
    }
}
