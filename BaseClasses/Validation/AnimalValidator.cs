using AnimalShelter.Models.Animal;
using FluentValidation;
using System.Text.RegularExpressions;

namespace AnimalShelter.Validation
{
    public class AnimalValidation : AbstractValidator<Animal>
    {
        public AnimalValidation()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(20).Matches(new Regex(@"^[A-Za-zA-Яа-яії\s]*$")).WithMessage("'{PropertyName}' should only contain letters.");
            RuleFor(x => x.Gender).NotNull();
            RuleFor(x => x.Age).NotEmpty().GreaterThan(0).WithMessage("The age must be Greater then 0");
            RuleFor(x => x.Tags).NotNull();
            RuleFor(x => x.History).MaximumLength(250);
        }
    }
}
