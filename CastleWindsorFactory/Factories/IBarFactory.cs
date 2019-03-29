using CastleWindsorFactory.Interfaces;

namespace CastleWindsorFactory.Factories
{
    public interface IBarFactory
    {
        IBar Create(string name);

        void Release(IBar bar);
    }
}