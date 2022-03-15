# Shuttle.Core.Cli

```
PM> Install-Package Shuttle.Core.Cli
```

Provides the `Arguments` class that gives you access to command-line interface arguments:

## Constructor

```c#
public Arguments(params string[] commandLine)
```

The `commandLine` is parsed as arguments starting with `-`, `--` or `/` followed by the argument name then either `=` or `:` and then the argument value.

The following are valid arguments:

```batch
-name=value
--name=value
/name=value
-name:value
--name:value
/name:value
```

The argument name and value may be *quoted* with either a single quote (`'`) or double quote (`"`).

An `Arguments` instance may be constructed from the `Environment.GetCommandLineArgs()` values using the `Arguments.FromCommandLine()` static factory method.

## Checking for values

```c#
public bool Contains(string name)
```

Returns `true` if the given argument `name` is found; else `false`.

## Getting values

```c#
public T Get<T>(string name)
public T Get<T>(string name, T @default)
```

Returns the value of the given argument `name` as type `T`.  If the argument `name` cannot be found the value given as `@default` will be returned.  If not `@default` is specified an `InvalidOperationException` is thrown.

## Argument definitions

You can add `ArgumentDefinition` entries to an `Arguments` instance by using the following method:

```c#
public Arguments Add(ArgumentDefinition definition)
```

Argument definitions must have unique keys and if aliases are used these too have to be unique across definitions.  Duplicate aliases within the same argument definition will be ignored.

An argument definition may be marked as required by calling the `AsRequired()` method which will set the `IsRequired` property to `true`.  You can then call the `HasMissingValues()` method on the `Arguments` class which will return `true` is there are any required arguments that have not been specified using either the proper name or an alias.