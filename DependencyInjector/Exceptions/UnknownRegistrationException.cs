// Author: simon.gockner
// Created: 2019-05-21
// Copyright(c) 2019 SimonG. All Rights Reserved.

using System;

namespace DependencyInjector.Exceptions
{
    public class UnknownRegistrationException : Exception
    {
        public UnknownRegistrationException(string message)
            : base(message)
        {

        }
    }
}