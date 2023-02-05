using AnimalShelter.Context;
using AnimalShelter.Data.Class;
using AnimalShelter.Models.Employee;
using AnimalShelter.Models.Volunteer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.IntegrationTest
{
    [TestClass]
    public class VolunteerRepoTests
    {
        private VolunteersRepo _volunteersRepo;
        private AnimalShelterContext _animalShelterContext;

        private VolunteersRepo GetVolunteersRepo()
        {
            return new VolunteersRepo(_animalShelterContext);
        }

        [TestInitialize]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<AnimalShelter.Context.AnimalShelterContext>().UseInMemoryDatabase("TestDB").Options;// конфігуруємо опшини(таблиці зв'язки і тд) такі як в нашого базового контексту.

            _animalShelterContext = new AnimalShelterContext(options);// створюємо новий контекст, базу даних, при ініціалізації якої в параметри прокидаємо новий шлях до тестової БД. в ін меморі
        }

        [TestCleanup]
        public void CleanUp()
        {
            _animalShelterContext.Database.EnsureDeleted();
        }

        [TestMethod]
        public async Task Create_ValidVolunteer_VolunteerCreated()
        {
            //arrange
            _volunteersRepo = GetVolunteersRepo();
            var Volunteer = new Volunteer() { FirstName = "TestName1", Surname = "TestSurname1",MiddleName = "TestLastName1", AssistanceType = AssistanceType.TakingAnAnimal, Email = "test@gmail.com",Gender = AnimalShelter.Models.Gender.Female, PhoneNumber = "+380999111000" };
            //act
            await _volunteersRepo.Create(Volunteer);
            //assert
            Assert.IsTrue(_animalShelterContext.Volunteers.Any());
        }

        //todo виправити адд зробити методами асинхронними
        [TestMethod]
        public async Task Delete_ValidVolunteer_VolunteerDeleted()// Перевірити
        {
            //arrange

            _volunteersRepo = GetVolunteersRepo();

            var volunteer = new Volunteer() { FirstName = "TestName1", Surname = "TestSurname1", MiddleName = "TestMiddleName", AssistanceType = AssistanceType.TakingAnAnimal, Email = "test@gmail.com", Gender = AnimalShelter.Models.Gender.Female, PhoneNumber = "+380999111000" };

            _animalShelterContext.Volunteers.Add(volunteer);
            await _animalShelterContext.SaveChangesAsync();
            //act

            if (_animalShelterContext.Volunteers.Any())
                await _volunteersRepo.Delete(volunteer);

            //Assert

            Assert.IsFalse(_animalShelterContext.Volunteers.Any());
        }

        [TestMethod]
        public async Task GetAll_ListWithFourVolunteers_ListWithFourVolunteers()
        {
            //arrange

            int countOflist = 4;

            _volunteersRepo = GetVolunteersRepo();

            List<Volunteer> VolunteersList = new List<Volunteer>() {
              new Volunteer() { FirstName = "TestName1", Surname = "TestSurname1",MiddleName = "TestMiddleName1", AssistanceType = AssistanceType.TakingAnAnimal, Email = "test@gmail.com",Gender = AnimalShelter.Models.Gender.Female, PhoneNumber = "+380999111000" },
              new Volunteer() { FirstName = "TestName2", Surname = "TestSurname2",MiddleName = "TestMiddleName2", AssistanceType = AssistanceType.TakingAnAnimal, Email = "test@gmail.com",Gender = AnimalShelter.Models.Gender.Female, PhoneNumber = "+380999111000" },
              new Volunteer() { FirstName = "TestName3", Surname = "TestSurname3",MiddleName = "TestMiddleName3", AssistanceType = AssistanceType.TakingAnAnimal, Email = "test@gmail.com",Gender = AnimalShelter.Models.Gender.Female, PhoneNumber = "+380999111000" },
              new Volunteer() { FirstName = "TestName4", Surname = "TestSurname4",MiddleName = "TestMiddleName4", AssistanceType = AssistanceType.TakingAnAnimal, Email = "test@gmail.com",Gender = AnimalShelter.Models.Gender.Female, PhoneNumber = "+380999111000" },
            };

            _animalShelterContext.Volunteers.AddRange(VolunteersList);
            await _animalShelterContext.SaveChangesAsync();

            //act

            var volunteers = await _volunteersRepo.GetAll();

            //assert

            Assert.IsTrue(countOflist == volunteers.Count());
        }

        [TestMethod]
        public async Task GetById_ListOfVolunteers_VolunteerWithId2()
        {
            //aeeange
            _volunteersRepo = GetVolunteersRepo();

            List<Volunteer> VolunteersList = new List<Volunteer>() {
              new Volunteer() { FirstName = "TestName1", Surname = "TestSurname1",MiddleName = "TestLastName1", AssistanceType = AssistanceType.TakingAnAnimal, Email = "test@gmail.com",Gender = AnimalShelter.Models.Gender.Female, PhoneNumber = "+380999111000" },
              new Volunteer() { FirstName = "TestName2", Surname = "TestSurname2",MiddleName = "TestLastName2", AssistanceType = AssistanceType.TakingAnAnimal, Email = "test@gmail.com",Gender = AnimalShelter.Models.Gender.Female, PhoneNumber = "+380999111000" },
              new Volunteer() { FirstName = "TestName3", Surname = "TestSurname3",MiddleName = "TestLastName3", AssistanceType = AssistanceType.TakingAnAnimal, Email = "test@gmail.com",Gender = AnimalShelter.Models.Gender.Female, PhoneNumber = "+380999111000" },
              new Volunteer() { FirstName = "TestName4", Surname = "TestSurname4",MiddleName = "TestLastName4", AssistanceType = AssistanceType.TakingAnAnimal, Email = "test@gmail.com",Gender = AnimalShelter.Models.Gender.Female, PhoneNumber = "+380999111000" },
            };

            int id = 2;

            _animalShelterContext.Volunteers.AddRange(VolunteersList);
            await _animalShelterContext.SaveChangesAsync();
            //act

            var volunteer = await _volunteersRepo.GetById(id);

            //Assert

            Assert.IsTrue(id == volunteer.VolunteerId);
        }
    }
}
