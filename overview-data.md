---
title: Data
layout: api
---
# Overview

The `Shuttle.Core.Data` package provides a thin abstraction over ADO.NET by making use of the `DbProviderFactories`.  Even though it provides object/relational mapping mechasnims it is in no way an ORM.

# IDatabaseContextFactory

As per usual, in order to access a database, we need a database connection.  A database connection is represented by a `IDatabaseContext` instance that may be obtained by using an instance of an `IDatabaseContextFactory` implementation.

The `DatabaseContextFactory` implmentation makes use of an `IDbConnectionFactory` implementation, that creates a `System.Data.IDbConnection` by using the provider name and connection string, an `IDbCommandFactory` that creates a `System.Data.IDbCommand` by using `IDbConnection` instance.  The `DatabaseContextFactory` also requires an instance of a `IDatabaseContextCache` that stores connections and is assigned to the `DatabaseContext` in order to obtain the active connection.

~~~ c#
var factory = DatabaseContextFactory.Default();

using (var context = factory.Create("connectionStringName"))
{
	// database interaction
}

using (var context = factory
	.Create("System.Data.SqlClient", 
		"Data Source=.\sqlexpress;Initial Catalog=Shuttle;Integrated Security=SSPI"))
{
	// database interaction
}

using (var context = factory.Create(existingIDbConnection))
{
	// database interaction
}
~~~

# IDatabaseGateway

The `DatabaseGateway` is used to execute `IQuery` instances in order return data from, or make changes to, the underlying data store.  If there is no active open `IDatabaseContext` returned by the `DatabaseContext.Current` and `InvalidOperationException` will be thrown.

~~~ c#
var factory = DatabaseContextFactory.Default();
var gateway = new DatabaseGateway();

using (var context = factory.Create("connectionStringName"))
{
	var table = gateway.GetDataTableFor(RawQuery.Create("select UserName from dbo.Member where id = 10");
}
~~~
