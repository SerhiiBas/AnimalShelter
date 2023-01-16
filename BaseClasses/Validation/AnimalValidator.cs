using AnimalShelter.Models.Animal;
using FluentValidation;

namespace AnimalShelter.Validation
{
    public class AnimalValidation: AbstractValidator<Animal>
    {
        public AnimalValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(20).Must(x=> x.All(Char.IsLetter)).WithMessage("The name can not contain the naumber");
            RuleFor(x => x.Gender).NotEmpty().NotNull();
            RuleFor(x => x.Age).NotEmpty().GreaterThan(0).WithMessage("The age must be Greater then 0");
            RuleFor(x => x.Tags).NotNull();
            RuleFor(x => x.History).MaximumLength(250);
        }
    }
}
