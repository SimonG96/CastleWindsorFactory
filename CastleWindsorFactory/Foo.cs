using System.Threading.Tasks;
using CastleWindsorFactory.Factories;
using CastleWindsorFactory.Interfaces;

namespace CastleWindsorFactory
{
    public class Foo : IFoo
    {
        public Foo(IBarFactory barFactory, IAsyncClassFactory asyncClassFactory)
        {
            string name = "This is from Foo";
            Bar = barFactory.Create(name);

            Task.Run(async () =>
            {
                ClassAsync = asyncClassFactory.Create(Bar);
                await ClassAsync.InitializeAsync();
            }).Wait();
        }

        public IBar Bar { get; set; }
        public IAsyncClass ClassAsync { get; private set; }
    }
}