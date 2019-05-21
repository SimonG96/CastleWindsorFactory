using System.Linq;
using CastleWindsorFactory.Installers;
using DependencyInjector;
using DependencyInjector.Interfaces;

namespace CastleWindsorFactory
{
    public class Bootstrapper
    {
        public IInjectorContainer BootstrapContainer()
        {
            InjectorContainer kernel = new InjectorContainer();
            //kernel.AddFacility<TypedFactoryFacility>();

            //TODO: disable property injection, only constructor injection is allowed
            //PropertiesDependenciesModelInspector propertyInjector = kernel.Kernel.ComponentModelBuilder.Contributors.OfType<PropertiesDependenciesModelInspector>().Single();
            //kernel.Kernel.ComponentModelBuilder.RemoveContributor(propertyInjector);

            return kernel.Install(new Installer(),
                new FooInstaller(),
                new BarInstaller()
            );
        }
    }
}