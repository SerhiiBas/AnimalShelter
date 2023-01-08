using AnimalShelter.Models.Volunteer;
using FluentValidation;

namespace AnimalShelter.Validation
{
    public class VolunteerValidation: AbstractValidator<Volunteer>
    {
        public VolunteerValidation()
        {
            RuleFor(x=> x.FirstName).NotEmpty().NotNull().Length(20).Must(x => x.All(Char.IsLetter)).WithMessage("Not corectly Name");
            RuleFor(x=> x.Surname).NotEmpty().NotNull().Length(20).Must(x => x.All(Char.IsLetter)).WithMessage("Not corectly Surname");
            RuleFor(x=> x.LastName).NotEmpty().NotNull().Length(20).Must(x => x.All(Char.IsLetter)).WithMessage("Not corectly LastName");
            RuleFor(x => x.Gender).NotEmpty().NotNull();
            RuleFor(x => x.AssistanceType).NotEmpty().NotNull();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
