using AnimalShelter.Models.Animal;
using FluentValidation;

namespace AnimalShelter.Validation
{
    public class AnimalValidation: AbstractValidator<Animal>
    {
        public AnimalValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(20).Must(x=> x.All(Char.IsLetter)).WithMessage("Not corectly Name");
            RuleFor(x => x.Gender).NotEmpty().NotNull();
            RuleFor(x => x.Age).NotEmpty().LessThan(0).WithMessage("Not Valid age");
            RuleFor(x => x.Tags).NotNull().NotEmpty().WithMessage("You can chous IWantToRecover, Sterilized, LookingForAnOverstay, NoParasites, IWantToHome");
            RuleFor(x => x.History).Length(250);
        }
    }
}
