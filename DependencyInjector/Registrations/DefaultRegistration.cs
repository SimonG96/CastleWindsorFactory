// Author: simon.gockner
// Created: 2019-05-20
// Copyright(c) 2019 SimonG. All Rights Reserved.

using System;
using DependencyInjector.Interfaces.Registrations;

namespace DependencyInjector.Registrations
{
    public class DefaultRegistration : IDefaultRegistration
    {
        public DefaultRegistration(Type interfaceType, Type implementationType, Lifestyle lifestyle)
        {
            InterfaceType = interfaceType;
            ImplementationType = implementationType;
            Lifestyle = lifestyle;

            Name = $"{InterfaceType.Name}, {ImplementationType.Name}, Lifestyle: {Lifestyle.ToString()}";
        }

        public string Name { get; }

        public Type InterfaceType { get; }
        public Type ImplementationType { get; }
        public Lifestyle Lifestyle { get; }
    }
}