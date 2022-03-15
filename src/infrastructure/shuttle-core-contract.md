---
title: Shuttle.Core.Contract
layout: api
---
# Shuttle.Core.Contract

```
PM> Install-Package Shuttle.Core.Contract
```


A guard implementation that performs asserts/assumptions to prevent invalid code execution.

# Guard

```c#
void Against<TException>(bool assertion, string message) where TException : Exception
```

Throws exception `TException` with the given `message` if the `assertion` is false.

```c#
void AgainstNull(object value, string name)
```

Throws a `NullReferenceException` is the given `value` is `null`.

```c#
void AgainstNullOrEmptyString(string value, string name)
```

Throws a `NullReferenceException` is the given `value` is `null` or empty.