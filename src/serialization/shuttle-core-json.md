# Shuttle.Core.Json

```
PM> Install-Package Shuttle.Core.Json
```

A `System.Text.Json` implementation of the `ISerializer` interface.

## Usage

``` c#
services.AddJsonSerializer(builder => {
	builder.Options = options;
	// or
	buidler.Options.option = value;
});
```

