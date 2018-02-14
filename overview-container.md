---
title: Container
layout: api
---
# Overview

In the dependency injection (DI) world there appears to be somewhat of a trend to separate registration and resolution of components.  Some containers have an explicit split while others do not allow any registrations after the first instance resolution.

To this end the `Shuttle.Core.Container` package provides two interfaces that relate to dependency injection containers.  The `IComponentRegistry` defines the registration of dependencies while the `IComponentResolver` defines the resolution of dependencies.

Typically there would be no need to directly reference this package unless you are developing an adapter to a dependency injection container.  Instead you would reference one of the implementations directly.

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

You can control the bootstrapping behaviour using and implementation of the `IBootstrapConfiguration`.  The `BootstrapSection` can provide a default `BootstrapConfiguration` instance for the following application configuration options:

``` xml
<configuration>
  <configSections>
    <section name="bootstrap" type="Shuttle.Core.Infrastructure.BootstrapSection, Shuttle.Core.Infrastructure"/>
  </configSections>

  <bootstrap scan="All|Shuttle|None">
    <assemblies>
      <add name="Shuttle.Module1" />
      <add name="Shuttle.Module2" />
    </assemblies>
  </bootstrap>
</configuration>
```

<a name="IComponentRegistryBootstrap"></a>

### IComponentRegistryBootstrap

You can call the `IComponentRegistry.RegistryBoostrap()` extension method to bootstrap registrations.  This method will instance any classes that implement the `IComponentRegistryBootstrap` interface and call the `Register(IComponentRegistry registry)` method within that instance.  The implementation has to have a default constructor.

You may also make use of the registry's configuration section to specify explicit registrations and to disable scanning of assemblies (which defaults to `true`):

``` xml
<configuration>
  <configSections>
    <section name="componentRegistry" type="Shuttle.Core.Infrastructure.ComponentRegistrySection, Shuttle.Core.Infrastructure"/>
  </configSections>

  <componentRegistry scan="true|false">
    <components>
      <add dependencyType="Shuttle.Module1" />
      <add dependencyType="Shuttle.Module2" />
    </components>
    <collections>
      <collection dependencyType="IPlugin">
        <add implementationType="Plugin1" />
        <add implementationType="Plugin2" />
        <add implementationType="Plugin3" />
      </collection>
    </collections>
  </componentRegistry>
</configuration>
```

<a name="IComponentResolverBootstrap"></a>

### IComponentResolverBootstrap

You can call the `IComponentResolver.ResolverBoostrap()` extension method to bootstrap resolving components.  This method will instance any classes that implement the `IComponentResolverBootstrap` interface and call the `Resolve(IComponentResolver resolver)` method within that instance.  The implementation has to have a default constructor.

In addition you may also use the following configuration section to specify explicit resolutions and to disable scanning of assemblies (which defaults to `true`):

``` xml
<configuration>
  <configSections>
    <section name="componentResolver" type="Shuttle.Core.Infrastructure.ComponentResolverSection, Shuttle.Core.Infrastructure"/>
  </configSections>

  <componentResolver scan="true|false">
    <components>
      <add dependencyType="Shuttle.Module1" />
      <add dependencyType="Shuttle.Module2" />
    </components>
  </componentResolver>
</configuration>
```

<a name="Supported"></a>

## Implementations

The following implementations can be used *out-of-the-box*:

- [WindsorContainer](https://github.com/Shuttle/Shuttle.Core.Castle)
- [Ninject](https://github.com/Shuttle/Shuttle.Core.Ninject)
- [AutoFac](https://github.com/Shuttle/Shuttle.Core.Autofac)
- [StructureMap](https://github.com/Shuttle/Shuttle.Core.StructureMap)
- [SimpleInjector](https://github.com/Shuttle/Shuttle.Core.SimpleInjector)
- [Unity](https://github.com/Shuttle/Shuttle.Core.Unity)

If you don't see your container of choice here please [log an issue](https://github.com/Shuttle/Shuttle.Core.Infrastructure/issues/new) or share your own implementation.