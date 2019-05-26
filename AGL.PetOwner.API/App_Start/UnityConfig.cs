using AGL.PetOwner.BusinessLogic;
using AGL.PetOwner.DataAccess;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace AGL.PetOwner.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();  
            container.RegisterType<IPetOwnerRepository, PetOwnerRepository>();
            container.RegisterType<IPetOwnerService, PetOwnerService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}