using CastleWindsorFactory;
using CastleWindsorFactory.Interfaces;
using Moq;
using NUnit.Framework;

namespace Test.CastleWindsorFactory
{
    [TestFixture]
    public class BarTest
    {
        [OneTimeSetUp]
        public void InitializeFixture()
        {

        }

        [OneTimeTearDown]
        public void CleanUp()
        {

        }

        [Test]
        public void TestClassBResolve()
        {
            Mock<IService> serviceMock = new Mock<IService>();
            IBar bar = new Bar("This is Bar", serviceMock.Object);
            Assert.AreEqual("This is Bar", bar.Name);
        }
    }
}