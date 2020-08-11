---
title: Shuttle.Core.Container
layout: api
---
# Shuttle.Core.Container

```
PM> Install-Package Shuttle.Core.Container
```

In the dependency injection (DI) world there appears to be somewhat of a trend to separate registration and resolution of components.  Some containers have an explicit split while others do not allow any registrations after the first instance resolution.

To this end the `Shuttle.Core.Container` package provides two interfaces that relate to dependency injection containers.  The `IComponentRegistry` defines the registration of dependencies while the `IComponentResolver` defines the resolution of dependencies.

Typically there would be no need to directly reference this package unless you are developing an adapter to a dependency injection container.  Instead you would reference one of the implementations directly.

## IComponentRegistry

### Lifestyle

```
public enum Lifestyle
{
    Singleton = 0,Transient = 1
}
```

When registering a dependency type with an implementation type you can specify one of the above lifestyles for your component:

- Singleton: only a single instance is created and that instance is returned for any call to `Resolve` the service type.
- Transient: a new instance of the implementation type is returned for each call to `Resolve` the service type.

### Registering all dependency implementations

``` c#
public static void RegisterAll(this IComponentRegistry registry, string assemblyName, Lifestyle lifestyle = Lifestyle.Singleton)
public static void RegisterAll(this IComponentRegistry registry, Assembly assembly, Lifestyle lifestyle = Lifestyle.Singleton)
```

Register all interfaces in the given assembly, that have not yet been registered, that have a single implementation as a regular dependency.  All interfaces that have more than 1 implementation are registered as collections.

This method differes from the usual convention in that there is no `AttemptRegisterAll` method.

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

#### Extensions

There are a number of extension methods that facilitate the registration of components:

```c#
public static bool IsRegistered<TDependency>(this IComponentRegistry registry)
```

Will return `true` if the dependency is registered; else `false`.

```c#
public static IComponentRegistry Register<TDependency, TImplementation>(this IComponentRegistry registry)
```

Registers a new dependency/implementation type pair as a singleton.

```c#
public static IComponentRegistry Register<TDependency, TImplementation>(this IComponentRegistry registry, Lifestyle lifestyle)
```

Registers a new dependency/implementation type pair with the given `Lifestyle`.

```c#
public static IComponentRegistry Register<TDependencyImplementation>(this IComponentRegistry registry)
```

Registers a new dependency/implementation type pair by binding the implementation type to itself.

```c#
public static IComponentRegistry RegisterInstance<TDependency>(this IComponentRegistry registry, TDependency instance)
```

Registers a singleton instance for the given dependency type.

```c#
public static IComponentRegistry Register(this IComponentRegistry registry, Type dependencyType, Type implementationType)
```

Registers a new dependency/implementation type pair as a singleton.

```c#
public static IComponentRegistry AttemptRegister<TDependency, TImplementation>(this IComponentRegistry registry)
```

Registers a new dependency/implementation type pair as a singleton if the dependency has not yet been registered; else does nothing.

```c#
public static IComponentRegistry AttemptRegister<TDependency, TImplementation>(this IComponentRegistry registry)
```

Registers a new dependency/implementation type pair as a singleton if the dependency has not yet been registered; else does nothing.

```c#
public static IComponentRegistry AttemptRegister<TDependency, TImplementation>(this IComponentRegistry registry, Lifestyle lifestyle)
```

Registers a new dependency/implementation type pair if the dependency has not yet been registered; else does nothing.

```c#
public static IComponentRegistry AttemptRegister<TDependencyImplementation>(this IComponentRegistry registry)
```

Registers a new dependency/implementation type pair as a singleton if the dependency has not yet been registered; else does nothing.

```c#
public static IComponentRegistry AttemptRegister<TDependencyImplementation>(this IComponentRegistry registry, Lifestyle lifestyle)
```

Registers a new dependency/implementation type pair if the dependency has not yet been registered; else does nothing.

```c#
public static IComponentRegistry AttemptRegister<TDependencyImplementation>(this IComponentRegistry registry, Lifestyle lifestyle)
```

Registers a new dependency/implementation type pair if the dependency has not yet been registered; else does nothing.

```c#
public static IComponentRegistry AttemptRegister<TDependencyImplementation>(this IComponentRegistry registry, Lifestyle lifestyle)
```

Registers a new dependency/implementation type pair if the dependency has not yet been registered; else does nothing.

```c#
public static IComponentRegistry AttemptRegister<TDependencyImplementation>(this IComponentRegistry registry, Lifestyle lifestyle)
```

Registers a new dependency/implementation type pair with then given `Lifestyle` if the dependency has not yet been registered; else does nothing.

```c#
public static IComponentRegistry AttemptRegisterInstance<TDependency>(this IComponentRegistry registry, TDependency instance)
```

Registers a singleton instance for the given dependency type if the dependency has not yet been registered; else does nothing.

```c#
public static IComponentRegistry AttemptRegisterGeneric(this IComponentRegistry registry, Type dependencyType, Type implementationType)
```

Registers an open generic for the given dependency type as a singleton if the dependency has not yet been registered; else does nothing.

```c#
public static IComponentRegistry AttemptRegisterGeneric(this IComponentRegistry registry, Type dependencyType, Type implementationType, Lifestyle lifestyle)
```

Registers an open generic for the given dependency type if the dependency has not yet been registered; else does nothing.

```c#
public static void RegisterSuffixed(this IComponentRegistry registry, string assemblyName, Lifestyle lifestyle = Lifestyle.Singleton)
public static void RegisterSuffixed(this IComponentRegistry registry, Assembly assembly, Lifestyle lifestyle = Lifestyle.Singleton)
```

