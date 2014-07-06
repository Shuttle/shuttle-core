---
title: Shuttle.Core.Infrastructure
layout: api 
---
# Arguments

## Properties

### CommandLine

``` c#
public string[] CommandLine { get; }
```

TBD

### Item

``` c#
public string Item { get; }
```

TBD

## Methods

### Get

``` c#
public T Get<T>(string name)
```

TBD

### Get

``` c#
public T Get<T>(string name, T default)
```

TBD

### Contains

``` c#
public System.Boolean Contains(string name)
```

TBD

# ConfigurationItem`1

## Methods

### GetValue

``` c#
public T GetValue()
```

TBD

### ReadSetting

``` c#
public static ConfigurationItem<T> ReadSetting(string key)
```

TBD

### ReadSetting

``` c#
public static ConfigurationItem<T> ReadSetting(string key, T default)
```

TBD

# ColoredConsole

## Methods

### WriteLine

``` c#
public static void WriteLine(System.ConsoleColor color, string format, params object[] arg)
```

TBD

# ObjectExtensions

## Methods

### AttemptDispose

``` c#
public static void AttemptDispose(this object o)
```

If the given object can be cast to `IDisposable` the `Dispose()` method is invoked; else does nothing.

TBD

# StreamExtensions

## Methods

### ToBytesOnly

``` c#
public static System.Byte[] ToBytesOnly(this System.IO.Stream stream)
```

TBD

### ToBytes

``` c#
public static System.Byte[] ToBytes(this System.IO.Stream stream)
```

TBD

### Copy

``` c#
public static System.IO.Stream Copy(this System.IO.Stream stream)
```

TBD

# IThreadState

## Properties

### Active

``` c#
public System.Boolean Active { get; }
```

TBD

# IReflectionService

## Methods

### GetAssembly

``` c#
public System.Reflection.Assembly GetAssembly(string assembly)
```

TBD

### GetAssemblies

``` c#
public IEnumerable<System.Reflection.Assembly> GetAssemblies(string folder)
```

TBD

### GetAssembliesRecursive

``` c#
public IEnumerable<System.Reflection.Assembly> GetAssembliesRecursive()
```

TBD

### GetAssembliesRecursive

``` c#
public IEnumerable<System.Reflection.Assembly> GetAssembliesRecursive(string folder)
```

TBD

### GetTypes

``` c#
public IEnumerable<System.Type> GetTypes<T>()
```

TBD

### GetTypes

``` c#
public IEnumerable<System.Type> GetTypes(System.Type type)
```

TBD

### GetTypes

``` c#
public IEnumerable<System.Type> GetTypes(System.Reflection.Assembly assembly)
```

TBD

### GetTypes

``` c#
public IEnumerable<System.Type> GetTypes<T>(System.Reflection.Assembly assembly)
```

TBD

### GetTypes

``` c#
public IEnumerable<System.Type> GetTypes(System.Type type, System.Reflection.Assembly assembly)
```

TBD

### GetType

``` c#
public System.Type GetType(Func<System.Type,System.Boolean> condition)
```

TBD

### GetType

``` c#
public System.Type GetType(System.Reflection.Assembly assembly, Func<System.Type,System.Boolean> condition)
```

TBD

### CreateInstances

``` c#
public IEnumerable<T> CreateInstances<T>(IEnumerable<System.Type> types)
```

TBD

# ReflectionService

## Methods

### GetAssembly

``` c#
public System.Reflection.Assembly GetAssembly(string assembly)
```

TBD

### GetAssemblies

``` c#
public IEnumerable<System.Reflection.Assembly> GetAssemblies(string folder)
```

TBD

### GetAssembliesRecursive

``` c#
public IEnumerable<System.Reflection.Assembly> GetAssembliesRecursive()
```

TBD

### GetAssembliesRecursive

``` c#
public IEnumerable<System.Reflection.Assembly> GetAssembliesRecursive(string folder)
```

TBD

### GetTypes

``` c#
public IEnumerable<System.Type> GetTypes<T>()
```

TBD

### GetTypes

``` c#
public IEnumerable<System.Type> GetTypes(System.Type type)
```

TBD

### GetTypes

``` c#
public IEnumerable<System.Type> GetTypes<T>(System.Reflection.Assembly assembly)
```

TBD

### GetTypes

``` c#
public IEnumerable<System.Type> GetTypes(System.Type type, System.Reflection.Assembly assembly)
```

TBD

### GetTypes

``` c#
public IEnumerable<System.Type> GetTypes(System.Reflection.Assembly assembly)
```

TBD

### GetType

