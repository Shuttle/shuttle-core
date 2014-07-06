---
title: Shuttle.Core.Infrastructure.Log4Net
layout: api 
---
# ActionAppender

## Methods

### Register

``` c#
public static void Register(Action<log4net.Core.LoggingEvent> action)
```

TBD

# Log4NetLog

## Properties

### IsTraceEnabled

``` c#
public System.Boolean IsTraceEnabled { get; }
```

TBD

### IsDebugEnabled

``` c#
public System.Boolean IsDebugEnabled { get; }
```

TBD

### IsInformationEnabled

``` c#
public System.Boolean IsInformationEnabled { get; }
```

TBD

### IsWarningEnabled

``` c#
public System.Boolean IsWarningEnabled { get; }
```

TBD

### IsErrorEnabled

``` c#
public System.Boolean IsErrorEnabled { get; }
```

TBD

### IsFatalEnabled

``` c#
public System.Boolean IsFatalEnabled { get; }
```

TBD

## Methods

### Verbose

``` c#
public void Verbose(string message)
```

TBD

### Trace

``` c#
public void Trace(string message)
```

TBD

### Debug

``` c#
public void Debug(string message)
```

TBD

### Warning

``` c#
public void Warning(string message)
```

TBD

### Information

``` c#
public void Information(string message)
```

TBD

### Error

``` c#
public void Error(string message)
```

TBD

### Fatal

``` c#
public void Fatal(string message)
```

TBD

### For

``` c#
public ILog For(System.Type type)
```

TBD

### For

``` c#
public ILog For(object instance)
```

TBD

[Shuttle.Core.Infrastructure.ILog]: {{ BASE_PATH }}/api-infrastructure/#ILog

