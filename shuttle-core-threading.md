---
title: Shuttle.Core.Threading
layout: api
---
# Shuttle.Core.Threading

```
PM> Install-Package Shuttle.Core.Threading
```

Provides various classes and interfaces to facilitate thread-based processing.

## ProcessorThreadPool

``` c#
public ProcessorThreadPool(string name, int threadCount, IProcessorFactory processorFactory)
```

Each thread pool has a `name` used only for identyfing the pool and for logging.  The `threadCount` is specified and will run a `Thread` that calls the `IProcessor.Execute(CancellationToken cancellationToken)` instance provided by the `IProcessorFactory.Create()` method in a loop while the `cancellationToken.IsCancellationRequested` returns `false`.