using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Lifestyle.Scoped;

namespace CastleWindsorFactory
{
    public class MultitonScopeAccessor<TScope> : IScopeAccessor where TScope : class
    {
        private static readonly ConditionalWeakTable<TScope, ILifetimeScope> _instances = new ConditionalWeakTable<TScope, ILifetimeScope>();
        private static readonly object _instancesLockObject = new object();

        /// <summary>
        /// Gets the scope of the resolving object -> if an instance for <see cref="TScope"/> is already created return this, otherwise create a new instance
        /// </summary>
        /// <param name="context">The <see cref="CreationContext"/></param>
        /// <returns>The existing instance or a new instance if none exists</returns>
        /// <exception cref="ArgumentException">If no additional arguments are given</exception>
        public ILifetimeScope GetScope(CreationContext context)
        {
            if (!context.HasAdditionalArguments)
                throw new ArgumentException("No additional arguments given.");

            var keyValuePair = context.AdditionalArguments.ToList().First();
            if (!(keyValuePair.Value is TScope scope))
                throw new ArgumentException($"First additional argument is not of type {typeof(TScope)} (Type: {context.AdditionalArguments[0].GetType()}).");

            lock (_instancesLockObject)
            {
                if (_instances.TryGetValue(scope, out ILifetimeScope lifetimeScope))
                    return lifetimeScope;

                lifetimeScope = new DefaultLifetimeScope();
                _instances.Add(scope, lifetimeScope);

                return lifetimeScope;
            }
        }


        public void Dispose()
        {

        }
    }
}