// Author: simon.gockner
// Created: 2019-05-20
// Copyright(c) 2019 SimonG. All Rights Reserved.

using System;

namespace DependencyInjector.Interfaces.Registrations
{
    public interface IDefaultRegistration : IRegistrationBase
    {
        Type ImplementationType { get; }

        Lifestyle Lifestyle { get; }
    }
}