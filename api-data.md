---
title: Shuttle.Core.Data
layout: api 
---
# IConnectionStringService

## Methods

### Approve

``` c#
public void Approve()
```

TBD

### Approve

``` c#
public void Approve(System.Configuration.ConnectionStringSettingsCollection connectionStrings)
```

TBD

# ConnectionStringService

## Methods

### Approve

``` c#
public void Approve()
```

TBD

### Approve

``` c#
public void Approve(System.Configuration.ConnectionStringSettingsCollection connectionStrings)
```

TBD

# DataSource

## Properties

### Name

``` c#
public string Name { get; }
```

TBD

### Key

``` c#
public string Key { get; }
```

TBD

### DbDataParameterFactory

``` c#
public IDbDataParameterFactory DbDataParameterFactory { get; }
```

TBD

# IDatabaseConnection

## Properties

### Transaction

``` c#
public System.Data.IDbTransaction Transaction { get; }
```

TBD

### Connection

``` c#
public System.Data.IDbConnection Connection { get; }
```

TBD

### HasTransaction

``` c#
public System.Boolean HasTransaction { get; }
```

TBD

## Methods

### CreateCommandToExecute

``` c#
public System.Data.IDbCommand CreateCommandToExecute(IQuery query)
```

TBD

### BeginTransaction

``` c#
public IDatabaseConnection BeginTransaction()
```

TBD

### CommitTransaction

``` c#
public void CommitTransaction()
```

TBD

# DatabaseConnection

## Properties

### HasTransaction

``` c#
public System.Boolean HasTransaction { get; }
```

TBD

### Transaction

``` c#
public System.Data.IDbTransaction Transaction { get; }
```

TBD

### Connection

``` c#
public System.Data.IDbConnection Connection { get; }
```

TBD

## Methods

### CreateCommandToExecute

``` c#
public System.Data.IDbCommand CreateCommandToExecute(IQuery query)
```

TBD

### BeginTransaction

``` c#
public IDatabaseConnection BeginTransaction()
```

TBD

### CommitTransaction

``` c#
public void CommitTransaction()
```

TBD

### Dispose

``` c#
public void Dispose()
```

TBD

# IDataRepository`1

## Methods

### FetchAllUsing

``` c#
public IEnumerable<T> FetchAllUsing(DataSource source, IQuery query)
```

TBD

### FetchItemUsing

``` c#
public T FetchItemUsing(DataSource source, IQuery query)
```

TBD

### FetchMappedRowUsing

``` c#
public MappedRow<T> FetchMappedRowUsing(DataSource source, IQuery query)
```

TBD

### FetchMappedRowsUsing

``` c#
public IEnumerable<MappedRow<T>> FetchMappedRowsUsing(DataSource source, IQuery query)
```

TBD

### Contains

``` c#
public System.Boolean Contains(DataSource source, IQuery query)
```

TBD

# DataRepository`1

## Methods

### FetchAllUsing

``` c#
public IEnumerable<T> FetchAllUsing(DataSource source, IQuery query)
```

TBD

### FetchItemUsing

``` c#
public T FetchItemUsing(DataSource source, IQuery query)
```

TBD

### FetchMappedRowUsing

``` c#
public MappedRow<T> FetchMappedRowUsing(DataSource source, IQuery query)
```

TBD

### FetchMappedRowsUsing

``` c#
public IEnumerable<MappedRow<T>> FetchMappedRowsUsing(DataSource source, IQuery query)
```

TBD

### Contains

``` c#
public System.Boolean Contains(DataSource source, IQuery query)
```

TBD

# IMappedColumn

## Properties

### ColumnName

``` c#
public string ColumnName { get; }
```

TBD

### DbType

``` c#
public System.Data.DbType DbType { get; }
```

TBD

### Size

``` c#
public int? Size { get; }
```

TBD

### Precision

``` c#
public System.Byte? Precision { get; }
```

TBD

### Scale

``` c#
public System.Byte? Scale { get; }
```

TBD

## Methods

### FlattenedColumnName

