---
title: Shuttle.Core.Data.Http
layout: api
---
# Shuttle.Core.Data.Http

```
PM> Install-Package Shuttle.Core.Data.Http
```

Register, or use, the `ContextDatabaseContextCache` implementation of the `IDatabaseContextCache` interface for use in web/wcf scenarios:

```c#
registry.Register<IDatabaseContextCache, ContextDatabaseContextCache>();
```

## .Net Core 2.0+

In order to gain access to the relevant `HttpContext` you also need to register the following:

```c#
registry.Register<IHttpContextAccessor, HttpContextAccessor>();
```