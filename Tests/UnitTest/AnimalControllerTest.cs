using AnimalShelter.Models;
using AnimalShelter.Models.Animal;
using AnimalShelter.Services.Interfaces;
using AnimalShelterMVC.Controllers;
using Microsoft.AspNetCore.Mvc;

using Moq;
using Servises.Interfaces;

namespace Test.IntegrationTest
{
    [TestClass]
    public class AnimalControllerTest
    {
        private Mock<IAnimalServices> _animalsServices;
        private Mock<IAnimalPhotoServices> _animalsPhotoServices;
        private Mock<IAnimalTagsServices> _animalTagsServices;
        private AnimalController _animalController;

        public AnimalController GetAnimalController()
        {
            return new AnimalController(_animalsServices.Object, _animalsPhotoServices.Object, _animalTagsServices.Object);
        }

        [TestInitialize]
        public void SetUp()
        {
            _animalTagsServices = new Mock<IAnimalTagsServices>();

            _animalsServices = new Mock<IAnimalServices>();

            _animalsPhotoServices = new Mock<IAnimalPhotoServices>();
        }

        [TestMethod]
        public void AddNewAnimal_ServisesReturnNull_VerifyNullException()
        {
            //arrange
            _animalController = GetAnimalController();
            //act
            _animalsServices.Setup(x => x.Create(new Animal())).Returns(Task.FromResult<Animal>(null));
            //assert
            Assert.ThrowsExceptionAsync<NullReferenceException>(() => _animalController.AddNewAnimal(new Animal() { Age = 1, Gender = Gender.Male, AnimalId = 1, Name = "Dips", Size = "123cm" },new int[1] {1}));
        }

        [TestMethod]
        public void UpdateAnimal_ServisesReturnNull_VerifyNullException()
        {
            //arrange
            _animalController = GetAnimalController();
            //act
            _animalsServices.Setup(x => x.Update(new Animal())).Returns(Task.FromResult<Animal>(null));
            //assert
            Assert.ThrowsExceptionAsync<NullReferenceException>(() => _animalController.AddNewAnimal(new Animal() { Age = 1, Gender = Gender.Male, AnimalId = 1, Name = "Dips", Size = "123cm" }, new int[1] { 1 }));
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
            Assert.IsTrue(resalt is ViewResult);

            Assert.AreEqual(newAnimalList, ((ViewResult)resalt).Model);
        }

        [TestMethod]
        public async Task GetAnimalById_id_VerifyId()
        {
            //arrange
            _animalController = GetAnimalController();

            int testId = 12;

            var newAnimal = new Animal() { AnimalId = 12, Gender = Gender.Male, Name = "Frank", Age = 2 };

            _animalsServices.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(newAnimal));

            //act

            var resalt = await _animalController.GetAnimalById(testId);

            //assert
            _animalsServices.Verify(x => x.GetById(testId), Times.Once);
        }

        [TestMethod]
        public void DeleteAnimal_ServisesReturnNull_VerifyNullException()
        {
            //arrange
            _animalController = GetAnimalController();
            //act
            _animalsServices.Setup(x => x.DeleteByID(It.IsAny<int>())).Returns(Task.FromResult<Animal>(null));
            //assert
            Assert.ThrowsExceptionAsync<NullReferenceException>(() => _animalController.DeleteAnimal(It.IsAny<int>()));
        }
    }
}
