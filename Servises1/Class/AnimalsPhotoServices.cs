using AnimalShelter.Services.Interfaces;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Models.Animal;
using System.Threading.Tasks;
using System;

namespace AnimalShelter.Services.Class
{
    public class AnimalsPhotoServices : IAnimalsPhotoServices
    {
        private readonly IAnimalsPhotoRepo _animalsPhotoRepo;

        public AnimalsPhotoServices(IAnimalsPhotoRepo animalsPhotoRepo)
        {
            this._animalsPhotoRepo = animalsPhotoRepo;
        }

        public async Task<AnimalPhoto> Add(AnimalPhoto animalPhoto)
        {
            if (animalPhoto.Id == null)
                throw new FormatException();

            return await _animalsPhotoRepo.Add(animalPhoto);
        }

        public async Task<AnimalPhoto> Delete(int Id)
        {
            var animalPhoto = await _animalsPhotoRepo.GetByID(Id);
            if (animalPhoto == null)
                throw new NullReferenceException();

            await _animalsPhotoRepo.Delete(animalPhoto);

            return animalPhoto;
        }

        public async Task<AnimalPhoto> GetByID(int Id)
        {
            var animalPhoto = await _animalsPhotoRepo.GetByID(Id);

            if (animalPhoto==null)
                throw new NullReferenceException();

            return animalPhoto;
        }
    }
}
