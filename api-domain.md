---
title: Shuttle.Core.Domain
layout: api 
---
# IDomainEventDispatcher

## Methods

### Dispatch

``` c#
public void Dispatch<T>(T event) where T: .IDomainEvent
```

TBD

# ActionDomainEventDispatcher

## Methods

### Dispatch

``` c#
public void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent: .IDomainEvent
```

TBD

### Register

``` c#
public void Register<TEvent>(Action<TEvent> eventAction) where TEvent: .IDomainEvent
```

TBD

# DomainEvents

## Methods

### Assign

``` c#
public static void Assign(.IDomainEventDispatcher dispatcherToAssign)
```

TBD

### Raise

``` c#
public static void Raise<TEvent>(TEvent event) where TEvent: .IDomainEvent
```

TBD

# NullDomainEventDispatcher

## Methods

### Dispatch

``` c#
public void Dispatch<T>(T event) where T: .IDomainEvent
```

TBD

# IDomainEventHandler`1

## Methods

### Handle

``` c#
public void Handle(T args)
```

TBD

