---
title: Ninject
layout: api
---
# Shuttle.Core.Ninject

```
PM> Install-Package Shuttle.Core.Ninject
```

The `NinjectComponentContainer` implements both the `IComponentRegistry` and `IComponentResolver` interfaces.  

~~~c#
var container = new NinjectComponentContainer(new StandardKernel());
~~~

