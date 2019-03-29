using System.Collections.Generic;
using System.Reflection;
using Castle.MicroKernel;
using CastleWindsorFactory;
using Moq;
using NUnit.Framework;

namespace Test.CastleWindsorFactory
{
    [TestFixture]
    public class FactoryComponentSelectorTest
    {
        [Test]
        public void TestGetArguments()
        {
            var param1Mock = new Mock<ParameterInfo>();
            param1Mock.Setup(p => p.ParameterType).Returns(typeof(string));
            param1Mock.Setup(p => p.Name).Returns("OneString");

            var param2Mock = new Mock<ParameterInfo>();
            param2Mock.Setup(p => p.ParameterType).Returns(typeof(int));
            param2Mock.Setup(p => p.Name).Returns("SignedInt");

            var param3Mock = new Mock<ParameterInfo>();
            param3Mock.Setup(p => p.ParameterType).Returns(typeof(uint));
            param3Mock.Setup(p => p.Name).Returns("UnsignedInt");

            var param4Mock = new Mock<ParameterInfo>();
            param4Mock.Setup(p => p.ParameterType).Returns(typeof(string));
            param4Mock.Setup(p => p.Name).Returns("AnotherString");

            List<ParameterInfo> parameters = new List<ParameterInfo>()
            {
                param1Mock.Object,
                param2Mock.Object,
                param3Mock.Object,
                param4Mock.Object
            };

            Mock<MethodInfo> methodInfoMock = new Mock<MethodInfo>();
            methodInfoMock.Setup(m => m.GetParameters()).Returns(parameters.ToArray);

            FactoryComponentSelectorWrapper componentSelector = new FactoryComponentSelectorWrapper();
            Arguments arguments = componentSelector.GetArgumentsWrapper(methodInfoMock.Object, new object[] { "String", -1, 5, "Name" });

            Arguments argumentMap = new Arguments()
            {
                {"OneString", "String"},
                {typeof(int), -1},
                {typeof(uint), 5},
                {"AnotherString", "Name"}
            };

            Assert.AreEqual(argumentMap, arguments);
        }
    }


    internal class FactoryComponentSelectorWrapper : FactoryComponentSelector
    {
        internal Arguments GetArgumentsWrapper(MethodInfo method, object[] arguments)
        {
            return base.GetArguments(method, arguments);
        }
    }
}
