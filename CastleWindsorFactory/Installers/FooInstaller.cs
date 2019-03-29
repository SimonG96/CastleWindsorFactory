using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CastleWindsorFactory.Factories;
using CastleWindsorFactory.Interfaces;

namespace CastleWindsorFactory.Installers
{
    public class FooInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IFoo>().ImplementedBy<Foo>().LifestyleTransient());

            //factories
            container.Register(Component.For<IFooFactory>().AsFactory(f => f.SelectedWith<FactoryComponentSelector>()));
        }
    }
}