// Author: simon.gockner
// Created: 2019-05-20
// Copyright(c) 2019 SimonG. All Rights Reserved.

using DependencyInjector.Interfaces.Factories;

namespace DependencyInjector.Interfaces.Registrations
{
    /// <summary>
    /// The registration that is used to register an abstract typed factory
    /// </summary>
    /// <typeparam name="TFactory">The type of the abstract typed factory</typeparam>
    public interface ITypedFactoryRegistration<TFactory> : IRegistrationBase
    {
        /// <summary>
        /// The class that contains the implemented abstract factory of this <see cref="ITypedFactoryRegistration{TFactory}"/>
        /// </summary>
        ITypedFactory<TFactory> Factory { get; }
    }
}