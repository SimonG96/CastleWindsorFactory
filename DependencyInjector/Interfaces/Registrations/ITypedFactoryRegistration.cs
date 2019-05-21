// Author: simon.gockner
// Created: 2019-05-20
// Copyright(c) 2019 SimonG. All Rights Reserved.

using System;
using DependencyInjector.Interfaces.Factories;

namespace DependencyInjector.Interfaces.Registrations
{
    public interface ITypedFactoryRegistration<TFactory> : IRegistrationBase
    {
        ITypedFactory<TFactory> Factory { get; }
    }
}