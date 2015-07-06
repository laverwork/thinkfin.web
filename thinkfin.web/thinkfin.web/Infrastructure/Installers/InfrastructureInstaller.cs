using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using thinkfin.web.Infrastructure.Caching;
using thinkfin.web.Infrastructure.Mappers;

namespace thinkfin.web.Infrastructure.Installers
{
    public class InfrastructureInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Mappers.Mappers.Init();
            container.Register(Component.For<ICache>().ImplementedBy<InMemoryCache>());
            container.Register(Component.For<IMapper>().ImplementedBy<Mapper>());
        }
    }
}