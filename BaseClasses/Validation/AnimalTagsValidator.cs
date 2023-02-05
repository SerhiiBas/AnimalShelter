using AnimalShelter.Models.Animal;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models.Validation
{
    internal class AnimalTagsValidator : AbstractValidator<AnimalTag>
    {
        public AnimalTagsValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(20).Matches(new Regex(@"^[A-Za-z\s]*$")).WithMessage("'{PropertyName}' should only contain letters.");
        }
    }
}
