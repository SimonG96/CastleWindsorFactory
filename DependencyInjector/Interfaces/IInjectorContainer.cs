// Author: simon.gockner
// Created: 2019-05-20
// Copyright(c) 2019 SimonG. All Rights Reserved.

using System;
using DependencyInjector.Interfaces.Registrations;

namespace DependencyInjector.Interfaces
{
    public interface IInjectorContainer : IDisposable
    {
        /// <summary>
        /// Install the given installers for the current <see cref="IInjectorContainer"/>
        /// </summary>
        /// <param name="installers">The given installers</param>
        /// <returns>An instance of the current <see cref="IInjectorContainer"/></returns>
        IInjectorContainer Install(params IInjectorInstaller[] installers);

        /// <summary>
        /// Add the <see cref="IRegistrationBase"/> to the the <see cref="IInjectorContainer"/>
        /// </summary>
        /// <param name="registration">The registration</param>
        void Register(IRegistrationBase registration);

        /// <summary>
        /// Gets an instance of the given type
        /// </summary>
        /// <typeparam name="T">The given type</typeparam>
        /// <returns>An instance of the given type</returns>
        T Resolve<T>();
    }
}