---
title: StructureMap
layout: api
---
# Shuttle.Core.StructureMap

```
PM> Install-Package Shuttle.Core.StructureMap
```

``` c#
var containerBuilder = new Registry();

var registry = new StructureMapComponentRegistry(containerBuilder);

// register all components

var resolver = new StructureMapComponentResolver(new Container(containerBuilder));
```
