---
title: Serializer
layout: api
---
# Shuttle.Core.Serialization

```
PM> Install-Package Shuttle.Core.Serialization
```

An implementation of the `ISerializer` interface is used to serialize objects into a `Stream`.

The `DefaultSerializer` makes use of the standard .NET xml serialization functionality.

## Methods

### Serialize

``` c#
Stream Serialize(object message);
```

Returns the message `object` as a `Stream`.

### Deserialize

``` c#
object Deserialize(Type type, Stream stream);
```

Deserializes the `Stream` into an `obejct` of the given type.

# ISerializerRootType

The `ISerializerRootType` interface is an optional interface that serializer implementations can use that allows the developer to specify explicit object types contained within a root type.  

The `DefaultSerializer` implements this interface and it is recommended that you explicitly register types with the same name, but in different namespaes, that will be serialized within the same root type to avoid any conflicts later down the line.

For instance, the following two types will cause issues when used in the root `Complex` type as they both serialize to the same name and the .Net serializer cannot seem to distinguish the difference:

``` c#
namespace Serializer.v1
{
	public class MovedEvent
	{
		public string Where { get; set; } 
	}
}

namespace Serializer.v2
{
	public class MovedEvent
	{
		public string Where { get; set; } 
	}
}

namespace Serializer
{
	public class Complex
	{
		public v1.MovedEvent { get; set; }
		public v2.MovedEvent { get; set; }
	}
}
```

By explicitly specifying the types the `DefaultSerializer` will add a namespace that will cause the types to be correctly identified.

## AddSerializerType

``` c#
void AddSerializerType(Type root, Type contained);
```

Specify the `contained` tpe that is used within te `root` type somewhere.