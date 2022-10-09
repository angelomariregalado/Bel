using System.Web.Http;
using TaxJar.BusinessLayer;
using Unity;
using Unity.WebApi;

namespace Bel.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ITaxRateBl, TaxRateBl>();
            container.RegisterType<ISalesTaxBl, SalesTaxBl>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}