``` c#
public string FlattenedColumnName()
```

TBD

### RetrieveRawValueFrom

``` c#
public object RetrieveRawValueFrom(System.Data.DataRow row)
```

TBD

### IsNullFor

``` c#
public System.Boolean IsNullFor(System.Data.DataRow row)
```

TBD

### CreateDataParameter

``` c#
public System.Data.IDbDataParameter CreateDataParameter(IDbDataParameterFactory factory, object value)
```

TBD

# IQuery

## Methods

### Prepare

``` c#
public void Prepare(DataSource source, System.Data.IDbCommand command)
```

TBD

### AddParameterValue

``` c#
public IQuery AddParameterValue(IMappedColumn column, object value)
```

TBD

# RawQuery

## Methods

### Prepare

``` c#
public void Prepare(DataSource source, System.Data.IDbCommand command)
```

TBD

### AddParameterValue

``` c#
public IQuery AddParameterValue(IMappedColumn column, object value)
```

TBD

### Create

``` c#
public static IQuery Create(string sql, params object[] args)
```

TBD

# AssemblerExtensions

## Methods

### AssembleItem

``` c#
public static T AssembleItem<T>(this IAssembler<T> assembler, MappedData data) where T: class
```

TBD

# IAssembler`1

## Methods

### Assemble

``` c#
public IEnumerable<T> Assemble(MappedData data)
```

TBD

# IDataRowMapper`1

## Methods

### Map

``` c#
public MappedRow<T> Map(System.Data.DataRow row)
```

TBD

# MappedData

## Methods

### Add

``` c#
public MappedData Add<T>(MappedRow<T> mappedRow)
```

TBD

### Add

``` c#
public MappedData Add<T>(IEnumerable<MappedRow<T>> mappedRows)
```

TBD

### MappedRows

``` c#
public IEnumerable<MappedRow<T>> MappedRows<T>()
```

TBD

### MappedRows

``` c#
public IEnumerable<MappedRow<T>> MappedRows<T>(Func<MappedRow<T>,System.Boolean> func)
```

TBD

# MappedRow`1

## Properties

### Row

``` c#
public System.Data.DataRow Row { get; }
```

TBD

### Result

``` c#
public T Result { get; }
```

TBD

# MappingExtensions

## Methods

### MappedRowsUsing

``` c#
public static IEnumerable<MappedRow<T>> MappedRowsUsing<T>(this IEnumerable<System.Data.DataRow> rows, IDataRowMapper<T> mapper) where T: class
```

TBD

# ProcedureQuery

## Methods

### Prepare

``` c#
public void Prepare(DataSource source, System.Data.IDbCommand command)
```

TBD

### AddParameterValue

``` c#
public IQuery AddParameterValue(IMappedColumn column, object value)
```

TBD

### Create

``` c#
public static IQuery Create(string procedure)
```

TBD

# DataResources

## Properties

### ResourceManager

``` c#
public static System.Resources.ResourceManager ResourceManager { get; }
```

TBD

### Culture

``` c#
public static void Culture { public get; set; }
```

TBD

### ConnectionStringApproved

``` c#
public static string ConnectionStringApproved { get; }
```

TBD

### ConnectionStringMissing

``` c#
public static string ConnectionStringMissing { get; }
```

TBD

### CouldNotCreateQueryBuilder

``` c#
public static string CouldNotCreateQueryBuilder { get; }
```

TBD

### CreateConnectionException

``` c#
public static string CreateConnectionException { get; }
```

TBD

### DatabaseConnectionCreated

``` c#
public static string DatabaseConnectionCreated { get; }
```

TBD

### DbConnectionCreated

``` c#
public static string DbConnectionCreated { get; }
```

TBD

### DbConnectionOpened

``` c#
public static string DbConnectionOpened { get; }
```

TBD

### DbConnectionOpenException

``` c#
public static string DbConnectionOpenException { get; }
```

TBD

### DbProviderFactoryCached

``` c#
public static string DbProviderFactoryCached { get; }
```

TBD

### DuplicateQueryFactory

