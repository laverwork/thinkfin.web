using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using thinkfin.web.Queries;
using thinkfin.web.Services;

namespace thinkfin.web.Infrastructure.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IGetCompaniesQuery>().ImplementedBy<GetCompaniesQuery>());
            container.Register(Component.For<ICompaniesService>().ImplementedBy<CompaniesService>());
        }
    }
}