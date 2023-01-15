using AnimalShelter.Services.Interfaces;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Models.Animal;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using AnimalShelter.CastomExceptions.Animal;
using AnimalShelter.Data.Class;

namespace AnimalShelter.Services.Class
{
    public class AnimalsPhotoServices : IAnimalPhotoServices
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

        public async Task<IEnumerable<AnimalPhoto>> GetAll()
        {
            var animalsPhoto = await _animalsPhotoRepo.GetAll();

            if (animalsPhoto == null)
                throw new AnimalIsNotFoundException();

            return animalsPhoto;
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