``` c#
public static string DuplicateQueryFactory { get; }
```

TBD

### ExistingDatabaseConnectionReturned

``` c#
public static string ExistingDatabaseConnectionReturned { get; }
```

TBD

### MissingQueryFactory

``` c#
public static string MissingQueryFactory { get; }
```

TBD

### ThreadStaticDatabaseConnectionCacheMissingEntry

``` c#
public static string ThreadStaticDatabaseConnectionCacheMissingEntry { get; }
```

TBD

### UnsupportedIQueryImplementation

``` c#
public static string UnsupportedIQueryImplementation { get; }
```

TBD

# IDbDataParameterFactory

## Methods

### Create

``` c#
public System.Data.IDbDataParameter Create(string name, System.Data.DbType type, object value)
```

TBD

### Create

``` c#
public System.Data.IDbDataParameter Create(string name, System.Data.DbType type, int size, object value)
```

TBD

### Create

``` c#
public System.Data.IDbDataParameter Create(string name, System.Data.DbType type, System.Byte precision, System.Byte scale, object value)
```

TBD

# SqlDbDataParameterFactory

## Methods

### Create

``` c#
public System.Data.IDbDataParameter Create(string name, System.Data.DbType type, object value)
```

TBD

### Create

``` c#
public System.Data.IDbDataParameter Create(string name, System.Data.DbType type, int size, object value)
```

TBD

### Create

``` c#
public System.Data.IDbDataParameter Create(string name, System.Data.DbType type, System.Byte precision, System.Byte scale, object value)
```

TBD

# IDatabaseConnectionCache

## Methods

### Get

``` c#
public IDatabaseConnection Get(DataSource source)
```

TBD

### Add

``` c#
public IDatabaseConnection Add(DataSource source, IDatabaseConnection connection)
```

TBD

### Remove

``` c#
public void Remove(DataSource source)
```

TBD

### Contains

``` c#
public System.Boolean Contains(DataSource source)
```

TBD

# ThreadStaticDatabaseConnectionCache

## Methods

### Get

``` c#
public IDatabaseConnection Get(DataSource source)
```

TBD

### Add

``` c#
public IDatabaseConnection Add(DataSource source, IDatabaseConnection connection)
```

TBD

### Remove

``` c#
public void Remove(DataSource source)
```

TBD

### Contains

``` c#
public System.Boolean Contains(DataSource source)
```

TBD

# IDatabaseConnectionFactory

## Methods

### Create

``` c#
public IDatabaseConnection Create(DataSource source)
```

TBD

# DatabaseConnectionFactory

## Methods

### Default

``` c#
public static IDatabaseConnectionFactory Default()
```

TBD

### Create

``` c#
public IDatabaseConnection Create(DataSource source)
```

TBD

# IDatabaseGateway

## Methods

### GetReaderUsing

``` c#
public System.Data.IDataReader GetReaderUsing(DataSource source, IQuery query)
```

TBD

### ExecuteUsing

``` c#
public int ExecuteUsing(DataSource source, IQuery query)
```

TBD

### GetScalarUsing

``` c#
public T GetScalarUsing<T>(DataSource source, IQuery query)
```

TBD

### GetDataTableFor

``` c#
public System.Data.DataTable GetDataTableFor(DataSource source, IQuery query)
```

TBD

### GetRowsUsing

``` c#
public IEnumerable<System.Data.DataRow> GetRowsUsing(DataSource source, IQuery query)
```

TBD

### GetSingleRowUsing

``` c#
public System.Data.DataRow GetSingleRowUsing(DataSource source, IQuery query)
```

TBD

# DatabaseGateway

## Methods

### Default

``` c#
public static IDatabaseGateway Default()
```

TBD

### GetDataTableFor

``` c#
public System.Data.DataTable GetDataTableFor(DataSource source, IQuery query)
```

TBD

### GetRowsUsing

``` c#
public IEnumerable<System.Data.DataRow> GetRowsUsing(DataSource source, IQuery query)
```

TBD

### GetSingleRowUsing

