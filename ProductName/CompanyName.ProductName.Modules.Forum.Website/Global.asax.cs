using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider;
using CompanyName.ProductName.Modules.Forum.Website.Controllers;
using EventBasedDDD;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace CompanyName.ProductName.Modules.Forum.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{handler}.ashx");
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(typeof(CommonServiceLocatorControllerFactory));

            IUnityContainer container = new UnityContainer();
            ((UnityConfigurationSection)ConfigurationManager.GetSection("unity")).Configure(container);
            UnityContainerHolder.UnityContainer = container;
            InstanceLocator.SetLocator(new ForumInstanceLocator());

            var eventSubscriberTypeMappingStore = EventSubscriberTypeMappingStore.Current;
            eventSubscriberTypeMappingStore.ResolveEventSubscriberTypeMappings(typeof(Group).Assembly);
            eventSubscriberTypeMappingStore.ResolveEventSubscriberTypeMappings(typeof(GroupCollection).Assembly);
        }
    }
}