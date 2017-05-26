---
title: TransactionScope
layout: api
---
# ITransactionScope

An implementation of the `ITransactionScope` interface is used to wrap a `TransactionScope`.

The `DefaultTransactionScope` makes use of the standard .NET `TransactionScope` functionality.  There is also a `NullTransactionScope` that implements the null pattern so it implements the interface but does not do anything.

## Properties

### Name

``` c#
string Name { get; }
```

Returns the name of the transaction scope.  This is helpful with logging.

## Methods

### Complete

``` c#
void Complete();
```

Marks the transaction scope as complete.

# ITransactionScopeFactory

An implementation of the `ITransactionScopeFactory` interface provides instances of an `ITransactionScope` implementation.

The `DefaultTransactionScopeFactory` provides a `DefaultTransactionScope` instance if transactions are `Enabled`; else an instance of `NullTransactionScope` is provided.

## Create

``` c#
ITransactionScope Create(string name);
ITransactionScope Create(string name, IsolationLevel isolationLevel, TimeSpan timeout);
ITransactionScope Create();
ITransactionScope Create(IsolationLevel isolationLevel, TimeSpan timeout);
```

Creates the relevant instance using the given parameters.

## Configuration Section

There is also a configuration section that can be used:

``` xml
<configuration>
  <configSections>
    <section name="transactionScope" type="Shuttle.Core.Infrastructure.TransactionScopeSection, Shuttle.Core.Infrastructure"/>
  </configSections>

  <transactionScope
      enabled="false"
      isolationLevel="RepeatableRead"
      timeoutSeconds="300" />
</configuration>
```

Call the static `TransactionScopeSection.Get()` method to return the configuration.