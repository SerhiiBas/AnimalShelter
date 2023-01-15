using AnimalShelter.Models.Animal;
using FluentValidation;

namespace AnimalShelter.Validation
{
    public class AnimalValidation: AbstractValidator<Animal>
    {
        public AnimalValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(20).Must(x=> x.All(Char.IsLetter)).WithMessage("The name is not valid");
            RuleFor(x => x.Gender).NotEmpty().NotNull();
            RuleFor(x => x.Age).NotEmpty().LessThan(0).WithMessage("The age is not valid");
            RuleFor(x => x.Tags).NotNull().NotEmpty();
            RuleFor(x => x.History).Length(250);
        }
    }
}
