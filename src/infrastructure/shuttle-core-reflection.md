# Shuttle.Core.Reflection

```
PM> Install-Package Shuttle.Core.Reflection
```

Provides various methods to facilitate reflection handling.

## ReflectionService

``` c#
string AssemblyPath(Assembly assembly)
```

Returns the path to the given assembly.

``` c#
Assembly FindAssemblyNamed(string name)
```

Returns the `Assembly` that has the requested `name`; else `null`.

``` c#
Assembly GetAssembly(string assemblyPath)
```

Returns the requested assembly if found; else `null`.

```c#
IEnumerable<Assembly> GetAssemblies()
```

Returns all reachable assemblies.

``` c#
IEnumerable<Assembly> GetMatchingAssemblies(string regex)
```

Returns a collection of assemblies that have their file name matching the given `Regex` expression.

``` c#
IEnumerable<Assembly> GetRuntimeAssemblies()
```

For .Net 4.6+ returns `AppDomain.CurrentDomain.GetAssemblies();`.  For .Net Core 2.0+ all the `DependencyContext.Default.GetRuntimeAssemblyNames(RuntimeEnvironment.GetRuntimeIdentifier())` assembly names are resolved.

``` c#
Type GetType(string typeName)
```

Attempts to find the requested type.

``` c#
IEnumerable<Type> GetTypes(Assembly assembly)
```

Returns all types in the given `assembly`.

``` c#
IEnumerable<Type> GetTypesAssignableTo<T>();
IEnumerable<Type> GetTypesAssignableTo(Type type);
IEnumerable<Type> GetTypesAssignableTo<T>(Assembly assembly);
IEnumerable<Type> GetTypesAssignableTo(Type type, Assembly assembly);
```

Returns all the types in the given `assembly` that are assignable to the `type` or `typeof(T)`; if no `assembly` is provided the all assemblies returned by `GetAssemblies()` will be scanned.

