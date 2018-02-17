---
title: Shuttle.Core.Uris
layout: api
---
# Shuttle.Core.Uris

```
PM> Install-Package Shuttle.Core.Uris
```

Provides simple `System.Uri` infrastructure components.

## QueryString

The `QueryString` inherits from `Dictionary<string, string>` so all the dictionary functionality is available.

``` c#
public QueryString()
public QueryString(Uri uri) : this(uri, true)
public QueryString(Uri uri, bool escape)
```

Instantiates the `QueryString` class from the given `System.Uri`.  If `escape` is `true` the query string keys and values will be unescaped using `Uri.UnescapeDataString`.

``` c#
public new void Add(string key, string value)
public void AddUnescaped(string key, string value)
```

Adds the key/value pair to the dictionary.
