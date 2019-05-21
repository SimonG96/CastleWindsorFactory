using CastleWindsorFactory.Factories;
using CastleWindsorFactory.Interfaces;
using DependencyInjector;
using DependencyInjector.Interfaces;
using DependencyInjector.Registrations;

namespace CastleWindsorFactory.Installers
{
    public class Installer : IInjectorInstaller
    {
        public void Install(IInjectorContainer container)
        {
            container.Register(RegistrationFactory.Register<IAsyncClass, AsyncClass>());
            container.Register(RegistrationFactory.Register<IService, Service>(Lifestyle.Singleton));

            //factories
            container.Register(RegistrationFactory.RegisterFactory<IAsyncClassFactory>());

            //component selector
            //container.Register(Component.For<FactoryComponentSelector, ITypedFactoryComponentSelector>());
        }
    }
}
