using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using thinkfin.web.Infrastructure.DependencyResolvers;
using thinkfin.web.Infrastructure.Installers;

namespace thinkfin.web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BootstrapContainer();

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorCompositionRoot(_container));
        }

        protected void Application_End()
        {
            _container.Dispose();
        }

        private static void BootstrapContainer()
        {
            _container = new WindsorContainer().Install(
                new InfrastructureInstaller(),
                new LoggerInstaller(),
                new ServiceInstaller(),
                new ControllersInstaller());
                
            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
