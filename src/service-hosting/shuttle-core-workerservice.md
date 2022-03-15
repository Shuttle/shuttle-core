# Shuttle.Core.WorkerService

```
PM> Install-Package Shuttle.Core.WorkerService
```

A simple wrapper built around the `Microsoft.Extensions.Hosting` that allows you to host your Net 5.0+ console application.  On Windows you can host the resulting console application as a Windows Service.  On Linux you would use Systemd to host the service.

## Implementation

A typical implementation would be as follows:

``` c#
using System;
using System.Threading;
using Shuttle.Core.WorkerService;

namespace Shuttle.Core.ServiceHost.Server
{
    internal class Program
    {
        private static void Main()
        {
            ServiceHost.Run<TestHost>();
        }

        public class TestHost : IServiceHost
        {
            private readonly Thread _thread;
            private volatile bool _active;

            public TestHost()
            {
                _thread = new Thread(Worker);
            }

            public void Start()
            {
                _active = true;
                _thread.Start();
            }

            public void Stop()
            {
                _active = false;
                _thread.Join(5000);
            }

            public bool Active => _active;

            private void Worker()
            {
                while (_active)
                {
                    Console.WriteLine($"[working] : {DateTime.Now:O}");
                    ThreadSleep.While(1000, this);
                }
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

## Windows

Installing on `Windows` requires using the [sc utility](https://docs.microsoft.com/en-us/windows/win32/services/controlling-a-service-using-sc):

``` cmd
sc create {service-name} binPath={path-to-exe}
```

## Linux

Using `Systemd` on `Linux` would require a `{SserviceName}.service` file in the `/etc/systemd/system/` folder:

``` sh
[Unit]
Description=Service created using Shuttle.Core.WorkerService

[Service]
ExecStart=/srv/somewhere/ServiceName
# journalctl identifier
SyslogIdentifier=HelloWorld

User=username

Environment=DOTNET_ROOT={dotnet-path}

[Install]
WantedBy=multi-user.target
```

Then reload the `Systemd` configuration:

``` sh
sudo systemctl daemon-reload
sudo systemctl start {ServiceName}
```

You can then view the status using:

``` sh
sudo systemctl status {ServiceName}
```

The log can be viewed as follows:

``` sh
sudo journalctl -u {ServiceName}
```