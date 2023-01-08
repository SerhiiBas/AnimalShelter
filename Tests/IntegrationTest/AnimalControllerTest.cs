using AnimalShelter.Models;
using AnimalShelter.Models.Animal;
using AnimalShelter.Services.Class;
using AnimalShelter.Services.Interfaces;
using AnimalShelterMVC.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.UnitTest;

namespace Test.IntegrationTest
{
    [TestClass]
    internal class AnimalControllerTest
    {
        private readonly Mock<IAnimalsServices> _animalsServices = new Mock<IAnimalsServices>();
        private readonly Mock<IAnimalsPhotoServices> _animalsPhotoServices = new Mock<IAnimalsPhotoServices>();
        private AnimalController _animalController;

        public AnimalController GetAnimalController()
        {
            return new AnimalController(_animalsServices.Object, _animalsPhotoServices.Object);
        }

        [TestMethod]
        public async Task GetAllAnimal_VerifyReturnType()
        {
            //arrange
            var controller = GetAnimalController();

            IEnumerable<Animal> newAnimalList = new List<Animal> {
                new Animal() { Age = 1, Gender = Gender.Male, AnimalId = 1,Name = "Dips",Size = "123cm" },
                new Animal() { Age = 1, Gender = Gender.Female, AnimalId = 2,Name = "Lips",Size = "113cm" },
                new Animal() { Age = 1, Gender = Gender.Male, AnimalId = 3,Name = "Mips",Size = "153cm" },
            };

            _animalsServices.Setup(x => x.GetAll()).Returns(Task.FromResult(newAnimalList));

            //act
            var resalt = await controller.GetAllAnimal();
            //assert
            Assert.IsTrue(resalt is IEnumerable<Animal>);

            Assert.Equals(newAnimalList, null);
        }

        [TestMethod]
        public async Task GetAnimalById_id_VerifyId()
        {
            //arrange
            _animalController = GetAnimalController();

            int testId = 12;

            var newAnimal = new Animal() { AnimalId = 12, Gender = Gender.Male, Name = "Frenk", Age = 2 };

            _animalsServices.Setup(x => x.DeleteByID(It.IsAny<int>())).Returns(Task.FromResult(newAnimal));

            //act

            var resalt = await _animalController.GetAnimalById(testId);

            //assert
            _animalsServices.Verify(x=>x.GetById(testId), Times.Once);
        }
    }
}