Register all types in the given assembly that end in the `DefaultSuffixes` against a dependency type matching the type name with an `I` prefix, e.g. `CustomerRepository` will be registered against `ICustomerRepository`.

```c#
public static void RegisterSuffixed(this IComponentRegistry registry, string assemblyName, IEnumerable<string> suffixes, Lifestyle lifestyle = Lifestyle.Singleton)
public static void RegisterSuffixed(this IComponentRegistry registry, Assembly assembly, IEnumerable<string> suffixes, Lifestyle lifestyle = Lifestyle.Singleton)
```

Register all types in the given assembly that end in the given `suffixes` against a dependency type matching the type name with an `I` prefix, e.g. `CustomerRepository` will be registered against `ICustomerRepository`.

```c#
public static void Register(this IComponentRegistry registry, Assembly assembly, Func<Type, bool> shouldRegister, Func<Type, Type> getDependencyType, Func<Type, Lifestyle> getLifestyle)
```

Registers all the types in the given assembly that satisfies the `shouldRegister` function against the type returned from the `getDependencyType` function.

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

#### Extensions

There are a couple of extension methods available to facilitate the resolving of dependencies:

```c#
public static T Resolve<T>(this IComponentResolver resolver)
```

Resolves the requested service type.  If the service type cannot be resolved an exception is thrown.

```c#
public static T AttemptResolve<T>(this IComponentResolver resolver)
public static object AttemptResolve(this IComponentResolver resolver, Type dependencyType)
```

Attempts to resolve the requested service type.  If the service type cannot be resolved null is returned.

```c#
public static IEnumerable<object> Resolve(this IComponentResolver resolver, IEnumerable<Type> dependencyTypes)
```

Resolves all the given types.  These may be types that will not necessarily be injected into another class but that may require other instances from the resolver.

```c#
public static IEnumerable<T> ResolveAll<T>(this IComponentResolver resolver)
```

Resolves all registered instances of the requested service type.

<a name="Bootstrapping"></a>

## Bootstrapping

It is important to note that your bootstrap implementations should be idempotent as they *may* be called more than once in some instances.

You can control the bootstrapping behaviour using and implementation of the `IBootstrapConfiguration`.  The `BootstrapSection` can provide a default `BootstrapConfiguration` instance for the following application configuration options:

``` xml
<configuration>
  <configSections>
    <section name="bootstrap" type="Shuttle.Core.Container.BootstrapSection, Shuttle.Core.Container"/>
  </configSections>

  <bootstrap scan="All|Shuttle|None">
    <assemblies>
      <add name="Shuttle.Module1" />
      <add name="Shuttle.Module2" />
    </assemblies>
  </bootstrap>
</configuration>
```

In addition a `ComponentResolver` implementation of the `IComponentResolver` interface is registered when using bootstrapping.  This is a proxy to the actual implementation of the `IComponentResolver` interface and forwards the relevant calls to the assigned instance.  

***Note***:  Avoid using the service locator anti-pattern by injecting `IComponentResolver` in order to obtain singleton services.  Instead the intention is to use the `IComponentResolver` as a factory for transient instances where creating another interface may be superfluous.

<a name="IComponentRegistryBootstrap"></a>

### IComponentRegistryBootstrap

You can call the `IComponentRegistry.RegistryBootstrap()` extension method to bootstrap registrations.  This method will instance any classes that implement the `IComponentRegistryBootstrap` interface and call the `Register(IComponentRegistry registry)` method within that instance.  The implementation has to have a default constructor.

Example:

```c#
public class Bootstrap : IComponentRegistryBootstrap
{
    private static bool _registryBootstrapCalled;

    public void Register(IComponentRegistry registry)
    {
        Guard.AgainstNull(registry, nameof(registry));

        if (_registryBootstrapCalled)
        {
            return;
        }

        if (!registry.IsRegistered<IDependencyType>())
        {
            registry.AttemptRegisterInstance(ImplementationInstance));
        }

        registry.AttemptRegister<IAnotherDependency, ImplementationType>();

        _registryBootstrapCalled = true;
    }
}
```

You may also make use of the registry's configuration section to specify explicit registrations and to disable scanning of assemblies (which defaults to `true`):

``` xml
<configuration>
  <configSections>
    <section name="componentRegistry" type="Shuttle.Core.Container.ComponentRegistrySection, Shuttle.Core.Container"/>
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

You can call the `IComponentResolver.ResolverBootstrap()` extension method to bootstrap resolving components.  This method will instance any classes that implement the `IComponentResolverBootstrap` interface and call the `Resolve(IComponentResolver resolver)` method within that instance.  The implementation has to have a default constructor.

Example:

```c#
public class Bootstrap : IComponentResolverBootstrap
{
    private static bool _resolverBootstrapCalled;

    public void Resolve(IComponentResolver resolver)
    {
        Guard.AgainstNull(resolver, nameof(resolver));

        if (_resolverBootstrapCalled)
        {
            return;
        }

        resolver.Resolve<IDependencyType>();

        _resolverBootstrapCalled = true;
    }
}
```

You may be wondering why one would need to resolve instances.  If you happen to have an instance that has dependencies but is not a dependency itself then you would need to resolve it in order to inject the relevant implementations.  This is particularly useful in framework/plug-in architectures. 

In addition you may also use the following configuration section to specify explicit resolutions and to disable scanning of assemblies (which defaults to `true`):

``` xml
<configuration>
  <configSections>
    <section name="componentResolver" type="Shuttle.Core.Container.ComponentResolverSection, Shuttle.Core.Container"/>
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

If you don't see your container of choice here please [log an issue](https://github.com/Shuttle/Shuttle.Core.Container/issues/new) or share your own implementation.