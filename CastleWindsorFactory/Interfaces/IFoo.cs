namespace CastleWindsorFactory.Interfaces
{
    public interface IFoo
    {
        IBar Bar { get; set; }
        IAsyncClass ClassAsync { get; }
    }
}