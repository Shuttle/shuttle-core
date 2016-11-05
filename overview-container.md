---
title: Container
layout: api
---
# Overview

The `Shuttle.Core.Infrastructure` package provides an 'IComponentContainer' abstraction that is used by other Shuttle projects to provide an implementation for your choice of dependency injection container.

## IComponentContainer

### Lifestyle

~~~
public enum Lifestyle
{
	Singleton = 0,
	Transient = 1,
	Thread = 2
}
~~~

When registering a sercvice type with an implementation type you can specify one of the above lifestyles for your component:

- Singleton: only a single instance is created and that instance is returned for any call to `Resolve` the service type.
- Transient: a new instance of the implementation type is returned for each call to `Resolve` the service type.
- Thread: each thread will share a single instance of the implementation type and that instance will be returned for any call to `Resolve` the service type.

### Register

~~~
IComponentContainer Register(Type serviceType, Type implementationType, Lifestyle lifestyle);
IComponentContainer Register(Type serviceType, object instance);
~~~

A new component is registered.  Any duplicates will result in a `TypeRegistrationException`.

### Resolve

~~~
object Resolve(Type serviceType);
T Resolve<T>() where T : class;
~~~

The requested service type will be resolved by returning the relevant instance of the implementation type.  Should a service type not be resolved a `TypeResolutionException` is thrown.

## DefaultComponentContainer

The `DefaultComponentContainer` is a very simple implementation that provides only constructor injection.  Typically you would use one of the major available implementations:

- [WindsorContainer](https://github.com/Shuttle/Shuttle.Core.Castle)
- [Ninject]()
- [Unity]()
- [AutoFac]()
- [StructureMap]()

If you don't see your container of choice here you could log an issue or share your own implementation.