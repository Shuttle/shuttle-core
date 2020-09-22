---
title: Shuttle.Core.ServiceHost
layout: api 
---
# Shuttle.Core.ServiceHost

<iframe width="560" height="315" src="https://www.youtube.com/embed/vknRxN4-sdo" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>

```
PM> Install-Package Shuttle.Core.ServiceHost
```

Allows you to host your console application.  When using .Net 4.6+ your console may also be hosted as a Windows Service.  When using .Net Core 2.0+ your console hosting can be stopped by sending `ctrl+c` to the console.

A typical implementation would be as follows:

``` c#
using System;
using System.Threading;
using System.Threading.Tasks;
using Shuttle.Core.Threading;

namespace Shuttle.Core.ServiceHost.Server
{
    internal class Program
    {
        private static void Main()
        {
            ServiceHost.Run<Host>();
        }

        public class Host : IServiceHost
        {
            private Task _task;
            private CancellationTokenSource _cancellationTokenSource;
            private CancellationToken _cancellationToken;

            public void Start()
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _cancellationToken = _cancellationTokenSource.Token;

                _task = Task.Run(() =>
                {
                    while (!_cancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine($"[working] : {DateTime.Now:O}");
                        ThreadSleep.While(1000, _cancellationToken);
                    }
                }, _cancellationToken);
            }

            public void Stop()
            {
                _cancellationTokenSource.Cancel();
                _task.Wait();
            }
        }
    }
}
```

Implement the `IServiceHost` interface if you need both `Start()` and `Stop()` methods; else `IServiceHostStart` for `Start()` and `IServiceHostStop` for `Stop()` although there would be little value in having only a `Stop()`.  If you do not need a `Stop()` method or you prefer using `IDisposable` to handle the destruction then you would go with only the `IServiceHostStart` interface.

## Running the host

The following methods are available to get this going on the `ServiceHost` class:

``` c#
public static void Run<T>() where T : IServiceHostStart, new()
public static void Run(IServiceHostStart service)
```

For .Net 4.6+ the following are also available:

``` c#
public static void Run<T>(Action<IServiceConfiguration> configure) where T : IServiceHostStart, new()
public static void Run(IServiceHostStart service, Action<IServiceConfiguration> configure)
```

The `IServiceConfiguration` allows you to configure the service from code.  Configuration supplied through code has the highest precedence.

## .Net 4.6+ options

### Configuration Section

You may also specify configuration using the following configuration which may, as all Shuttle configuration sections do, be grouped under a `shuttle` group.

``` xml
<configuration>
  <configSections>
    <section name="service" type="Shuttle.Core.ServiceHost.ServiceHostSection, Shuttle.Core.ServiceHost" />
  </configSections>

  <service
    serviceName="test-service"
    instance="one"
    username="mr.resistor"
    password="ohm"
    startMode="Disabled" />
</configuration>
```

### Command Line (.Net 4.6+ only)

The following command-line arguments are available and can be viewed by running `{your-console}.exe /?`:

```
[/install [/serviceName]]    
    - install the service
        
[/displayName]                
    - friendly name for the installed service
        
[/description]                
    - Description for the service
        
[/instance]                    
    - unique name of the instance you wish to install
        
[/startMode]            
    - specifies that the service start mode (Boot, System, Automatic, Manual, Disabled)
        
[/delayedAutoStart]
    - if specified will delay services with a start mode of 'Automatic'

[/username /password]
    - username and password of the account to use for the service

- or -
    
[/uninstall [/serviceName] [/instance]]    

[/start]
    - starts the service instance

[/stop]
    - stops the service instance
```

### Service Name

If no `/serviceName` is specified the full name of the your console application along with the version number, e.g.:

```
Namespace.ConsoleApplication (1.0.0.0)
```

### Uninstall

If you set the `/serviceName` and/or `/instance` during installation you will need to specify them when uninstalling as well, e.g.:

```
{your-console}.exe 
    /uninstall 
    /serviceName:"Shuttle.Application.Server" 
    /instance:"Instance5"
```

### Example

```
{your-console}.exe 
    /install 
    /serviceName:"Shuttle.Application.Server" 
    /displayName:"Shuttle server for the application"
    /description:"Service to handle messages relating to the application." 
    /username:"domain\\hostuser"
    /password:"p@ssw0rd!"
```

