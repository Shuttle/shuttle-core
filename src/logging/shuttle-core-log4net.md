---
title: Shuttle.Core.Log4Net
layout: api 
---
# Shuttle.Core.Log4Net

```
PM> Install-Package Shuttle.Core.Log4Net
```

Log4Net `ILog` implementation used by the `Log` class in the `Shuttle.Core.Logging` assembly.

# Usage

Add a reference to the `Shuttle.Core.Log4Net` package and then assign a new `Log4NetLog` to the `Log` as follows:

## .NET 4.6+

``` c#
Log.Assign(new Log4NetLog(LogManager.GetLogger(typeof(Program))));
```

## .NET Core 2.0+

The .NET Core 1.3 implementation provided by Log4Net does not make use of the application configuration file as it only appeared again in .NET Core 2.0.  A custom configuration file has to be used in the meantime.

``` c#
Log.Assign(new Log4NetLog(LogManager.GetLogger(typeof(Program), new FileInfo("log4net.config"))));
```

When assigning the logger *always* use the `Log4NetLog` with the `FileInfo` overload to perform the configuration; else nothing will log.

# Configuration

For .NET Core you'll need to either use a custom configuration file (not the application configuration file) or reference the `System.Configuration.ConfigurationManager`.  Referencing the `Shuttle.Core.Configuration` package should also do the trick.

Since this implementation wraps the `Log4Net` log you would use the `Log4Net` [configuration options](https://logging.apache.org/log4net/release/manual/configuration.html).

Here is a sample configuration but there are [many examples online](https://logging.apache.org/log4net/release/config-examples.html):

``` xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <configSections>
        <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net"/>
    </configSections>

    <log4net>
        <appender name="ConsoleAppender" type="log4net.Appender.ColoredConsoleAppender">
            <layout type="log4net.Layout.PatternLayout">
                <conversionPattern value="%d [%t] %-5p %c - %m%n"/>
            </layout>
        </appender>
        <appender name="RollingFileAppender" type="log4net.Appender.RollingFileAppender">
            <file value="logs\\program"/>
            <appendToFile value="true"/>
            <rollingStyle value="Composite"/>
            <maxSizeRollBackups value="10"/>
            <maximumFileSize value="100000KB"/>
            <datePattern value="-yyyyMMdd.'log'"/>
            <param name="StaticLogFileName" value="false"/>
            <layout type="log4net.Layout.PatternLayout">
                <conversionPattern value="%d [%t] %-5p %c - %m%n"/>
            </layout>
        </appender>
        <root>
            <level value="TRACE"/>
            <appender-ref ref="ConsoleAppender"/>
            <appender-ref ref="RollingFileAppender"/>
        </root>
    </log4net>
</configuration>
```