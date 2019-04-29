using System.Threading.Tasks;

namespace CastleWindsorFactory.Interfaces
{
    public interface IAsyncClass
    {
        Task InitializeAsync();

        string Name { get; }
        IService Service { get; }
        IBar Bar { get; }
    }
}
