using System.Threading.Tasks;
using CastleWindsorFactory.Interfaces;

namespace CastleWindsorFactory
{
    public class AsyncClass : IAsyncClass
    {
        private bool _isInitialized;

        public AsyncClass(IService service, IBar bar)
        {
            Service = service;
            Bar = bar;
        }

        public async Task InitializeAsync()
        {
            await Task.Run(async () =>
            {
                await Task.Delay(1000);
                Name = "AsyncName";
                _isInitialized = true;
            });
        }

        public string Name { get; private set; }
        public IService Service { get; }
        public IBar Bar { get; }
    }
}