---
title: Shuttle.Core.TimeSpanTypeConverters
layout: api
---
# TimeSpanTypeConverters

```
PM> Install-Package Shuttle.Core.TimeSpanTypeConverters
```

Contains type converters for use with `TimeSpan`.

## StringDurationArrayConverter

The `StringDurationArrayConverter` converts from a comma-delimited string that contains durations formatted as `length` followed by `duration` as `ms` (millisecond), `s` (second), `m` (minute), `h` (hour), or `d`.  It can optionally be followed by `*repeat` to repeat the duration for the specifiied number of times.
