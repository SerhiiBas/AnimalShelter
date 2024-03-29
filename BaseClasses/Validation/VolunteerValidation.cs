﻿using AnimalShelter.Models.Volunteer;
using FluentValidation;
using System.Text.RegularExpressions;

namespace AnimalShelter.Validation
{
    public class VolunteerValidation: AbstractValidator<Volunteer>
    {
        public VolunteerValidation()
        {
            RuleFor(x=> x.FirstName).NotEmpty().NotNull().MaximumLength(20).Matches(new Regex(@"^[A-Za-zA-Яа-яії\s]*$")).WithMessage("'{PropertyName}' should only contain letters."); ;
            RuleFor(x=> x.Surname).NotEmpty().NotNull().MaximumLength(20).Matches(new Regex(@"^[A-Za-zA-Яа-яії\s]*$")).WithMessage("'{PropertyName}' should only contain letters."); ;
            RuleFor(x=> x.MiddleName).NotEmpty().NotNull().MaximumLength(20).Matches(new Regex(@"^[A-Za-zA-Яа-яії\s]*$")).WithMessage("'{PropertyName}' should only contain letters."); ;
            RuleFor(x => x.Gender).NotNull();
            RuleFor(x => x.AssistanceType).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x=>x.PhoneNumber).NotEmpty()
                    .NotNull().WithMessage("Phone Number is required.")
                    .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
                    .MaximumLength(20).WithMessage("PhoneNumber must not exceed 13 characters.")
                    .Matches(new Regex(@"([\+]?[0-9][-]?|[0])?[1-9][0-9]{8}$")).WithMessage("PhoneNumber not valid +38298765432");
        }
    }
}
