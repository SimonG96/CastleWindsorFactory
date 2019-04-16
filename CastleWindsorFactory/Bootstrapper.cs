using System.Linq;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.ModelBuilder.Inspectors;
using Castle.Windsor;
using CastleWindsorFactory.Installers;

namespace CastleWindsorFactory
{
    public class Bootstrapper
    {
        public IWindsorContainer BootstrapContainer()
        {
            WindsorContainer kernel = new WindsorContainer();
            kernel.AddFacility<TypedFactoryFacility>();

            //disable property injection, only constructor injection is allowed
            PropertiesDependenciesModelInspector propertyInjector = kernel.Kernel.ComponentModelBuilder.Contributors.OfType<PropertiesDependenciesModelInspector>().Single();
            kernel.Kernel.ComponentModelBuilder.RemoveContributor(propertyInjector);

            return kernel.Install(new Installer(),
                new FooInstaller(),
                new BarInstaller()
            );
        }
    }
}