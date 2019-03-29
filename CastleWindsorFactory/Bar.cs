using CastleWindsorFactory.Interfaces;

namespace CastleWindsorFactory
{
    public class Bar : IBar
    {
        public Bar(string name, IService service)
        {
            Name = name;
            Service = service;
        }

        public Bar(IService service)
        {
            Name = "This is Bar";
            Service = service;
        }

        public Bar(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public IService Service { get; }
    }
}