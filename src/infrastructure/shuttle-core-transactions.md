# Shuttle.Core.Transactions

```
PM> Install-Package Shuttle.Core.Transactions
```

This package makes use of the .Net `TransactionScope` class to provide ambient transaction handling.

## Configuration

The relevant components may be configured using `IServiceColletion`:

```c#
services.AddTransactionScope(builder => 
{
    builder.Options.Enabled = true;
    builder.Options.IsolationLevel = isolationLevel;
    builder.Options.Timeout = TimeSpan.FromSeconds(30);
});
```

The default JSON settings structure is as follows::

```json
{
	"Shuttle": {
		"TransactionScope": {
			"Enabled": true,
			"IsolationLevel": "isolation-level",
			"Timeout": "00:00:30"
		} 
	}
}
```

# ITransactionScope

An implementation of the `ITransactionScope` interface is used to wrap a `TransactionScope`.

The `DefaultTransactionScope` makes use of the standard .NET `TransactionScope` functionality.  There is also a `NullTransactionScope` that implements the null pattern so it implements the interface but does not do anything.

## Properties

``` c#
Guid Id { get; }
```

Returns the Id of the transaction scope.

## Methods

``` c#
void Complete();
```

Marks the transaction scope as complete.

# ITransactionScopeFactory

An implementation of the `ITransactionScopeFactory` interface provides instances of an `ITransactionScope` implementation.

The `TransactionScopeFactory` provides a `DefaultTransactionScope` instance if transaction scopes are `Enabled`; else a `NullTransactionScope` that implements the null pattern.

## Create

``` c#
ITransactionScope Create(IsolationLevel isolationLevel, TimeSpan timeout);
```

Creates the relevant instance using the given parameters.
