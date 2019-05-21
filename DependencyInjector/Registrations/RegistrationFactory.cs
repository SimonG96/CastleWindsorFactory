// Author: simon.gockner
// Created: 2019-05-20
// Copyright(c) 2019 SimonG. All Rights Reserved.

using DependencyInjector.Interfaces.Registrations;

namespace DependencyInjector.Registrations
{
    public static class RegistrationFactory
    {
        public static IDefaultRegistration Register<TInterface, TImplementation>(Lifestyle lifestyle = Lifestyle.Transient) where TImplementation : TInterface
        {
            return new DefaultRegistration(typeof(TInterface), typeof(TImplementation), lifestyle);
        }

        public static ITypedFactoryRegistration<TFactory> RegisterFactory<TFactory>()
        {
            return new TypedFactoryRegistration<TFactory>(typeof(TFactory));
        }
    }
}