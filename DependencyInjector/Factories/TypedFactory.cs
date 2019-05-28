// Author: simon.gockner
// Created: 2019-05-20
// Copyright(c) 2019 SimonG. All Rights Reserved.

using DependencyInjector.Interfaces.Factories;

namespace DependencyInjector.Factories
{
    public class TypedFactory<TFactory> : ITypedFactory<TFactory>
    {
        public TFactory Factory { get; set; }
    }
}