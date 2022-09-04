# Shuttle.Core.Json

```
PM> Install-Package Shuttle.Core.Json
```

A `System.Text.Json` implementation of the `ISerializer` interface.

## Usage

``` c#
services.AddJsonSerializer(builder => {
	builder.Options = new JsonSerializerOptions 
	{
	};

	// or

	buidler.Options.option = value;
});
```

The `builder.Options` is of type [JsonSerializerOptions](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions?view=net-6.0).