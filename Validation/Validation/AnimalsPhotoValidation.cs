using AnimalShelter.Models.Animal;
using FluentValidation;

namespace AnimalShelter.Validation
{
    public class AnimalsPhotoValidation : AbstractValidator<AnimalPhoto>
    {
        public AnimalsPhotoValidation()
        {
            RuleFor(x => x.Animal_Id).NotEmpty().NotNull();
        }
    }
}
