# Shuttle.Core.Threading

```
PM> Install-Package Shuttle.Core.Threading
```

Provides various classes and interfaces to facilitate thread-based processing.

## ProcessorThreadPool

``` c#
public ProcessorThreadPool(string name, int threadCount, TimeSpan joinTimeout, IProcessorFactory processorFactory)
```

Each thread pool has a `name` used only for identyfing the poollogging.  The `threadCount` determines the number of `ProcessorThread` instances in the pool.  Each `ProcessorThread` calls the `IProcessor.Execute(CancellationToken)` instance provided by the `IProcessorFactory.Create()` method in a loop while the `CancellationToken.IsCancellationRequested` returns `false`.