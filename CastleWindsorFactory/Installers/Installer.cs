using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CastleWindsorFactory.Factories;
using CastleWindsorFactory.Interfaces;

namespace CastleWindsorFactory.Installers
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IAsyncClass>().ImplementedBy<AsyncClass>().LifestyleTransient());
            container.Register(Component.For<IService>().ImplementedBy<Service>().LifestyleSingleton());

            //factories
            container.Register(Component.For<IAsyncClassFactory>().AsFactory());

            //component selector
            container.Register(Component.For<FactoryComponentSelector, ITypedFactoryComponentSelector>());
        }
    }
}
