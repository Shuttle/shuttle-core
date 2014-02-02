---
title: Shuttle.Core.Infrastructure
layout: api 
---

# `Shuttle.Core.Infrastructure`

## `ObjectExtensions`

### `AttemptDispose`

_Parameters_

Parameter | Type | Description
--- | --- | ---
`o` | `object` | The object to attempt the `Dispose()` on.

If the given object can be cast to `IDisposable` the `Dispose()` method is invoked; else does nothing.

_Returns_

`void`
