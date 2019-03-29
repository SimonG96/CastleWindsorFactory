using CastleWindsorFactory.Interfaces;

namespace CastleWindsorFactory.Factories
{
    public interface IAsyncClassFactory
    {
        IAsyncClass Create(IBar bar);

        void Release(IAsyncClass asyncClass);
    }
}