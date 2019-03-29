//  

using CastleWindsorFactory.Interfaces;

namespace CastleWindsorFactory.Factories
{
    public interface IFooFactory
    {
        IFoo Create();

        void Release(IFoo foo);
    }
}