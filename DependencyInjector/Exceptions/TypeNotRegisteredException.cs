// Author: simon.gockner
// Created: 2019-05-21
// Copyright(c) 2019 SimonG. All Rights Reserved.

using System;

namespace DependencyInjector.Exceptions
{
    public class TypeNotRegisteredException : Exception
    {
        public TypeNotRegisteredException(Type type)
            : base($"Type {type.Name} is not registered in this InjectorContainer.")
        {
            Type = type;
        }

        public Type Type { get; }
    }
}