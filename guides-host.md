---
title: Shuttle.Core.Host
layout: api 
---
# Shuttle.Core.Host

The generic host is used to execute code either within a console window or as a Windows service.

When the generic host is executed it searches for all classes that implement the `IHost`.  It needs to find exactly 1 class implementing the interface else it fails with an exception.  If you *do* have more than one type implementing the interface you can specify the interface using an argument:

```
/hostType="assembly qualified name"
```

In order to debug applications that use the `IHost` interface you would simply need to set the `Shuttle.Core.Host.exe` as the startup application for your project:

![Host Debug Image]({{ BASE_PATH }}/assets/images/host-debug.png "Host Debug")

So a typical