---
title: Shuttle.Core.Transactions
layout: api
---
# Shuttle.Core.Transactions

```
PM> Install-Package Shuttle.Core.Transactions
```

This package makes use of the .Net `TransactionScope` class to provide ambient transaction handling.  .Net Core 2.0 does not yet support ambient transactions and you would need to handle any transactions yourself.  To this end you would need to return a `NullTransactionScope` from the `ITransactionScopeFactory` implementation.  If you are using the `DefaultTransactionScopeFactory` then you can simply set the `enabled` attribute to `false`.

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
    <section name="transactionScope" type="Shuttle.Core.Transactions.TransactionScopeSection, Shuttle.Core.Transactions"/>
  </configSections>

  <transactionScope
      enabled="false"
      isolationLevel="RepeatableRead"
      timeoutSeconds="300" />
</configuration>
```

Call the static `TransactionScopeSection.Get()` method to return the configuration.
