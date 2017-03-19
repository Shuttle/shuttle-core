---
title: Container
layout: api
---
# Overview

In the dependency injection (DI) world there appears to be somewhat of a trend to separate registration and resolution of components.  Some containers have an explicit split while others do not allow any registrations after the first instance resolution.

To this end the `Shuttle.Core.Infrastructure` package provides two interfaces that relate to dependency injection containers.  The `IComponentRegistry` defines the registration of dependencies while the `IComponentResolver` defines the resolution of dependencies.

## IComponentRegistry

### Lifestyle

```
public enum Lifestyle
{
	Singleton = 0,
	Transient = 1
}
```

When registering a dependency type with an implementation type you can specify one of the above lifestyles for your component:

- Singleton: only a single instance is created and that instance is returned for any call to `Resolve` the service type.
- Transient: a new instance of the implementation type is returned for each call to `Resolve` the service type.

### Register

``` c#
IComponentRegistry Register(Type dependencyType, Type implementationType, Lifestyle lifestyle);
```

Registers a dependency by type with the relevant lifestyle.

``` c#
IComponentRegistry Register(Type dependencyType, object instance);
```

Registers the given singleton instance against the dependency type.

``` c#
IComponentRegistry RegisterCollection(Type dependencyType, IEnumerable<Type> implementationTypes, Lifestyle lifestyle);
```

Registers a collection of implementation types against the relevant dependency type using the given lifestyle.  Collections are a somewhat unique case and need to be registered as such.

## IComponentResolver

### Resolve

``` c#
object Resolve(Type dependencyType);
```

The requested dependency type will be resolved by returning the relevant instance of the implementation type.  

``` c#
IEnumerable<object> ResolveAll(Type dependencyType);
```

All instances of the requested dependency type will be resolved.  

<a name="Bootstrapping"></a>

## Bootstrapping

It is important to note that your bootstrap implementations should be idempotent as they *may* be called more than once in some instances.

<a name="IComponentRegistryBootstrap"></a>

### IComponentRegistryBootstrap

You can call the `IComponentRegistry.Bootstrap()` extension method to bootstrap registrations.  This method will instance any classes that implement the `IComponentRegistryBootstrap` interface and call the `Register(IComponentRegistry registry)` method within that instance.  The implementation has to have a default constructor.

<a name="IComponentResolverBootstrap"></a>

### IComponentResolverBootstrap

You can call the `IComponentResolver.Bootstrap()` extension method to bootstrap resolving components.  This method will instance any classes that implement the `IComponentResolverBootstrap` interface and call the `Resolve(IComponentResolver resolver)` method within that instance.  The implementation has to have a default constructor.


## Implementations

The following implementations can be used *out-of-the-box*:

- [WindsorContainer](https://github.com/Shuttle/Shuttle.Core.Castle)
- [Ninject](https://github.com/Shuttle/Shuttle.Core.Ninject)
- [AutoFac](https://github.com/Shuttle/Shuttle.Core.Autofac)
- [StructureMap](https://github.com/Shuttle/Shuttle.Core.StructureMap)
- [SimpleInjector](https://github.com/Shuttle/Shuttle.Core.SimpleInjector)
- [Unity](https://github.com/Shuttle/Shuttle.Core.Unity)

If you don't see your container of choice here please [log an issue](https://github.com/Shuttle/Shuttle.Core.Infrastructure/issues/new) or share your own implementation.