using AnimalShelter.Context;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Models.Animal;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Data.Class
{
    public class AnimalsPhotoRepo : IAnimalsPhotoRepo
    {
        private readonly AnimalShelterContext _animalShelterContext;

        public AnimalsPhotoRepo(AnimalShelterContext animalShelterContext)
        {
            this._animalShelterContext = animalShelterContext;
        }

        public async Task<AnimalPhoto> Add(AnimalPhoto animalPhoto)
        {
            await _animalShelterContext.AnimalsPhotos.AddAsync(animalPhoto);

            await _animalShelterContext.SaveChangesAsync();

            return animalPhoto;
        }

        public async Task Delete(AnimalPhoto animalPhoto)
        {
            _animalShelterContext.Remove(animalPhoto);

            await _animalShelterContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AnimalPhoto>> GetAll()
        {
            var animalPhotolList = await _animalShelterContext.AnimalsPhotos.AsNoTracking().ToListAsync();

            return animalPhotolList;
        }

        public async Task<AnimalPhoto> GetByID(int Id)
        {
            var animalPhoto = await _animalShelterContext.AnimalsPhotos.FirstOrDefaultAsync(x => x.Id == Id);

            return animalPhoto;
        }
    }
}
