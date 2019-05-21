// Author: simon.gockner
// Created: 2019-05-20
// Copyright(c) 2019 SimonG. All Rights Reserved.

using System;

namespace DependencyInjector.Exceptions
{
    public class InvalidRegistrationException : Exception
    {
        public InvalidRegistrationException(string message)
            : base(message)
        {

        }
    }
}