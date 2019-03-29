using System;
using Castle.Windsor;
using CastleWindsorFactory.Factories;
using CastleWindsorFactory.Interfaces;

namespace CastleWindsorFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper bootstrapper = new Bootstrapper();
            IWindsorContainer kernel = bootstrapper.BootstrapperContainer();

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
