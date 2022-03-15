# Shuttle.Core.Json

```
PM> Install-Package Shuttle.Core.Json
```

Json.Net implementation of the `ISerializer` interface.

## Usage

``` c#
var serializer = JsonSerializer.Default();
````

You can also specify `JsonSerializerSettings` when using the constructor to create the `JsonSerializer`:

``` c#
var serializer = new JsonSerializer(new JsonSerializerSettings());
````
