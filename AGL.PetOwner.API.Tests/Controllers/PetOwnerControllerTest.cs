using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using AGL.PetOwner.API.Controllers;
using AGL.PetOwner.BusinessLogic;
using NSubstitute;
using System.Net.Http;

namespace AGL.PetOwner.API.Tests.Controllers
{
    public class PetOwnerControllerTest
    {
        private readonly IPetOwnerService petOwnerService;

        public PetOwnerControllerTest()
        {
            petOwnerService = Substitute.For<IPetOwnerService>();
        }
    }
}
