using CastleWindsorFactory.Factories;
using CastleWindsorFactory.Interfaces;
using DependencyInjector.Interfaces;
using DependencyInjector.Registrations;

namespace CastleWindsorFactory.Installers
{
    public class BarInstaller : IInjectorInstaller
    {
        public void Install(IInjectorContainer container)
        {
            container.Register(RegistrationFactory.Register<IBar, Bar>());

            //factories
            container.Register(RegistrationFactory.RegisterFactory<IBarFactory>(container));
        }
    }
}