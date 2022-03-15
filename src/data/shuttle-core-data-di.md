---
title: Shuttle.Core.Data (Dependency Injection)
layout: api
---
# Dependency Injection

When using a dependency injection container there are a couple of things that need to be wired up.  The following describes that required wiring in a container agnostic way:

| Interface | Implementation | Comments |
| --- | --- | --- |
| IDatabaseContextCache | ThreadStaticDatabaseContextCache | Use this in Windows Service / Console solutions (such as when using the Shuttle.Core.Host). |
|  | ContextDatabaseContextCache | Use this in a Web / Web-Api / WCF scenario.  Contained in the Shuttle.Core.Data.Http package. |
| IDatabaseGateway | DatabaseGateway | |
| IDatabaseContextFactory | DatabaseContextFactory | |
| IDbConnectionFactory | DbConnectionFactory | |
| IDbCommandFactory | DbCommandFactory | |
| IDataRepository<> | typeof (DataRepository<>) | Your container should support an open generic construct. |
| All Classes | typeof (IDataRowMapper<>) | Your container should be able to find all open generic implementations of the `IDataRowMapper<T>` interface |

When using the [container bootstrapping](http://shuttle.github.io/shuttle-core/overview-container/#Bootstrapping) and you have referenced `Shuttle.Core.Data` the following registrations will be attempted:

```c#
registry.AttemptRegister<IConnectionConfigurationProvider, ConnectionConfigurationProvider>();
registry.AttemptRegister<IDatabaseContextCache, ThreadStaticDatabaseContextCache>();
registry.AttemptRegister<IDatabaseContextFactory, DatabaseContextFactory>();
registry.AttemptRegister<IDbConnectionFactory, DbConnectionFactory>();
registry.AttemptRegister<IDbCommandFactory, DbCommandFactory>();
registry.AttemptRegister<IDatabaseGateway, DatabaseGateway>();
registry.AttemptRegister<IQueryMapper, QueryMapper>();
```

If you need to use another specific implementation of `IDatabaseContextCache` remember to register that before the bootstrapping code.

You may also want to use the `IComponentRegistry.RegisterSuffixed()` extension method to register data, and other, components that end with the following default suffixes:

```c#
public static readonly List<string> DefaultSuffixes = new List<string>
{
    "Query",
    "Repository",
    "Provider",
    "Service",
    "Task",
    "Factory",
    "Mapper",
    "Cache"
};
```