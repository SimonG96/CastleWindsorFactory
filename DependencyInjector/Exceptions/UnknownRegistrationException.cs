// Author: simon.gockner
// Created: 2019-05-21
// Copyright(c) 2019 SimonG. All Rights Reserved.

using System;
using DependencyInjector.Interfaces.Registrations;

namespace DependencyInjector.Exceptions
{
    /// <summary>
    /// An unknown <see cref="IRegistrationBase"/> was used
    /// </summary>
    public class UnknownRegistrationException : Exception
    {
        public UnknownRegistrationException(string message)
            : base(message)
        {

        }
    }
}