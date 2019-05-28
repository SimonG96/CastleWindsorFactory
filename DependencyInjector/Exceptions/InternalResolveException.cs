// Author: simon.gockner
// Created: 2019-05-27
// Copyright(c) 2019 SimonG. All Rights Reserved.

using System;

namespace DependencyInjector.Exceptions
{
    public class InternalResolveException : Exception
    {
        public InternalResolveException(string message)
            : base(message)
        {

        }
    }
}