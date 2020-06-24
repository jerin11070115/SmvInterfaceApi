using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using TestApi.Admin.App_Start;
using TestApi.Admin.Filter;
using Unity.WebApi;

namespace TestApi.Admin
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //var container = new UnityContainer();
            //container.RegisterType<ITestService, TestService>(new HierarchicalLifetimeManager());
            //container.RegisterType<ITestRepository, TestRepository>(new HierarchicalLifetimeManager());
            //config.DependencyResolver = new UnityResolver(container);
            config.Formatters.RemoveAt(0);
            config.Formatters.Insert(0, new JilFormatter());

            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());

            config.Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());

            //config.EnableCors();

            WebApiUnityActionFilterProvider.RegisterFilterProviders(config);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

}

