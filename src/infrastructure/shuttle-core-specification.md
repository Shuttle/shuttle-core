# Shuttle.Core.Specification

```
PM> Install-Package Shuttle.Core.Specification
```

Provides a simple `ISpecification` interface.

A default `Specification` class is available that accepts a function as a callback for scenarios where an explicit `ISpecification` implementation may not be warranted:

``` c#
public Specification(Func<T, bool> function)
```