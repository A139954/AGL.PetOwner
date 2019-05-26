using AGL.PetOwner.DataAccess;
using System.Linq;
using Xunit;

namespace AGL.PetOwner.API.Tests.DataAccess
{
    public class PetOwnerDataAccessTest
    {
        public PetOwnerDataAccessTest()
        {

        }
        [Fact]
        public void GetPetsByOwnerGenderNotNull()
        {
            // Arrange
            var petRepository = new PetOwnerRepository();
            // Act
            var result = petRepository.GetPetOwnerDetails();
            // Assert
            AssertLibrary.Assert.IsNotNull(result);
            AssertLibrary.Assert.IsEqual(result.Count(), 6);
        }
    }
} 