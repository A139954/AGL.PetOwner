using AGL.PetOwner.Models;
using System.Collections.Generic;

namespace AGL.PetOwner.BusinessLogic
{
    public interface IPetOwnerService
    {
        IEnumerable<PetsByOwnerGender> GetPetOwnerDetails(string petType);
    }
}
