# Shuttle.Core.DependencyInjection

```
PM> Install-Package Shuttle.Core.DependencyInjection
```

Add components to `IServiceCollection` by convention:

```c#
IServiceCollection services = new ServiceCollection();

services
	.FromAssembly(assembly)
	.Add();
```

The above would be the simplest case and adds all types using either a matching interface (with the same name as the class prefixed with `I`) or the first interface found.  The default service lifetime is `Singleton`.

In order to filter the types add a `Filter` function:

```c#
IServiceCollection services = new ServiceCollection();

services
	.FromAssembly(assembly)
	.Filter(type => type.Name.Equals("FilteredType", StringComparison.InvariantCultureIgnoreCase))
	.Add();
```

If a particular interface should be used for a selected type it may be specified as follows:

```c#
IServiceCollection services = new ServiceCollection();

services
	.FromAssembly(assembly)
	.GetServiceType(type => typeof(ISomeInterface))
	.Add();
```

The service lifetime may also be specified:

```c#
IServiceCollection services = new ServiceCollection();

services
	.FromAssembly(assembly)
	.GetServiceLifetime(type => ServiceLifetime.Transient)
	.Add();
```

Since this is a builder interface all the bits may be used in combination:

```c#
IServiceCollection services = new ServiceCollection();

services
	.FromAssembly(assembly)
	.Filter(type => type.Name.Equals("FilteredType", StringComparison.InvariantCultureIgnoreCase))
	.GetServiceType(type => typeof(ISomeInterface))
	.GetServiceLifetime(type => ServiceLifetime.Transient)
	.Add();
```
