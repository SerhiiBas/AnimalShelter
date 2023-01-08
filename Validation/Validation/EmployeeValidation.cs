using AnimalShelter.Models.Animal;
using AnimalShelter.Models.Employee;
using FluentValidation;

namespace AnimalShelter.Validation
{
    public class EmployeeValidation: AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(20).Must(x => x.All(Char.IsLetter)).WithMessage("Not corectly Name");
            RuleFor(x => x.Surname).NotEmpty().NotNull().Length(20).Must(x => x.All(Char.IsLetter)).WithMessage("Not corectly Surname");
            RuleFor(x => x.Position).NotEmpty().NotNull().Length(20);
            RuleFor(x => x.Description).Length(250);
        }
    }
}