``` c#
public System.Type GetType(Func<System.Type,System.Boolean> condition)
```

TBD

### GetType

``` c#
public System.Type GetType(System.Reflection.Assembly assembly, Func<System.Type,System.Boolean> condition)
```

TBD

### CreateInstances

``` c#
public IEnumerable<T> CreateInstances<T>(IEnumerable<System.Type> types)
```

TBD

# ThreadSleep

## Methods

### While

``` c#
public static void While(int ms, IThreadState state)
```

TBD

### While

``` c#
public static void While(int ms, IThreadState state, int step)
```

TBD

# TypeExtensions

## Methods

### HasInterfaces

``` c#
public static System.Boolean HasInterfaces(this System.Type type)
```

TBD

### InterfaceMatching

``` c#
public static System.Type InterfaceMatching(this System.Type type, string includeRegexPattern)
```

TBD

### InterfaceMatching

``` c#
public static System.Type InterfaceMatching(this System.Type type, string includeRegexPattern, string excludeRegexPattern)
```

TBD

### FirstInterface

``` c#
public static IEnumerable<System.Type> FirstInterface(this System.Type type, System.Type of)
```

TBD

### MatchingInterface

``` c#
public static System.Type MatchingInterface(this System.Type type)
```

TBD

### InterfacesAssignableTo

``` c#
public static IEnumerable<System.Type> InterfacesAssignableTo<T>(this System.Type type)
```

TBD

### InterfacesAssignableTo

``` c#
public static IEnumerable<System.Type> InterfacesAssignableTo(this System.Type type, System.Type interfaceType)
```

TBD

### AssertDefaultConstructor

``` c#
public static void AssertDefaultConstructor(this System.Type type)
```

TBD

### AssertDefaultConstructor

``` c#
public static void AssertDefaultConstructor(this System.Type type, string message)
```

TBD

### HasDefaultConstructor

``` c#
public static System.Boolean HasDefaultConstructor(this System.Type type)
```

TBD

### IsAssignableTo

``` c#
public static System.Boolean IsAssignableTo(this System.Type type, System.Type otherType)
```

TBD

### GetGenericArguments

``` c#
public static System.Type GetGenericArguments(this System.Type type, System.Type generic)
```

TBD

# ILog

## Properties

### LogLevel

``` c#
public LogLevel LogLevel { get; }
```

TBD

### IsVerboseEnabled

``` c#
public System.Boolean IsVerboseEnabled { get; }
```

TBD

### IsTraceEnabled

``` c#
public System.Boolean IsTraceEnabled { get; }
```

TBD

### IsDebugEnabled

``` c#
public System.Boolean IsDebugEnabled { get; }
```

TBD

### IsInformationEnabled

``` c#
public System.Boolean IsInformationEnabled { get; }
```

TBD

### IsWarningEnabled

``` c#
public System.Boolean IsWarningEnabled { get; }
```

TBD

### IsErrorEnabled

``` c#
public System.Boolean IsErrorEnabled { get; }
```

TBD

### IsFatalEnabled

``` c#
public System.Boolean IsFatalEnabled { get; }
```

TBD

## Methods

### AtLevel

``` c#
public void AtLevel(LogLevel level, string message)
```

TBD

### Verbose

``` c#
public void Verbose(string message)
```

TBD

### Trace

``` c#
public void Trace(string message)
```

TBD

### Debug

``` c#
public void Debug(string message)
```

TBD

### Information

``` c#
public void Information(string message)
```

TBD

### Warning

``` c#
public void Warning(string message)
```

TBD

### Error

``` c#
public void Error(string message)
```

TBD

### Fatal

``` c#
public void Fatal(string message)
```

TBD

### Verbose

``` c#
public void Verbose(System.Boolean condition, string message)
```

TBD

### Trace

``` c#
public void Trace(System.Boolean condition, string message)
```

TBD

### Debug

``` c#
public void Debug(System.Boolean condition, string message)
```

TBD

### Information

``` c#
public void Information(System.Boolean condition, string message)
```

TBD

### Warning

``` c#
public void Warning(System.Boolean condition, string message)
```

TBD

### Error

``` c#
public void Error(System.Boolean condition, string message)
```

TBD

### Fatal

``` c#
public void Fatal(System.Boolean condition, string message)
```

TBD

### Verbose

``` c#
public void Verbose(Func<System.Boolean> condition, string message)
```

TBD

### Trace

``` c#
public void Trace(Func<System.Boolean> condition, string message)
```

TBD

### Debug

``` c#
public void Debug(Func<System.Boolean> condition, string message)
```

TBD

### Information

``` c#
public void Information(Func<System.Boolean> condition, string message)
```

