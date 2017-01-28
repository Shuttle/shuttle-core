# Host

The `Shuttle.Core.Host` package is an executable assembly used to execute code either within a console window or as a Windows service.  Since it can host your code while running in Visual Studio it makes debugging very easy.  No need to attach a debugger to a Windows service.

# Data

The `Shuttle.Core.Data` provides a thin abstraction over ADO.NET.

# Container

There are interfaces that abstract away dependency injection containers semantics to facilitate working with the most popular DI containers.

# Pipelines

The observable pipelines are included in the `Shuttle.Core.Infrastructure` package and provide a mechanism to decouple functionality in order to facilitate re-use and improve extensibility.

# Logging

The logging abstraction is also included in the `Shuttle.Core.Infrastructure` package and enables one to use any implementation of the `ILog` interface.

# Serializer

Serialization is required in various aspects of modern software design and the `ISerializer` interface enables on to swap out the implementation in order to use the most appropriate serializer.

