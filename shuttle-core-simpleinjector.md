---
title: SimpleInjector
layout: api
---
# Shuttle.Core.SimpleInjector

```
PM> Install-Package Shuttle.Core.SimpleInjector
```

The `SimpleInjectorComponentContainer` implements both the `IComponentRegistry` and `IComponentResolver` interfaces.  

``` c#
var container = new SimpleInjectorComponentContainer(new SimpleInjector.Container());
```

