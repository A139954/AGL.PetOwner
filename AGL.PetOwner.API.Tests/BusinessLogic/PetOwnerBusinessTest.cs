using AGL.PetOwner.API.Tests.TestData;
using AGL.PetOwner.DataAccess;
using System.Linq;
using NSubstitute;
using Xunit;
using AGL.PetOwner.BusinessLogic;

namespace AGL.PetOwner.API.Tests.BusinessLogic
{
    
    
    public class PetOwnerBusinessTest
    {

        public PetOwnerBusinessTest() { }

        [Fact]
        public void GetPetsByOwnerGenderNotNull()
        {
            // Arrange
            var mockProvider = new PetOwnerTestData();
            var mockRepository = Substitute.For<PetOwner.DataAccess.IPetOwnerRepository>();
            mockRepository.GetPetOwnerDetails().Returns(mockProvider.GetMockPetOwnerResult());
            var petService = new PetOwnerService(mockRepository);

            // Act
            var result = petService.GetPetOwnerDetails("Cat");

            // Assert
            AssertLibrary.Assert.IsNotNull(result);
        }

        [Fact]
        public void GetPetsByOwnerGenderGroupCount()
        {
            // Arrange
            var mockProvider = new PetOwnerTestData();
            var mockRepository = Substitute.For<IPetOwnerRepository>();
            mockRepository.GetPetOwnerDetails().Returns(mockProvider.GetMockPetOwnerResult());
            var petService = new PetOwnerService(mockRepository);

            //Act
            var result = petService.GetPetOwnerDetails("Cat").ToList();

            // Assert
            AssertLibrary.Assert.IsEqual(result.Count, 2);
        }

        [Fact]
        public void GetPetsByOwnerGenderEachGenderGroupAvailable()
        {
            // Arrange
            var mockProvider = new PetOwnerTestData();
            var mockRepository = Substitute.For<IPetOwnerRepository>();
            mockRepository.GetPetOwnerDetails().Returns(mockProvider.GetMockPetOwnerResult());
            var petService = new PetOwnerService(mockRepository);

            // Act
            var result = petService.GetPetOwnerDetails("Cat");

            // Assert
            AssertLibrary.Assert.IsNotNull(result);
            var petGroups = result.ToList();
            AssertLibrary.Assert.IsTrue(petGroups.Any(r => r.OwnerGen.Equals("Male", System.StringComparison.InvariantCultureIgnoreCase)));
            AssertLibrary.Assert.IsTrue(petGroups.Any(r => r.OwnerGen.Equals("Female", System.StringComparison.InvariantCultureIgnoreCase)));
        }

        [Fact]
        public void GetPetsByOwnerGenderGenderGroupCount()
        {
            // Arrange
            var mockProvider = new PetOwnerTestData();
            var mockRepository = Substitute.For<IPetOwnerRepository>();
            mockRepository.GetPetOwnerDetails().Returns(mockProvider.GetMockPetOwnerResult());
            var petService = new PetOwnerService(mockRepository);

            // Act
            var result = petService.GetPetOwnerDetails("Cat");

            // Assert
            AssertLibrary.Assert.IsEqual(result.Count(r => r.OwnerGen.Equals("Male", System.StringComparison.InvariantCultureIgnoreCase)), 1);
            AssertLibrary.Assert.IsEqual(result.Count(r => r.OwnerGen.Equals("Female", System.StringComparison.InvariantCultureIgnoreCase)), 1);
        }

        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [Theory]
        public void TestOrderSequenceOfPetsForMaleOwner(int index)
        {
            // Arrange
            var mockProvider = new PetOwnerTestData();
            var mockRepository = Substitute.For<IPetOwnerRepository>();
            mockRepository.GetPetOwnerDetails().Returns(mockProvider.GetMockPetOwnerResult());
            var petService = new PetOwnerService(mockRepository);

            // Act
            var result = petService.GetPetOwnerDetails("Cat");
            AssertLibrary.Assert.IsNotNull(result);
            var petNames = result.Where(r => r.OwnerGen.Equals("Male", System.StringComparison.InvariantCultureIgnoreCase)).SelectMany(p => p.PetNames);
            var expectedResult = mockProvider.GetMockPetGroup().Where(r => r.OwnerGen.Equals("Male", System.StringComparison.InvariantCultureIgnoreCase)).SelectMany(m => m.PetNames);

            // Assert
            AssertLibrary.Assert.IsEqual(petNames.ElementAt(index), expectedResult.ElementAt(index));
        }

        [Fact]
        public void TestEmptyPetListExistsForSingleGroup()
        {
            // Arrange
            var mockProvider = new PetOwnerTestData();
            var mockRepository = Substitute.For<IPetOwnerRepository>();
            mockRepository.GetPetOwnerDetails().Returns(mockProvider.GetMockPetOwnerSingleNullPetArrayResult());
            var petService = new PetOwnerService(mockRepository);

            // Act
            var result = petService.GetPetOwnerDetails("Cat");
            var maleGroupPetNames = result.Where(r => r.OwnerGen.Equals("Male", System.StringComparison.InvariantCultureIgnoreCase)).SelectMany(m => m.PetNames);

            // Assert
            AssertLibrary.Assert.IsEqual(maleGroupPetNames.Count(), 0);
        }

        [Fact]
        public void TestEmptyPetListExistsForAllGroup()
        {
            // Arrange
            var mockProvider = new PetOwnerTestData();
            var mockRepository = Substitute.For<IPetOwnerRepository>();
            mockRepository.GetPetOwnerDetails().Returns(mockProvider.GetMockPetOwnerBothNullPetArrayResult());
            var petService = new PetOwnerService(mockRepository);

            // Act
            var result = petService.GetPetOwnerDetails("Cat");
            var maleGroupPetNames = result.Where(r => r.OwnerGen.Equals("Male")).SelectMany(m => m.PetNames);
            var femaleGroupPetNames = result.Where(r => r.OwnerGen.Equals("Female")).SelectMany(m => m.PetNames);

            // Assert
            AssertLibrary.Assert.IsEqual(maleGroupPetNames.Count(), 0);
            AssertLibrary.Assert.IsEqual(femaleGroupPetNames.Count(), 0);
        }
    }
}
