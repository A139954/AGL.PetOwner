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
            var mockService = Substitute.For<PetOwner.BusinessLogic.IPetOwnerService>();
            mockService.GetPetOwnerDetails("cat").Returns(mockProvider.GetMockPetsByOwnerGender());
            var controller = new PetOwnerController(mockService);

            // Act
            var result = controller.GetPetsByOwnerGender();

            // Assert
            AssertLibrary.Assert.IsNotNull(result);
        } 
    }
}
