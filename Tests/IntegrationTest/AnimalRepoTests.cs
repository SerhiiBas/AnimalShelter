using AnimalShelter.Context;
using AnimalShelter.Data.Class;
using AnimalShelter.Models;
using AnimalShelter.Models.Animal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.IntegrationTest
{
    [TestClass]
    public class AnimalRepoTests
    {
        private AnimalsRepo _animalsRepo;
        private AnimalShelterContext _animalShelterContext;

        private AnimalsRepo GetAnimalsRepo()
        {
            return new AnimalsRepo(_animalShelterContext);
        }

        [TestInitialize]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<AnimalShelter.Context.AnimalShelterContext>().UseInMemoryDatabase("TestDB").Options;
            _animalShelterContext = new AnimalShelterContext(options);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _animalShelterContext.Database.EnsureDeleted();
        }

        [TestMethod]
        public async Task Create_ValidAnimal_AnimalCreated()
        {
            //arrange

            _animalsRepo = GetAnimalsRepo();

            var animal = new Animal() { Age = 1, Gender = Gender.Male, AnimalId = 1, Name = "Dips", Size = "123cm", History = "sfe", TypeOfAnimal = "dog" };

            //act
            await _animalsRepo.Create(animal);
            //assert
            Assert.IsTrue(_animalShelterContext.Animals.Any());
        }

        //todo виправити адд зробити методами асинхронними
        [TestMethod]
        public async Task Delete_ValidAnimal_AnimalDeleted()// Перевірити
        {
            //arrange
            _animalsRepo = GetAnimalsRepo();

            var animal = new Animal() { AnimalId = 1, Name = "TestName1", TypeOfAnimal = "TestType1", Age = 1, Gender = Gender.Male, Size = "153cm",History = "TestHistory1" };

            _animalShelterContext.Animals.Add(animal);
            await _animalShelterContext.SaveChangesAsync();
            //act

            if (_animalShelterContext.Animals.Any())
               await _animalsRepo.Delete(animal);

            //Assert

            Assert.IsFalse(_animalShelterContext.Animals.Any());
        }

        [TestMethod]
        public async Task GetAll_ListWithTwoAnimals_ListWithTwoAnimals()
        {
            //arrange
            _animalsRepo = GetAnimalsRepo();

            List<Animal> animalsList = new List<Animal>() {
                new Animal() { AnimalId = 1, Name = "TestName1", TypeOfAnimal = "TestType1", Age = 1, Gender = Gender.Male, Size = "153cm", History = "TestHistory1" },
                new Animal() { AnimalId = 2, Name = "TestName2", TypeOfAnimal = "TestType2", Age = 2, Gender = Gender.Female, Size = "23cm", History = "TestHistory2" }
            };

            _animalShelterContext.Animals.AddRange(animalsList);
            await _animalShelterContext.SaveChangesAsync();

            //act

            var animals = await _animalsRepo.GetAll();

            //assert

            Assert.IsTrue(2 == animals.Count());
        }

        [TestMethod]
        public async Task GetById_ListOfAnimals_AnimalWithId2()
        {
            //aeeange
            _animalsRepo = GetAnimalsRepo();

            List<Animal> animalsList = new List<Animal>() {
                new Animal() { AnimalId = 1, Name = "TestName1", TypeOfAnimal = "TestType1", Age = 1, Gender = Gender.Male, Size = "153cm", History = "TestHistory1" },
                new Animal() { AnimalId = 2, Name = "TestName2", TypeOfAnimal = "TestType2", Age = 2, Gender = Gender.Female, Size = "23cm", History = "TestHistory2" },
                new Animal() { AnimalId = 3, Name = "TestName3", TypeOfAnimal = "TestType3", Age = 3, Gender = Gender.Female, Size = "23cm" , History = "TestHistory3"},
                new Animal() { AnimalId = 4, Name = "TestName4", TypeOfAnimal = "TestType4", Age = 4, Gender = Gender.Female, Size = "23cm" , History = "TestHistory4"},
            };

            int id = 2;

            _animalShelterContext.Animals.AddRange(animalsList);
            await _animalShelterContext.SaveChangesAsync();
            //act

            var animal = await _animalsRepo.GetById(id);

            //Assert

            Assert.IsTrue(id == animal.AnimalId);
        }

        [TestMethod]
        public async Task Update_ListOfAnimals_AnimalUpdated()//походу щоб переробити вони кидає в трекінг анімала який і так сидить в памяті тому конфліктує
        {
            //aeeange
            _animalsRepo = GetAnimalsRepo();

            List<Animal> animalsList = new List<Animal>() {
                new Animal() { AnimalId = 1, Name = "TestName1", TypeOfAnimal = "TestType1", Age = 1, Gender = Gender.Male, Size = "153cm", History = "TestHistory1" },
                new Animal() { AnimalId = 2, Name = "TestName2", TypeOfAnimal = "TestType2", Age = 2, Gender = Gender.Female, Size = "23cm", History = "TestHistory2" },
                new Animal() { AnimalId = 3, Name = "TestName3", TypeOfAnimal = "TestType3", Age = 3, Gender = Gender.Female, Size = "23cm", History = "TestHistory3" },
                new Animal() { AnimalId = 4, Name = "TestName4", TypeOfAnimal = "TestType4", Age = 4, Gender = Gender.Female, Size = "23cm" , History = "TestHistory4"},
            };

            Animal updateAnimal = new Animal() { AnimalId = 2, Name = "UpdateName2", TypeOfAnimal = "UpdateType2", Age = 2, Gender = Gender.Female, Size = "Update23cm", History = "UpdateHistory2" };

            _animalShelterContext.Animals.AddRange(animalsList);

            await _animalShelterContext.SaveChangesAsync();

            _animalShelterContext.Animals.AsNoTracking();
            //act

            Animal animal = await _animalsRepo.Update(updateAnimal);

            //Assert

            Assert.IsTrue(_animalShelterContext.Animals.Contains<Animal>(animal));
        }
    }
}