``` c#
public System.Data.DataRow GetSingleRowUsing(DataSource source, IQuery query)
```

TBD

### GetReaderUsing

``` c#
public System.Data.IDataReader GetReaderUsing(DataSource source, IQuery query)
```

TBD

### ExecuteUsing

``` c#
public int ExecuteUsing(DataSource source, IQuery query)
```

TBD

### GetScalarUsing

``` c#
public T GetScalarUsing<T>(DataSource source, IQuery query)
```

TBD

# IDbCommandFactory

## Methods

### CreateCommandUsing

``` c#
public System.Data.IDbCommand CreateCommandUsing(DataSource source, System.Data.IDbConnection connection, IQuery query)
```

TBD

# DbCommandFactory

## Methods

### CreateCommandUsing

``` c#
public System.Data.IDbCommand CreateCommandUsing(DataSource source, System.Data.IDbConnection connection, IQuery query)
```

TBD

# IDbConnectionConfiguration

## Properties

### Name

``` c#
public string Name { get; }
```

TBD

### ProviderName

``` c#
public string ProviderName { get; }
```

TBD

### ConnectionString

``` c#
public string ConnectionString { get; }
```

TBD

# DbConnectionConfiguration

## Properties

### Name

``` c#
public string Name { get; }
```

TBD

### ProviderName

``` c#
public string ProviderName { get; }
```

TBD

### ConnectionString

``` c#
public string ConnectionString { get; }
```

TBD

# IDbConnectionConfigurationProvider

## Methods

### Get

``` c#
public IDbConnectionConfiguration Get(DataSource source)
```

TBD

# DbConnectionConfigurationProvider

## Methods

### Get

``` c#
public IDbConnectionConfiguration Get(DataSource source)
```

TBD

# IDbConnectionFactory

## Methods

### CreateConnection

``` c#
public System.Data.IDbConnection CreateConnection(DataSource source)
```

TBD

# DbConnectionFactory

## Methods

### Default

``` c#
public static IDbConnectionFactory Default()
```

TBD

### CreateConnection

``` c#
public System.Data.IDbConnection CreateConnection(DataSource source)
```

TBD

# MappedColumn`1

## Properties

### ColumnName

``` c#
public string ColumnName { get; }
```

TBD

### DbType

``` c#
public System.Data.DbType DbType { get; }
```

TBD

### Size

``` c#
public int? Size { get; }
```

TBD

### Precision

``` c#
public System.Byte? Precision { get; }
```

TBD

### Scale

``` c#
public System.Byte? Scale { get; }
```

TBD

## Methods

### MapFrom

``` c#
public T MapFrom(System.Data.DataRow row)
```

TBD

### MapFrom

``` c#
public T MapFrom(System.Data.IDataRecord record)
```

TBD

### FlattenedColumnName

``` c#
public string FlattenedColumnName()
```

TBD

### RetrieveRawValueFrom

``` c#
public object RetrieveRawValueFrom(System.Data.DataRow row)
```

TBD

### IsNullFor

``` c#
public System.Boolean IsNullFor(System.Data.DataRow row)
```

TBD

### CreateDataParameter

``` c#
public System.Data.IDbDataParameter CreateDataParameter(IDbDataParameterFactory factory, object value)
```

TBD

### Rename

``` c#
public MappedColumn<T> Rename(string name)
```

TBD

# ExistingDatabaseConnection

## Properties

### HasTransaction

``` c#
public System.Boolean HasTransaction { get; }
```

TBD

### Transaction

``` c#
public System.Data.IDbTransaction Transaction { get; }
```

TBD

### Connection

``` c#
public System.Data.IDbConnection Connection { get; }
```

TBD

## Methods

### Dispose

``` c#
public void Dispose()
```

TBD

### CreateCommandToExecute

``` c#
public System.Data.IDbCommand CreateCommandToExecute(IQuery query)
```

TBD

### BeginTransaction

``` c#
public IDatabaseConnection BeginTransaction()
```

TBD

### CommitTransaction

``` c#
public void CommitTransaction()
```

TBD

