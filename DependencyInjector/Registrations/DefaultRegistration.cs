// Author: simon.gockner
// Created: 2019-05-20
// Copyright(c) 2019 SimonG. All Rights Reserved.

using System;
using DependencyInjector.Interfaces.Registrations;

namespace DependencyInjector.Registrations
{
    public class DefaultRegistration<TInterface> : IDefaultRegistration<TInterface>
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

        public Action<TInterface> OnCreateAction { get; private set; }


        /// <summary>
        /// Pass an action that will be invoked when an instance of this type is created
        /// </summary>
        /// <param name="action">The action</param>
        /// <returns>The current instance of this <see cref="IDefaultRegistration{TInterface}"/></returns>
        public IDefaultRegistration<TInterface> OnCreate(Action<TInterface> action)
        {
            OnCreateAction = action;
            return this;
        }
    }
}