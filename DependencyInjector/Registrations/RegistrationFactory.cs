// Author: simon.gockner
// Created: 2019-05-20
// Copyright(c) 2019 SimonG. All Rights Reserved.

using DependencyInjector.Interfaces;
using DependencyInjector.Interfaces.Registrations;

namespace DependencyInjector.Registrations
{
    public static class RegistrationFactory
    {
        public static IDefaultRegistration<TInterface> Register<TInterface, TImplementation>(Lifestyle lifestyle = Lifestyle.Transient) where TImplementation : TInterface
        {
            return new DefaultRegistration<TInterface>(typeof(TInterface), typeof(TImplementation), lifestyle);
        }

        public static ITypedFactoryRegistration<TFactory> RegisterFactory<TFactory>(IInjectorContainer container) //TODO: Find a nicer way to inject the container into `TypedFactoryRegistration`
        {
            return new TypedFactoryRegistration<TFactory>(typeof(TFactory), container);
        }
    }
}