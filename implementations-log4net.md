---
title: Log4Net Implementation
layout: api 
---
# Log4Net

In order to use the `Log4Net` implementation assign the new log as early as possible to the start of your application's execution and before any calls to the logging mechanism:

``` c#
Log.Assign(new Log4NetLog(LogManager.GetLogger(typeof(Host))));
```

All configuration would follow the usual `Log4Net` practices.

After the log has been assigned you can start using it in much the same way you would use `Log4Net`.

