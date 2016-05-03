---
title: Data (Dependency Injection)
layout: api
---
# Dependency Injection

When using a dependency injection container there are a couple of thing that need to be wired up.  The following describes that required wiring in a container agnostic way and then shows how you would go about doing so using the `WindsorContainer` from the **Castle Project**.

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

## WindsorContainer Example

~~~ c#
public class CompositionRoot
{
	public void WireUp(IWindsorContainer container)
	{
		container.Register(Component.For<IDatabaseContextCache>()
			.ImplementedBy<ThreadStaticDatabaseContextCache>());
		container.Register(Component.For<IDatabaseGateway>()
			.ImplementedBy<DatabaseGateway>());
		container.Register(Component.For(typeof (IDataRepository<>))
			.ImplementedBy(typeof (DataRepository<>)));

		container.Register(
			Classes
				.FromAssemblyNamed("Shuttle.Core.Data")
				.Pick()
				.If(type => type.Name.EndsWith("Factory"))
				.Configure(configurer => 
					configurer.Named(configurer.Implementation.Name.ToLower()))
				.WithService.Select((type, basetype) => 
					new[] {type.InterfaceMatching(@".*Factory\Z")}));

		container.Register(
			Classes
				.FromThisAssembly()
				.BasedOn(typeof (IDataRowMapper<>))
				.WithServiceFirstInterface());
	}
}
~~~
