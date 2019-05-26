using System;
using System.Collections.Generic;
using AGL.PetOwner.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGL.PetOwner.DataAccess
{
    public interface IPetOwnerRepository
    {
        IEnumerable<Owner> GetPetOwnerDetails();
    }
}