TBD

### Warning

``` c#
public void Warning(Func<System.Boolean> condition, string message)
```

TBD

### Error

``` c#
public void Error(Func<System.Boolean> condition, string message)
```

TBD

### Fatal

``` c#
public void Fatal(Func<System.Boolean> condition, string message)
```

TBD

### IsEnabled

``` c#
public System.Boolean IsEnabled(LogLevel level)
```

TBD

### For

``` c#
public ILog For(System.Type type)
```

TBD

### For

``` c#
public ILog For(object instance)
```

TBD

# AbstractLog

## Properties

### LogLevel

``` c#
public LogLevel LogLevel { get; }
```

TBD

### IsVerboseEnabled

``` c#
public System.Boolean IsVerboseEnabled { get; }
```

TBD

### IsTraceEnabled

``` c#
public System.Boolean IsTraceEnabled { get; }
```

TBD

### IsDebugEnabled

``` c#
public System.Boolean IsDebugEnabled { get; }
```

TBD

### IsInformationEnabled

``` c#
public System.Boolean IsInformationEnabled { get; }
```

TBD

### IsWarningEnabled

``` c#
public System.Boolean IsWarningEnabled { get; }
```

TBD

### IsErrorEnabled

``` c#
public System.Boolean IsErrorEnabled { get; }
```

TBD

### IsFatalEnabled

``` c#
public System.Boolean IsFatalEnabled { get; }
```

TBD

## Methods

### AtLevel

``` c#
public void AtLevel(LogLevel level, string message)
```

TBD

### Verbose

``` c#
public void Verbose(string message)
```

TBD

### Trace

``` c#
public void Trace(string message)
```

TBD

### Debug

``` c#
public void Debug(string message)
```

TBD

### Warning

``` c#
public void Warning(string message)
```

TBD

### Information

``` c#
public void Information(string message)
```

TBD

### Error

``` c#
public void Error(string message)
```

TBD

### Fatal

``` c#
public void Fatal(string message)
```

TBD

### Verbose

``` c#
public void Verbose(System.Boolean condition, string message)
```

TBD

### Trace

``` c#
public void Trace(System.Boolean condition, string message)
```

TBD

### Debug

``` c#
public void Debug(System.Boolean condition, string message)
```

TBD

### Information

``` c#
public void Information(System.Boolean condition, string message)
```

TBD

### Warning

``` c#
public void Warning(System.Boolean condition, string message)
```

TBD

### Error

``` c#
public void Error(System.Boolean condition, string message)
```

TBD

### Fatal

``` c#
public void Fatal(System.Boolean condition, string message)
```

TBD

### Verbose

``` c#
public void Verbose(Func<System.Boolean> condition, string message)
```

TBD

### Trace

``` c#
public void Trace(Func<System.Boolean> condition, string message)
```

TBD

### Debug

``` c#
public void Debug(Func<System.Boolean> condition, string message)
```

TBD

### Information

``` c#
public void Information(Func<System.Boolean> condition, string message)
```

TBD

### Warning

``` c#
public void Warning(Func<System.Boolean> condition, string message)
```

TBD

### Error

``` c#
public void Error(Func<System.Boolean> condition, string message)
```

TBD

### Fatal

``` c#
public void Fatal(Func<System.Boolean> condition, string message)
```

TBD

### IsEnabled

``` c#
public System.Boolean IsEnabled(LogLevel level)
```

TBD

### For

``` c#
public ILog For(System.Type type)
```

TBD

### For

``` c#
public ILog For(object instance)
```

TBD

# ConsoleLog

## Properties

### LogLevel

``` c#
public void LogLevel { public get; set; }
```

TBD

## Methods

### Verbose

``` c#
public void Verbose(string message)
```

TBD

### Trace

``` c#
public void Trace(string message)
```

TBD

### Debug

``` c#
public void Debug(string message)
```

TBD

### Warning

``` c#
public void Warning(string message)
```

TBD

### Information

``` c#
public void Information(string message)
```

TBD

### Error

``` c#
public void Error(string message)
```

TBD

### Fatal

``` c#
public void Fatal(string message)
```

TBD

### For

``` c#
public ILog For(System.Type type)
```

TBD

### For

``` c#
public ILog For(object instance)
```

TBD

# SimpleEventLog

## Methods

### Verbose

``` c#
public void Verbose(string message)
```

TBD

### Trace

``` c#
public void Trace(string message)
```

TBD

### Debug

``` c#
public void Debug(string message)
```

TBD

### Information

``` c#
public void Information(string message)
```

TBD

### Error

