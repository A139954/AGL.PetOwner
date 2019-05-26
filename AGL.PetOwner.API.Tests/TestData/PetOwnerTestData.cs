using AGL.PetOwner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGL.PetOwner.API.Tests.TestData
{
    public class PetOwnerTestData
    {
        #region Gender Pets

        public List<Pet> GetMaleMockPetResult()
        {
            return new List<Pet>
            {
                new Pet { Name = "Garfield", Type = "Cat" },
                new Pet { Name = "Fido", Type = "Dog" },
                new Pet { Name = "Tom", Type = "Cat" },
                new Pet { Name = "Simba", Type = "Cat" },
                new Pet { Name = "Nemo", Type = "Fish" },
                new Pet { Name = "Sam", Type = "Dog" },
                new Pet { Name = "Garfield", Type = "Cat" }
            };
        }

        public List<Pet> GetFemaleMockPetResult()
        {
            return new List<Pet>
            {
                new Pet { Name = "Rosy", Type = "Cat" },
                new Pet { Name = "Fido", Type = "Dog" },
                new Pet { Name = "Lucy", Type = "Cat" },
                new Pet { Name = "Sweetie", Type = "Cat" },
                new Pet { Name = "Nemo", Type = "Fish" },
                new Pet { Name = "Sam", Type = "Dog" },
                new Pet { Name = "Rosy", Type = "Cat" }
            };
        }
        #endregion

        #region PetOwner Setup
        public List<Owner> GetMockPetOwnerResult()
        {
            return new List<Owner>
            {
                new Owner { Name = "Bob", Gender = "Male", Age = 23, Pets = GetMaleMockPetResult() },
                new Owner { Name = "Jennifer", Gender = "Female", Age = 18, Pets = GetFemaleMockPetResult() }
            };
        }

        public List<Owner> GetMockPetOwnerSingleNullPetArrayResult()
        {
            return new List<Owner>
            {
                new Owner { Name = "Bob", Gender = "Male", Age = 23, Pets = null },
                new Owner { Name = "Jennifer", Gender = "Female" , Age = 18, Pets = GetFemaleMockPetResult() }
            };
        }

        public List<Owner> GetMockPetOwnerBothNullPetArrayResult()
        {
            return new List<Owner>
            {
                new Owner { Name = "Bob", Gender = "Male", Age = 23, Pets = null },
                new Owner { Name = "Jennifer", Gender = "Female", Age = 18, Pets = null }
            };
        }

        #endregion

        #region Mock PetGroup Setup
        public List<PetsByOwnerGender> GetMockPetGroup()
        {
            return new List<PetsByOwnerGender>
            {
                new PetsByOwnerGender { OwnerGen = "Male", PetNames = new List<string> { "Garfield", "Simba", "Tom" } },
                new PetsByOwnerGender { OwnerGen = "Female", PetNames = new List<string> { "Lucy", "Rosy", "Sweetie" } },
            };
        }

        public List<PetsByOwnerGender> GetMockPetGroupWithError()
        {
            return new List<PetsByOwnerGender>
            {
                new PetsByOwnerGender { OwnerGen = "Male", PetNames = null },
                new PetsByOwnerGender { OwnerGen = "Female", PetNames = null },
            };
        }
        public List<PetsByOwnerGender> GetMockPetGroupWithNull()
        {
            return null;
        }
        #endregion

    }
}
