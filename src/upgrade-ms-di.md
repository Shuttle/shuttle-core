# Breaking Changes

With the introduction of <a href="https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection" target="_blank">.NET dependency injection</a> as well as the <a href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options" target="_blank">options pattern</a> into the `Shuttle.Core` components, some packages are no longer required and support for them will be dropped in due course.

These include the `Shuttle.Core.Container`, `Shuttle.Core.Logging`, generic hosting, as well as all related and derived packages.

Logging is no longer directly implemented in any of the components.  Instead, where required, events are raised that may be handled in client applications where the appropriate <a href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging" target="_blank">logging</a> should occur.

Please see the documentation for each of the relevant packages to see how to make use of them now.