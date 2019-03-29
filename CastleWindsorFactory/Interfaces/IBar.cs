namespace CastleWindsorFactory.Interfaces
{
    public interface IBar
    {
        string Name { get; }
        IService Service { get; }
    }
}