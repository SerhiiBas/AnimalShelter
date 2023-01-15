using AnimalShelter.Models.Animal;
using AnimalShelter.Services.Interfaces;
using AnimalShelterMVC.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AnimalShelter.Controllers;
using AnimalShelter.Models.Volunteer;

namespace Test.IntegrationTest
{
    [TestClass]
    public class VolunteerControllerTest
    {
        private Mock<IVolunteerServices> _volunteersServices;
        private VolunteerController _volunteerController;

        public VolunteerController GetVolunteerController()
        {
            return new VolunteerController(_volunteersServices.Object);
        }

        [TestInitialize]
        public void SetUp()
        {
            _volunteersServices = new Mock<IVolunteerServices>();
        }

        [TestMethod]
        public void AddNewVolunteer_ServisesReturnNull_VerifyNullException()
        {
            //arrange
            _volunteerController = GetVolunteerController();
            //act
            _volunteersServices.Setup(x => x.Create(new Volunteer())).Returns(Task.FromResult<Volunteer>(null));
            //assert
            Assert.ThrowsExceptionAsync<NullReferenceException>(() => _volunteerController.AddNewVolunteer(new Volunteer() { FirstName = "TestName1", Surname = "TestSurname1", AssistanceType = AssistanceType.TakingAnAnimal, Email = "test@gmail.com" }));
        }

        [TestMethod]
        public void UpdateVolunteer_ServisesReturnNull_VerifyNullException()
        {
            //arrange
            _volunteerController = GetVolunteerController();
            //act
            _volunteersServices.Setup(x => x.Update(new Volunteer())).Returns(Task.FromResult<Volunteer>(null));
            //assert
            Assert.ThrowsExceptionAsync<NullReferenceException>(() => _volunteerController.AddNewVolunteer(new Volunteer() { FirstName = "TestName1", Surname = "TestSurname1", AssistanceType = AssistanceType.TakingAnAnimal, Email = "test@gmail.com" }));
        }

        [TestMethod]
        public async Task GetAllVolunteer_VerifyReturnType()
        {
            //arrange
            _volunteerController = GetVolunteerController();

            IEnumerable<Volunteer> newVolunteerlList = new List<Volunteer> {
                new Volunteer() { FirstName = "TestName1",Surname = "TestSurname1",AssistanceType = AssistanceType.TakingAnAnimal,Email ="test@gmail.com" },
                new Volunteer() { FirstName = "TestName2",Surname = "TestSurname2",AssistanceType = AssistanceType.AnimalWalking,Email ="test@gmail.com" },
                new Volunteer() { FirstName = "TestName3",Surname = "TestSurname3",AssistanceType = AssistanceType.TakingAnAnimal,Email ="test@gmail.com" },
                new Volunteer() { FirstName = "TestName4",Surname = "TestSurname4",AssistanceType = AssistanceType.Volunteering,Email ="test@gmail.com" },
                new Volunteer() { FirstName = "TestName5",Surname = "TestSurname5",AssistanceType = AssistanceType.TakingAnAnimal,Email ="test@gmail.com" }
            };

            _volunteersServices.Setup(x => x.GetAll()).Returns(Task.FromResult(newVolunteerlList));

            //act
            var resalt = await _volunteerController.GetAllVolunteer();
            //assert
            Assert.IsTrue(resalt is ViewResult);

            Assert.AreEqual(newVolunteerlList, ((ViewResult)resalt).Model);
        }

        [TestMethod]
        public async Task GetVolunteerById_id_VerifyId()
        {
            //arrange
            _volunteerController = GetVolunteerController();

            int testId = 12;

            var newVolunteer = new Volunteer() { FirstName = "TestName5", Surname = "TestSurname5", AssistanceType = AssistanceType.TakingAnAnimal, Email = "test@gmail.com" };

            _volunteersServices.Setup(x => x.GetById(It.IsAny<int>())).Returns(Task.FromResult(newVolunteer));

            //act

            var resalt = await _volunteerController.GetVolunteerById(testId);

            //assert
            _volunteersServices.Verify(x => x.GetById(testId), Times.Once);
        }

        [TestMethod]
        public void DeleteVolunteer_ServisesReturnNull_VerifyNullException()
        {
            //arrange
            _volunteerController = GetVolunteerController();
            //act
            _volunteersServices.Setup(x => x.DeleteByID(It.IsAny<int>())).Returns(Task.FromResult<Volunteer>(null));
            //assert
            Assert.ThrowsExceptionAsync<NullReferenceException>(() => _volunteerController.DeleteVolunteer(It.IsAny<int>()));
        }
    }
}
