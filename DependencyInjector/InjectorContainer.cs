﻿// Author: simon.gockner
// Created: 2019-05-20
// Copyright(c) 2019 SimonG. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using DependencyInjector.Exceptions;
using DependencyInjector.Interfaces;
using DependencyInjector.Interfaces.Registrations;

namespace DependencyInjector
{
    public class InjectorContainer : IInjectorContainer
    {
        private readonly List<IRegistrationBase> _registrations = new List<IRegistrationBase>();
        private readonly List<(Type type, object instance)> _singletons = new List<(Type, object)>(); //TODO: Think about the usage of ConditionalWeakTable<>

        /// <summary>
        /// Install the given installers for the current <see cref="InjectorContainer"/>
        /// </summary>
        /// <param name="installers">The given installers</param>
        /// <returns>An instance of the current <see cref="InjectorContainer"/></returns>
        public IInjectorContainer Install(params IInjectorInstaller[] installers)
        {
            foreach (var installer in installers)
            {
                installer.Install(this);
            }

            return this;
        }

        /// <summary>
        /// Add the <see cref="IRegistrationBase"/> to the the <see cref="InjectorContainer"/>
        /// </summary>
        /// <param name="registration">The registration</param>
        public void Register(IRegistrationBase registration)
        {
            _registrations.Add(registration);
        }

        /// <summary>
        /// Gets an instance of the given type
        /// </summary>
        /// <typeparam name="T">The given type</typeparam>
        /// <returns>An instance of the given type</returns>
        public T Resolve<T>()
        {
            return ResolveInternal<T>();
        }
        
        /// <summary>
        /// Gets an instance of a given registered type
        /// </summary>
        /// <typeparam name="T">The registered type</typeparam>
        /// <returns>An instance of the given registered type</returns>
        /// <exception cref="TypeNotRegisteredException">The given type is not registered in this <see cref="InjectorContainer"/></exception>
        /// <exception cref="UnknownRegistrationException">The registration for the given type has an unknown type</exception>
        private T ResolveInternal<T>()
        {
            IRegistrationBase registration = _registrations.FirstOrDefault(r => r.InterfaceType == typeof(T));
            if (registration == null)
                throw new TypeNotRegisteredException(typeof(T));

            if (registration is IDefaultRegistration defaultRegistration)
            {
                if (defaultRegistration.Lifestyle == Lifestyle.Singleton)
                    return GetOrCreateSingletonInstance<T>(defaultRegistration);

                return CreateInstance<T>(defaultRegistration);
            }
            else if (registration is ITypedFactoryRegistration<T> typedFactoryRegistration)
            {
                return typedFactoryRegistration.Factory.Factory;
            }
            else
                throw new UnknownRegistrationException($"There is no registration of type {registration.GetType().Name}.");
        }

        /// <summary>
        /// Gets or creates a singleton instance of a given type
        /// </summary>
        /// <typeparam name="T">The given type</typeparam>
        /// <param name="registration">The registration of the given type</param>
        /// <returns>An existing or newly created singleton instance of the given type</returns>
        private T GetOrCreateSingletonInstance<T>(IDefaultRegistration registration)
        {
            //if a singleton instance exists return it
            object instance = _singletons.FirstOrDefault(s => s.type == typeof(T)).instance;
            if (instance != null)
                return (T) instance;

            //if it doesn't already exist create a new instance and add it to the list
            T newInstance = CreateInstance<T>(registration);
            _singletons.Add((typeof(T), newInstance));

            return newInstance;
        }

        /// <summary>
        /// Creates an instance of a given type
        /// </summary>
        /// <typeparam name="T">The given type</typeparam>
        /// <param name="registration">The registration of the given type</param>
        /// <returns>A newly created instance of the given type</returns>
        private T CreateInstance<T>(IDefaultRegistration registration)
        {
            return (T) Activator.CreateInstance(registration.ImplementationType);
        }
        
        public void Dispose()
        {

        }
    }
}