// Author: simon.gockner
// Created: 2019-05-20
// Copyright(c) 2019 SimonG. All Rights Reserved.

using System;
using System.Linq;
using DependencyInjector.Exceptions;
using DependencyInjector.Factories;
using DependencyInjector.Interfaces.Factories;
using DependencyInjector.Interfaces.Registrations;

namespace DependencyInjector.Registrations
{
    public class TypedFactoryRegistration<TFactory> : ITypedFactoryRegistration<TFactory>
    {
        public TypedFactoryRegistration(Type factoryType)
        {
            InterfaceType = factoryType;
            Name = $"{InterfaceType.Name}";

            CreateFactory();
        }

        public string Name { get; }

        public Type InterfaceType { get; }
        public ITypedFactory<TFactory> Factory { get; private set; }


        /// <summary>
        /// Creates the factory from the given abstract factory type
        /// </summary>
        /// <exception cref="InvalidFactoryRegistrationException">Factory registration is invalid</exception>
        private void CreateFactory() //TODO
        {
            var createMethods = InterfaceType.GetMethods().Where(m => m.ReturnType != typeof(void));
            if (!createMethods.Any())
                throw new InvalidFactoryRegistrationException($"Factory {Name} has no create methods.");

            Type type = typeof(TypedFactory<>);
            Type factory = type.MakeGenericType(InterfaceType);

            Factory = (ITypedFactory<TFactory>) Activator.CreateInstance(factory);
        }
    }
}