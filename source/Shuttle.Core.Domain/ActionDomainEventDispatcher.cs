using System;
using System.Collections.Generic;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Domain
{
    public class ActionDomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly List<Delegate> handlers = new List<Delegate>();

        public void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        {
            foreach (var handler in handlers)
            {
                if (!(handler is Action<TEvent>))
                {
                    continue;
                }

                ((Action<TEvent>)handler).Invoke(eventToDispatch);
            }
        }

        public void Register<TEvent>(Action<TEvent> eventAction) where TEvent : IDomainEvent
        {
            Guard.AgainstNull(eventAction, "eventAction");

            handlers.Add(eventAction);
        }
    }
}