using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CastleWindsorFactory.Factories;
using CastleWindsorFactory.Interfaces;

namespace CastleWindsorFactory.Installers
{
    public class BarInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IBar>().ImplementedBy<Bar>().LifestyleTransient());

            //factories
            container.Register(Component.For<IBarFactory>().AsFactory(f => f.SelectedWith<FactoryComponentSelector>()));
        }
    }
}