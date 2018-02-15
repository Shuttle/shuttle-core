---
title: Shuttle.Core.Cli
layout: api
---
# Shuttle.Core.Cli

```
PM> Install-Package Shuttle.Core.Cli
```

Provides the `Arguments` class that provides access to your command-line interface arguments:

### Constructor

``` c#
public Arguments(params string[] commandLine)
```

The `commandLine` is parsed as arguments starting with `-`, `--` or `/` followed by the argument name then either `=` or `:` and then the argument value.

The following are valid arguments:

```
-name=value
--name=value
/name=value
-name:value
--name:value
/name:value
```

The argument name and value may be *quoted* with either a single quote (`'`) or double quote (`"`).

### Checking for values

``` c#
public bool Contains(string name)
```

Returns `true` if the given argument `name` is found; else `false`.

### Getting values

``` c#
public T Get<T>(string name)
public T Get<T>(string name, T @default)
```

Returns the value of the given argument `name` as type `T`.  If the argument `name` cannot be found the value given as `@default` will be returned.  If not `@default` is specified an `InvalidOperationException` is thrown.