``` c#
public void Error(string message)
```

TBD

### Fatal

``` c#
public void Fatal(string message)
```

TBD

### For

``` c#
public ILog For(System.Type type)
```

TBD

### For

``` c#
public ILog For(object instance)
```

TBD

### Warning

``` c#
public void Warning(string message)
```

TBD

# LoggerDelegate

## Methods

### Invoke

``` c#
public void Invoke(System.Type type, string message)
```

TBD

### BeginInvoke

``` c#
public System.IAsyncResult BeginInvoke(System.Type type, string message, System.AsyncCallback callback, object object)
```

TBD

### EndInvoke

``` c#
public void EndInvoke(System.IAsyncResult result)
```

TBD

# Log

## Properties

### IsVerboseEnabled

``` c#
public static System.Boolean IsVerboseEnabled { get; }
```

TBD

### IsTraceEnabled

``` c#
public static System.Boolean IsTraceEnabled { get; }
```

TBD

### IsDebugEnabled

``` c#
public static System.Boolean IsDebugEnabled { get; }
```

TBD

### IsInformationEnabled

``` c#
public static System.Boolean IsInformationEnabled { get; }
```

TBD

### IsWarningEnabled

``` c#
public static System.Boolean IsWarningEnabled { get; }
```

TBD

### IsErrorEnabled

``` c#
public static System.Boolean IsErrorEnabled { get; }
```

TBD

### IsFatalEnabled

``` c#
public static System.Boolean IsFatalEnabled { get; }
```

TBD

## Methods

### Assign

``` c#
public static void Assign(ILog instance)
```

TBD

### AssignTransient

``` c#
public static TransientLog AssignTransient(ILog instance)
```

TBD

### AtLevel

``` c#
public static void AtLevel(LogLevel level, string message)
```

TBD

### Verbose

``` c#
public static void Verbose(string message)
```

TBD

### Trace

``` c#
public static void Trace(string message)
```

TBD

### Debug

``` c#
public static void Debug(string message)
```

TBD

### Information

``` c#
public static void Information(string message)
```

TBD

### Warning

``` c#
public static void Warning(string message)
```

TBD

### Error

``` c#
public static void Error(string message)
```

TBD

### Fatal

``` c#
public static void Fatal(string message)
```

TBD

### Verbose

``` c#
public static void Verbose(System.Boolean condition, string message)
```

TBD

### Trace

``` c#
public static void Trace(System.Boolean condition, string message)
```

TBD

### Debug

``` c#
public static void Debug(System.Boolean condition, string message)
```

TBD

### Information

``` c#
public static void Information(System.Boolean condition, string message)
```

TBD

### Warning

``` c#
public static void Warning(System.Boolean condition, string message)
```

TBD

### Error

``` c#
public static void Error(System.Boolean condition, string message)
```

TBD

### Fatal

``` c#
public static void Fatal(System.Boolean condition, string message)
```

TBD

### Verbose

``` c#
public static void Verbose(Func<System.Boolean> condition, string message)
```

TBD

### Trace

``` c#
public static void Trace(Func<System.Boolean> condition, string message)
```

TBD

### Debug

``` c#
public static void Debug(Func<System.Boolean> condition, string message)
```

TBD

### Information

``` c#
public static void Information(Func<System.Boolean> condition, string message)
```

TBD

### Warning

``` c#
public static void Warning(Func<System.Boolean> condition, string message)
```

TBD

### Error

``` c#
public static void Error(Func<System.Boolean> condition, string message)
```

TBD

### Fatal

``` c#
public static void Fatal(Func<System.Boolean> condition, string message)
```

TBD

### For

``` c#
public static ILog For(System.Type type)
```

TBD

### For

``` c#
public static ILog For(object instance)
```

TBD

# TransientLog

## Methods

### Dispose

``` c#
public void Dispose()
```

TBD

# NullLog

## Properties

### LogLevel

``` c#
public LogLevel LogLevel { get; }
```

TBD

### IsVerboseEnabled

``` c#
public System.Boolean IsVerboseEnabled { get; }
```

TBD

### IsTraceEnabled

``` c#
public System.Boolean IsTraceEnabled { get; }
```

TBD

### IsDebugEnabled

``` c#
public System.Boolean IsDebugEnabled { get; }
```

TBD

### IsInformationEnabled

``` c#
public System.Boolean IsInformationEnabled { get; }
```

TBD

### IsWarningEnabled

``` c#
public System.Boolean IsWarningEnabled { get; }
```

TBD

### IsErrorEnabled

``` c#
public System.Boolean IsErrorEnabled { get; }
```

TBD

### IsFatalEnabled

