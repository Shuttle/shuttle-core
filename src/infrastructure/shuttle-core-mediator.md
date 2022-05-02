# Shuttle.Core.Mediator

```
PM> Install-Package Shuttle.Core.Mediator
```

The Shuttle.Core.Mediator package provides a [mediator pattern](https://en.wikipedia.org/wiki/Mediator_pattern) implementation.

## IMediator

The core interface is the `IMediator` interface and the default implementation provided is the `Mediator` class.

This interface provides a synchronous calling mechanism and all `IParticipant` implementations need to be thread-safe singleton implementations that are added to the mediator at startup.  Any operations that require transient mechanisms should be handled by the relevant participant.

```c#
IMediator Add(object participant);
```

The `Add` method registers the given participant.

```c#
void Send(object message, CancellationToken cancellationToken = default);
```

The `Send` method will find all participants that implements the `IParticipant<T>` with the type `T` of the message type that you are sending.  Participants that are marked with the `BeforeObserverAttribute` filter will be executed first followed by all participants with no filters attributes and then finally all participants marked with the `AfterObserverAttribute` filter will be called.

### Extensions

```c#
Task SendAsync(this IMediator mediator, object message, CancellationToken cancellationToken = default)
```
Sends a message asynchronously.

```c#
public static T Send<T>(this IMediator mediator, T message, CancellationToken cancellationToken = default);
```

The same as `Send` except that it returns the given message.

## IParticipant

```c#
public interface IParticipant<in T>
{
    void ProcessMessage(IParticipantContext<T> context);
}
```

A participant would handle the message that is sent using the mediator.  There may be any number of participants that process the message. 

## Design philosophy

There are no *request/response* semantics and the design philosophy here is that the message encapsulates the state that is passed along in a *pipes & filters* approach.

However, you may wish to make use of one of the existing utility classes:-

### RequestMessage\<TRequest\>

The only expectation from a `RequestMessage<TRequest>` instance is either a success or failure (along with the failure message).

### RequestResponseMessage\<TRequest, TResponse\>

The `RequestResponseMessage<TRequest, TResponse>` takes an initial `TRequest` object and after the mediator processing would expect that there be a `TResponse` provided using the `.WithResponse(TResponse)` method.  The same success/failure mechanism used in the `RequestMessage<TRequest>` calss is also available on this class.

## Registration

In order to get all the relevant bits working you would need to register the `IMediator` dependency along with all the relevant `IParticipant` dependencies.

You can register the mediator using `ComponentRegistryExtensions.RegisterMediator(IComponentRegistry)`.

The participants may be registered using the following `ComponentRegistryExtensions` methods:

```c#
public static void RegisterMediatorParticipants(this IComponentRegistry registry, Assembly assembly);
```

## Considerations

If you have a rather predictable sequential workflow and you require something faster execution then you may wish to consider the [Shuttle.Core.Pipelines](http://shuttle.github.io/shuttle-core/shuttle-core-pipelines) package.  A performance testing application for your use-case would be able to indicate the more suitable option.
