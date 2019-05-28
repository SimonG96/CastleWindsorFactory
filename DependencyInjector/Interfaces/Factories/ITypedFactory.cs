// Author: simon.gockner
// Created: 2019-05-20
// Copyright(c) 2019 SimonG. All Rights Reserved.

namespace DependencyInjector.Interfaces.Factories
{
    public interface ITypedFactory<TFactory>
    {
        TFactory Factory { get; set; }
    }
}