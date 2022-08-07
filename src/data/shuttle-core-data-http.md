# Shuttle.Core.Data.Http

```
PM> Install-Package Shuttle.Core.Data.Http
```

Provides the `ContextDatabaseContextCache` implementation of the `IDatabaseContextCache` interface for use in web/wcf scenarios:

```
services.AddHttpDatabaseContextCache();
```

## .Net Core 2.0+

In order to gain access to the relevant `HttpContext` you also need to register the following:

```c#
services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
```

