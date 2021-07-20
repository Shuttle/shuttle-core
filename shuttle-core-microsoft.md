---
title: Shuttle.Core.Microsoft.Extensions.Logging
layout: api 
---
# Microsoft Extensions Logging

```
PM> Install-Package Shuttle.Core.Microsoft.Extensions.Logging
```

Shuttle logging implementation for [Microsoft's extension logging adapter](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging).

## Usage

``` c#
    using var loggerFactory =
        LoggerFactory.Create(builder =>
            builder.AddSimpleConsole());
    
    Log.Assign(new Logger(loggerFactory.CreateLogger<Program>()));
```