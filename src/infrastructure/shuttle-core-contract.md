# Shuttle.Core.Contract

```
PM> Install-Package Shuttle.Core.Contract
```


A guard implementation that performs assertions/assumptions to prevent invalid code execution.

# Guard

```c#
void Against<TException>(bool assertion, string message) 
	where TException : Exception
```

Throws exception `TException` with the given `message` if the `assertion` is false.  If exception type `TException` does not have a constructor that accepts a `message` then an `InvalidOperationException` is thrown instead.

---

```c#
void AgainstNull(object value, string name)
```

Throws a `NullReferenceException` if the given `value` is `null`.

---

```c#
void AgainstNullOrEmptyString(string value, string name)
```

Throws a `NullReferenceException` if the given `value` is `null` or empty/whitespace.

---

```c#
void AgainstUndefinedEnum<TEnum>(object value, string name)
```

Throws an `InvalidOperationException` if the provided `value` cannot be found in the given `enum`.

---

```c#
void AgainstEmptyEnumerable<T>(IEnumerable<T> enumerable, string name)
```

Throws an `InvalidOperationException` if the given `enumerable` does not contain any entries.

---

```c#
public static void AgainstEmptyGuid(Guid value, string name)
```

Throws and `ArgumentException` when the `value` is equal to an empty `Guid` (`{00000000-0000-0000-0000-000000000000}`).