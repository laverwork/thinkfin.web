using System;
using System.Web.Mvc;
using Castle.MicroKernel;
using Castle.Windsor;
using thinkfin.web.Infrastructure.Installers;
using Xunit;

namespace thinkfin.web.tests.IoC
{
    public class ControllersInstallerTests
    {
        private IWindsorContainer containerWithControllers;

        public ControllersInstallerTests()
        {
            containerWithControllers = new WindsorContainer()
                .Install(new ControllersInstaller());
        }

        private IHandler[] GetAllHandlers(IWindsorContainer container)
        {
            return GetHandlersFor(typeof(object), container);
        }

        private IHandler[] GetHandlersFor(Type type, IWindsorContainer container)
        {
            return container.Kernel.GetAssignableHandlers(type);
        }

        [Fact]
        public void ShouldImplementIController()
        {
            var allHandlers = GetAllHandlers(containerWithControllers);
            var controllerHandlers = GetHandlersFor(typeof(IController), containerWithControllers);

            Assert.NotEmpty(allHandlers);
            Assert.Equal(allHandlers, controllerHandlers);
        }

        [Fact]
        public void AllControllersAreRegistered()
        {
            
        }

    }
}
