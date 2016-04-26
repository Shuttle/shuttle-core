---
title: Logging Infrastructure
layout: api 
---
# Logging Infrastructure

The Shuttle.Core project does not provide a concrete implementation for logging but rather provides an abstract mechanism that can be used to implement any logging mechanism such as a Log4Net implementation.

In this way all logging can be performed through the `ILog` interface and accompanying `Log` singleton without relying on any specific implementation.  Developer can then make use any implementation.

Since there is some boilerplate code implementors may make use of the `AbstractLog` class to implement a new concrete logging mechanism:

~~~ c#
public abstract class AbstractLog : ILog
{
	// boilerplate
}
~~~

# Assigning a logging mechanism

If no log is assigned or if a `null` is assigned the `NullLog.Instance` will be used.  As may be deduced from the name this log does not do anything.

## Assign

~~~ c#
public static void Assign(ILog instance)
~~~

This assigns the log to use for the duration of the execution.

## AssignTransient

~~~ c#
public static TransientLog AssignTransient(ILog instance)
~~~

Returns a `IDisposable` instance that returns the log to the previous instance on dispose.  This may be usefull for testing purposes where you may want to use a mock object and ensure that certain bits are logged.