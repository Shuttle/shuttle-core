---
title: Shuttle.Core.Host
layout: api 
---
# ArgumentsExtensions

## Methods

### ShouldShowHelp

``` c#
public static System.Boolean ShouldShowHelp(this Arguments arguments)
```

TBD

# Host

## Methods

### RunService

``` c#
public void RunService(IHost host, Arguments arguments)
```

TBD

### GetDefaultDisplayName

``` c#
public static string GetDefaultDisplayName(string serviceName, object hostTypeInstance)
```

TBD

# HostFactory

## Methods

### Create

``` c#
public IHost Create(Arguments arguments)
```

TBD

### GetAssembliesToScan

``` c#
public IEnumerable<System.Reflection.Assembly> GetAssembliesToScan()
```

TBD

# IHostServiceConfiguration

## Properties

### Host

``` c#
public IHost Host { get; }
```

TBD

### ServiceName

``` c#
public void ServiceName { public get; set; }
```

TBD

### DisplayName

``` c#
public void DisplayName { public get; set; }
```

TBD

### Description

``` c#
public void Description { public get; set; }
```

TBD

### Instance

``` c#
public void Instance { public get; set; }
```

TBD

### UserName

``` c#
public void UserName { public get; set; }
```

TBD

### Password

``` c#
public void Password { public get; set; }
```

TBD

### StartManually

``` c#
public void StartManually { public get; set; }
```

TBD

# HostServiceConfiguration

## Properties

### Host

``` c#
public IHost Host { get; }
```

TBD

### ServiceName

``` c#
public void ServiceName { public get; set; }
```

TBD

### DisplayName

``` c#
public void DisplayName { public get; set; }
```

TBD

### Description

``` c#
public void Description { public get; set; }
```

TBD

### Instance

``` c#
public void Instance { public get; set; }
```

TBD

### UserName

``` c#
public void UserName { public get; set; }
```

TBD

### Password

``` c#
public void Password { public get; set; }
```

TBD

### StartManually

``` c#
public void StartManually { public get; set; }
```

TBD

# IHost

## Methods

### Start

``` c#
public void Start()
```

TBD

# IHostServiceRunner

## Methods

### Run

``` c#
public void Run(IHostServiceConfiguration configuration)
```

TBD

# Program

## Methods

### Main

``` c#
public static void Main(params string[] args)
```

TBD

[Shuttle.Core.Infrastructure.Arguments]: {{ BASE_PATH }}/api-infrastructure/#Arguments
