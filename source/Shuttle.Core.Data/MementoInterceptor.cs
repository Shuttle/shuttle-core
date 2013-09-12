using System;
using System.Collections.Generic;
using Castle.Shuttle.Core.Interceptor;

namespace Shuttle.Core.ORM
{
    public class MementoInterceptor : IInterceptor
    {
        private readonly Dictionary<string, object> state = new Dictionary<string, object>();

        private bool hasChanged;

        #region IInterceptor Members

        public void Intercept(IInvocation invocation)
        {
            var method = invocation.Method.Name;

            var key = method.Length > 4
                              ? method.Substring(4)
                              : string.Empty;

            if (method.StartsWith("set_", StringComparison.InvariantCultureIgnoreCase))
            {
                if (state.ContainsKey(key))
                {
                    state.Remove(key);
                }

                state.Add(key, invocation.Arguments[0]);

                hasChanged = true;
            }
            else
            {
                if (method == "get_HasChanged")
                {
                    invocation.ReturnValue = hasChanged;
                }
                else
                {
                    if (method.StartsWith("get_", StringComparison.InvariantCultureIgnoreCase))
                    {
                        invocation.ReturnValue = state.ContainsKey(key)
                                                         ? state[key]
                                                         : null;
                    }
                    else
                    {
                        if (method == "ResetChangeTracking")
                        {
                            hasChanged = false;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
