using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using AGL.PetOwner.API.Controllers;
using AGL.PetOwner.BusinessLogic;
using NSubstitute;
using System.Net.Http;
using AGL.PetOwner.API.Tests.TestData;
using System.Web.Http;

namespace AGL.PetOwner.API.Tests.Controllers
{
    public class PetOwnerControllerTest
    {
        private readonly IPetOwnerService petOwnerService;

        public PetOwnerControllerTest()
        {
            petOwnerService = Substitute.For<IPetOwnerService>();
        }

        [Fact]
        public void GetPetsByOwnerGenderNotNull()
        {
            // Arrange
            var mockProvider = new PetOwnerTestData();
            var mockRepository = Substitute.For<PetOwner.BusinessLogic.IPetOwnerService>();
            mockRepository.GetPetOwnerDetails("cat").Returns(mockProvider.GetMockPetsByOwnerGender());
            var controller = new PetOwnerController(petOwnerService);

            // Act
            var result = controller.GetPetsByOwnerGender();

            // Assert
            AssertLibrary.Assert.IsNotNull(result);
        } 
    }
}