``` c#
public System.Boolean IsFatalEnabled { get; }
```

TBD

## Methods

### AtLevel

``` c#
public void AtLevel(LogLevel level, string message)
```

TBD

### Verbose

``` c#
public void Verbose(string message)
```

TBD

### Trace

``` c#
public void Trace(string message)
```

TBD

### Debug

``` c#
public void Debug(string message)
```

TBD

### Information

``` c#
public void Information(string message)
```

TBD

### Warning

``` c#
public void Warning(string message)
```

TBD

### Error

``` c#
public void Error(string message)
```

TBD

### Fatal

``` c#
public void Fatal(string message)
```

TBD

### Verbose

``` c#
public void Verbose(System.Boolean condition, string message)
```

TBD

### Trace

``` c#
public void Trace(System.Boolean condition, string message)
```

TBD

### Debug

``` c#
public void Debug(System.Boolean condition, string message)
```

TBD

### Information

``` c#
public void Information(System.Boolean condition, string message)
```

TBD

### Warning

``` c#
public void Warning(System.Boolean condition, string message)
```

TBD

### Error

``` c#
public void Error(System.Boolean condition, string message)
```

TBD

### Fatal

``` c#
public void Fatal(System.Boolean condition, string message)
```

TBD

### Verbose

``` c#
public void Verbose(Func<System.Boolean> condition, string message)
```

TBD

### Trace

``` c#
public void Trace(Func<System.Boolean> condition, string message)
```

TBD

### Debug

``` c#
public void Debug(Func<System.Boolean> condition, string message)
```

TBD

### Information

``` c#
public void Information(Func<System.Boolean> condition, string message)
```

TBD

### Warning

``` c#
public void Warning(Func<System.Boolean> condition, string message)
```

TBD

### Error

``` c#
public void Error(Func<System.Boolean> condition, string message)
```

TBD

### Fatal

``` c#
public void Fatal(Func<System.Boolean> condition, string message)
```

TBD

### IsEnabled

``` c#
public System.Boolean IsEnabled(LogLevel level)
```

TBD

### For

``` c#
public ILog For(System.Type type)
```

TBD

### For

``` c#
public ILog For(object instance)
```

TBD

# ExceptionExtensions

## Methods

### Messages

``` c#
public static IList<string> Messages(this System.Exception ex)
```

TBD

### AllMessages

``` c#
public static string AllMessages(this System.Exception ex)
```

TBD

### TrimLeading

``` c#
public static System.Exception TrimLeading<T>(this System.Exception ex) where T: System.Exception
```

TBD

# GuidExtensions

## Methods

### TryParse

``` c#
public static System.Boolean TryParse(string guid, out System.Guid& result)
```

TBD

# Guard

## Methods

### Against

``` c#
public static void Against<TException>(System.Boolean assertion, string message) where TException: System.Exception
```

TBD

### Against

``` c#
public static void Against<TException>(Func<System.Boolean> assertion, string message) where TException: System.Exception
```

TBD

### AgainstNull

``` c#
public static void AgainstNull(object value, string name)
```

TBD

### AgainstNullOrEmptyString

``` c#
public static void AgainstNullOrEmptyString(string value, string name)
```

TBD

### AgainstReassignment

``` c#
public static void AgainstReassignment(object variable, string name)
```

TBD

# InfrastructureResources

## Properties

### ResourceManager

``` c#
public static System.Resources.ResourceManager ResourceManager { get; }
```

TBD

### Culture

``` c#
public static void Culture { public get; set; }
```

TBD

### ConfigurationItemEmptyUsingDefault

``` c#
public static string ConfigurationItemEmptyUsingDefault { get; }
```

TBD

### ConfigurationItemMissing

``` c#
public static string ConfigurationItemMissing { get; }
```

TBD

### ConfigurationItemMissingUsingDefault

``` c#
public static string ConfigurationItemMissingUsingDefault { get; }
```

TBD

### EmptyStringException

``` c#
public static string EmptyStringException { get; }
```

TBD

### InvalidArgumentException

``` c#
public static string InvalidArgumentException { get; }
```

TBD

### InvalidGuardExceptionType

``` c#
public static string InvalidGuardExceptionType { get; }
```

TBD

### NullValueException

``` c#
public static string NullValueException { get; }
```

TBD

### ReassignmentException

``` c#
public static string ReassignmentException { get; }
```

TBD

### StreamCannotSeek

``` c#
public static string StreamCannotSeek { get; }
```

TBD

### TraceGetTypesFromAssembly

``` c#
public static string TraceGetTypesFromAssembly { get; }
```

TBD

