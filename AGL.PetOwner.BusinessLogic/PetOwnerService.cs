using AGL.PetOwner.DataAccess;
using AGL.PetOwner.Models;
using AGL.PetOwner.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AGL.PetOwner.BusinessLogic
{
    public class PetOwnerService : IPetOwnerService
    {
        private IPetOwnerRepository _petOwnerRepository;

        public PetOwnerService(IPetOwnerRepository petOwnerRepository)
        {
            _petOwnerRepository = petOwnerRepository;
        }

        public  IEnumerable<PetsByOwnerGender> GetPetOwnerDetails(string petType)
        {
            List<PetsByOwnerGender> _petsByOwnerGender = null;
            try
            {
                Logger.Info(petType);
                List<Owner> lstOwners = _petOwnerRepository.GetPetOwnerDetails().ToList();
                if (lstOwners.Count > 0)
                {
                    _petsByOwnerGender = new List<PetsByOwnerGender>();
                    var lstFilteredOwner = from owner in lstOwners
                                           where !string.IsNullOrEmpty(owner.Gender) && owner.Pets != null && owner.Pets.Count > 0
                                           select owner;

                    _petsByOwnerGender = lstFilteredOwner.GroupBy(x => x.Gender)
                                        .Select(x => new PetsByOwnerGender
                                        {
                                            OwnerGen = x.Key,
                                            PetNames = x.SelectMany(y => y.Pets)
                                                        .Where(p => !string.IsNullOrEmpty(p.Type) && !string.IsNullOrEmpty(p.Name)
                                                         && petType == p.Type)
                                                         .Select(c => c.Name)
                                                         .Distinct()
                                                         .OrderBy(c => c)
                                                         .ToList()
                                        }).ToList<PetsByOwnerGender>();
                }
            }
            catch (Exception ex)
            {
                Logger.HandleException(ex);
                throw;
            }
            return _petsByOwnerGender;
        }
    }
}
