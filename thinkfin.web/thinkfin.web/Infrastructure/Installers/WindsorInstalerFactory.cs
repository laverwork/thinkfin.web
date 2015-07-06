using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Facilities.Logging;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace thinkfin.web.Infrastructure.Installers
{
    public class WindsorInstalerFactory : InstallerFactory
    {
        public override IEnumerable<Type> Select(IEnumerable<Type> installerTypes)
        {
            var windsorInfrastructureInstaller = installerTypes.FirstOrDefault(it => it == typeof(WindsorInfrastructureInstaller));

            var retVal = new List<Type>();
            retVal.Add(windsorInfrastructureInstaller);
            retVal.AddRange(installerTypes.Where(it => (it != typeof(WindsorInfrastructureInstaller) && (typeof(IWindsorInstaller).IsAssignableFrom(it)))));

            return retVal;
        }
    }

    public class WindsorInfrastructureInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Members

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();
            container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.Log4net).WithAppConfig());
        }
        #endregion
    }
}