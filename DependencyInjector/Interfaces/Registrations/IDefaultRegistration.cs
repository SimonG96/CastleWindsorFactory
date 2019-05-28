// Author: simon.gockner
// Created: 2019-05-20
// Copyright(c) 2019 SimonG. All Rights Reserved.

using System;

namespace DependencyInjector.Interfaces.Registrations
{
    public interface IDefaultRegistration<TInterface> : IRegistrationBase
    {
        Type ImplementationType { get; }

        Lifestyle Lifestyle { get; }

        Action<TInterface> OnCreateAction { get; }

        /// <summary>
        /// Pass an action that will be invoked when an instance of this type is created
        /// </summary>
        /// <param name="action">The action</param>
        /// <returns>The current instance of this <see cref="IDefaultRegistration{TInterface}"/></returns>
        IDefaultRegistration<TInterface> OnCreate(Action<TInterface> action);
    }
}