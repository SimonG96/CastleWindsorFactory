using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel;

namespace CastleWindsorFactory
{
    public class FactoryComponentSelector : DefaultTypedFactoryComponentSelector
    {
        protected override Arguments GetArguments(MethodInfo method, object[] arguments)
        {
            if (arguments == null)
                return null;

            Arguments argumentMap = new Arguments();
            List<ParameterInfo> parameters = method.GetParameters().ToList();

            List<Type> types = parameters.Select(p => p.ParameterType).ToList();
            List<Type> duplicateTypes = types.Where(t => types.Count(type => type == t) > 1).ToList();

            foreach (var parameter in parameters)
            {
                if (duplicateTypes.Contains(parameter.ParameterType))
                    argumentMap.Add(parameter.Name, arguments[parameters.IndexOf(parameter)]);
                else
                    argumentMap.Add(parameter.ParameterType, arguments[parameters.IndexOf(parameter)]);
            }

            return argumentMap;
        }
    }
}