using AnimalShelter.Models.Volunteer;
using FluentValidation;

namespace AnimalShelter.Validation
{
    public class VolunteerValidation: AbstractValidator<Volunteer>
    {
        public VolunteerValidation()
        {
            RuleFor(x=> x.FirstName).NotEmpty().NotNull().Length(20).Must(x => x.All(Char.IsLetter)).WithMessage("The name is not valid");
            RuleFor(x=> x.Surname).NotEmpty().NotNull().Length(20).Must(x => x.All(Char.IsLetter)).WithMessage("The surname is not valid");
            RuleFor(x=> x.MiddleName).NotEmpty().NotNull().Length(20).Must(x => x.All(Char.IsLetter)).WithMessage("Thr middle name is not valid");
            RuleFor(x => x.Gender).NotEmpty().NotNull();
            RuleFor(x => x.AssistanceType).NotEmpty().NotNull();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
