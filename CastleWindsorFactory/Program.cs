using System;
using CastleWindsorFactory.Factories;
using CastleWindsorFactory.Interfaces;
using DependencyInjector.Interfaces;

namespace CastleWindsorFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper bootstrapper = new Bootstrapper();
            IInjectorContainer kernel = bootstrapper.BootstrapContainer();

            IService service = kernel.Resolve<IService>();
            IBar bar = kernel.Resolve<IBar>("test", service);

            IFooFactory fooFactory = kernel.Resolve<IFooFactory>();
            IFoo foo = fooFactory.Create();

            Console.WriteLine(foo.Bar.Name);
            Console.WriteLine(foo.Bar.Service.ServiceName);
            Console.WriteLine(foo.ClassAsync.Name);

            Console.ReadLine();
            kernel.Dispose();
        }
    }
}
