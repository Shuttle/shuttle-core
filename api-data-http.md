---
title: Shuttle.Core.Data.Http
layout: api 
---
# ContextDatabaseConnectionCache

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

# ItemOperationContext

## Properties

### Items

``` c#
public System.Collections.IDictionary Items { get; }
```

TBD

### Current

``` c#
public static Http.ItemOperationContext Current { get; }
```

TBD

## Methods

### Attach

``` c#
public void Attach(System.ServiceModel.OperationContext owner)
```

TBD

### Detach

``` c#
public void Detach(System.ServiceModel.OperationContext owner)
```

TBD

[Shuttle.Core.Data.IDatabaseConnection]: {{ site.baseurl }}/api-data/#IDatabaseConnection
[Shuttle.Core.Data.DataSource]: {{ site.baseurl }}/api-data/#DataSource
