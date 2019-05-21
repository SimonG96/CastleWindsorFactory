using CastleWindsorFactory.Factories;
using CastleWindsorFactory.Interfaces;
using DependencyInjector.Interfaces;
using DependencyInjector.Registrations;

namespace CastleWindsorFactory.Installers
{
    public class FooInstaller : IInjectorInstaller
    {
        public void Install(IInjectorContainer container)
        {
            container.Register(RegistrationFactory.Register<IFoo, Foo>());

            //factories
            container.Register(RegistrationFactory.RegisterFactory<IFooFactory>());
        }
    }
}