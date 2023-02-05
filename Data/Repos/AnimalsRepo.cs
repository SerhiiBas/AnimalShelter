using AnimalShelter.Context;
using AnimalShelter.Data.Interfaces;
using AnimalShelter.Models.Animal;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Data.Class
{
    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly AnimalShelterContext _animal;

        public AnimalsRepo(AnimalShelterContext animal)
        {
            this._animal = animal;
        }

        public async Task<Animal> Create(Animal animal)
        {
            await _animal.AddAsync(animal);

            await _animal.SaveChangesAsync();

            return animal;
        }

        public async Task Delete(Animal Animal)
        {
            _animal.Remove(Animal);

            await _animal.SaveChangesAsync();
        }

        public async Task DeleteTag(Animal animal, AnimalTag animalTag)
        {
                animal.Tags.Remove(animalTag);

                await _animal.SaveChangesAsync();
        }

        public async Task<IEnumerable<Animal>> GetAll()
        {
            var animalList = await _animal.Animals.AsNoTracking().ToListAsync();

            return animalList;
        }

        public async Task<Animal> GetById(int id)
        {
            var animal = await _animal.Animals.Include(x=>x.AnimalPhotos).Include(x => x.Tags).FirstOrDefaultAsync(x => x.AnimalId == id);

            return animal;
        }

        public async Task SaveAnimalChanges()
        {
             await _animal.SaveChangesAsync();
        }

        public async Task<Animal> Update(Animal animal)
        {
            _animal.Update(animal);

            await _animal.SaveChangesAsync();

            return animal;
        }
    }
}
