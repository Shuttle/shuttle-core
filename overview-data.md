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

The following section each describe the methods available in the `IDatabaseGateway` interface.

## GetReaderUsing

~~~ c#
IDataReader GetReaderUsing(IQuery query);
~~~

Returns an `IDataReader` instance for the given `select` statement:

~~~ c#
var factory = DatabaseContextFactory.Default();
var gateway = new DatabaseGateway();

using (var context = factory.Create("connectionStringName"))
{
	var reader = gateway.GetReaderUsing(RawQuery.Create("select Id, Username from dbo.Member"));
}
~~~

## ExecuteUsing

~~~ c#
int ExecuteUsing(IQuery query);
~~~

Executes the given query and returns the number of rows affected:

~~~ c#
var factory = DatabaseContextFactory.Default();
var gateway = new DatabaseGateway();

using (var context = factory.Create("connectionStringName"))
{
	gateway.ExecuteUsing(RawQuery.Create("delete from dbo.Member where Username = 'mr.resistor'"));
}
~~~

## GetScalarUsing<T>

~~~ c#
T GetScalarUsing<T>(IQuery query);
~~~

Get the scalar value returned by the `select` query.  The query shoud return only one value (scalar):

~~~ c#
var factory = DatabaseContextFactory.Default();
var gateway = new DatabaseGateway();

using (var context = factory.Create("connectionStringName"))
{
	var username = gateway.GetScalarUsing<string>(
		RawQuery.Create("select Username from dbo.Member where Id = 10")
	);
	
	var id = gateway.GetScalarUsing<int>(
		RawQuery.Create("select Id from dbo.Member where Username = 'mr.resistor'")
	);
}
~~~

## GetDataTableFor

~~~ c#
DataTable GetDataTableFor(IQuery query);
~~~

Returns a `DataTable` containing the rows returned for the given `select` statement.

~~~ c#
var factory = DatabaseContextFactory.Default();
var gateway = new DatabaseGateway();

using (var context = factory.Create("connectionStringName"))
{
	var table = gateway.GetDataTableFor(RawQuery.Create("select Id, Username from dbo.Member"));
}
~~~

## GetRowsUsing

~~~ c#
IEnumerable<DataRow> GetRowsUsing(IQuery query);
~~~

Returns an enumerable containing the `DataRow` instances returned for a `select` query:

~~~ c#
var factory = DatabaseContextFactory.Default();
var gateway = new DatabaseGateway();

using (var context = factory.Create("connectionStringName"))
{
	var rows = gateway.GetRowsUsing(RawQuery.Create("select Id, Username from dbo.Member"));
}
~~~


## GetSingleRowUsing

~~~ c#
DataRow GetSingleRowUsing(IQuery query);
~~~

Returns a single `DataRow` containing the values returned for a `select` statement that returns exactly one row:

~~~ c#
var factory = DatabaseContextFactory.Default();
var gateway = new DatabaseGateway();

using (var context = factory.Create("connectionStringName"))
{
	var row = gateway.GetSingleRowUsing(
		RawQuery.Create("select Id, Username, EMail, DateActivated from dbo.Member where Id = 10")
	);
}
~~~

# IQuery

An `IQuery` represent a database query that can be executed against the relevant database type.  There is only one method that needs to be implemented:

~~~ c#
void Prepare(IDbCommand command);
~~~

This should ensure that the given `IDbCommand` is configured for execution by setting the relvant command attributes and parameters.

# IQueryParameter: IQuery

An `IQueryParameter` inherits the `IQuery` interface and extends it by allowing you to add parameters to a query by specifying an `IMappedColumn` (see below) instance along with the value for the parameter.

There are two implementations of this interface.

## RawQuery

## ProcedureQuery