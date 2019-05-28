﻿// Author: simon.gockner
// Created: 2019-05-20
// Copyright(c) 2019 SimonG. All Rights Reserved.

using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using DependencyInjector.Exceptions;
using DependencyInjector.Factories;
using DependencyInjector.Interfaces;
using DependencyInjector.Interfaces.Factories;
using DependencyInjector.Interfaces.Registrations;

namespace DependencyInjector.Registrations
{
    public class TypedFactoryRegistration<TFactory> : ITypedFactoryRegistration<TFactory>
    {
        private readonly IInjectorContainer _container;

        public TypedFactoryRegistration(Type factoryType, IInjectorContainer container)
        {
            _container = container;

            InterfaceType = factoryType;
            Name = $"{InterfaceType.Name}";

            CreateFactory();
        }

        public string Name { get; }

        public Type InterfaceType { get; }
        public ITypedFactory<TFactory> Factory { get; private set; }


        /// <summary>
        /// Creates the factory from the given abstract factory type
        /// </summary>
        /// <exception cref="InvalidFactoryRegistrationException">Factory registration is invalid</exception>
        private void CreateFactory() //TODO
        {
            var createMethods = InterfaceType.GetMethods().Where(m => m.ReturnType != typeof(void)).ToList();
            if (!createMethods.Any())
                throw new InvalidFactoryRegistrationException($"Factory {Name} has no create methods.");

            Type type = typeof(TypedFactory<>);
            Type factory = type.MakeGenericType(InterfaceType);
            
            Factory = (ITypedFactory<TFactory>) Activator.CreateInstance(factory);
            
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("Factory"), AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("Factory");
            TypeBuilder typeBuilder = moduleBuilder.DefineType($"TypedFactory.{InterfaceType.Name}");
            
            typeBuilder.AddInterfaceImplementation(InterfaceType);

            //add `private readonly IInjectorContainer _container` field
            FieldBuilder containerFieldBuilder = typeBuilder.DefineField("_container", typeof(IInjectorContainer), FieldAttributes.Private | FieldAttributes.InitOnly);

            //add ctor
            ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis, new[] {typeof(IInjectorContainer)});
            var constructorGenerator = constructorBuilder.GetILGenerator();
            constructorGenerator.Emit(OpCodes.Ldarg_0);
            constructorGenerator.Emit(OpCodes.Ldarg_1);
            constructorGenerator.Emit(OpCodes.Stfld, containerFieldBuilder); //set `_container` field
            constructorGenerator.Emit(OpCodes.Ret);

            foreach (var createMethod in createMethods)
            {
                //public `createMethod.ReturnType` Create(`createMethod.GetParameters()`)
                //{
                //    return IInjectorContainer.Resolve(`createMethod.ReturnType`, params);
                //}

                var args = createMethod.GetParameters();

                MethodBuilder methodBuilder = typeBuilder.DefineMethod(createMethod.Name, MethodAttributes.Public | MethodAttributes.Virtual, 
                    createMethod.ReturnType, (from arg in args select arg.ParameterType).ToArray());
                typeBuilder.DefineMethodOverride(methodBuilder, createMethod);

                var generator = methodBuilder.GetILGenerator();

                generator.Emit(OpCodes.Ldarg_0);
                generator.Emit(OpCodes.Ldfld, containerFieldBuilder);
                generator.Emit(OpCodes.Ldtoken, createMethod.ReturnType);

                if (args.Any())
                {
                    generator.Emit(OpCodes.Ldc_I4_S, args.Length + 1);
                    generator.Emit(OpCodes.Newarr, typeof(object));

                    for (int i = 0; i < args.Length; i++)
                    {
                        generator.Emit(OpCodes.Dup);
                        generator.Emit(OpCodes.Ldc_I4_S, i);
                        generator.Emit(OpCodes.Ldarg_S, i + 1);
                        generator.Emit(OpCodes.Stelem_Ref);
                    }
                }
                else
                {
                    generator.Emit(OpCodes.Ldc_I4_0);
                }

                generator.EmitCall(OpCodes.Callvirt, typeof(IInjectorContainer).GetMethod(nameof(IInjectorContainer.Resolve), new[] { typeof(object[]), typeof(Type) }), null);
                generator.Emit(OpCodes.Ret);
            }

            Factory.Factory = (TFactory) Activator.CreateInstance(typeBuilder.CreateTypeInfo().AsType(), _container);
        }
    }
}