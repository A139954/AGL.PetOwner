using AGL.PetOwner.BusinessLogic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AGL.PetOwner.API.Controllers
{
    public class PetOwnerController : ApiController
    {
        private readonly IPetOwnerService _petOwnerService;

        public PetOwnerController(IPetOwnerService petOwnerService)
        {
            this._petOwnerService = petOwnerService;
        }

        [HttpGet, Route("api/petsbyownergender")] 
        public HttpResponseMessage GetPetsByOwnerGender()
        {
            var result = _petOwnerService.GetPetOwnerDetails("Cat"); 
            return Request.CreateResponse(HttpStatusCode.OK, result); 
        }
    }
}
