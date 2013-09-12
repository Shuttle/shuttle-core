using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Domain
{
    public static class DomainEvents
    {
        private static IDomainEventDispatcher dispatcher = new NullDomainEventDispatcher();

        public static void Assign(IDomainEventDispatcher dispatcherToAssign)
        {
            Guard.AgainstNull(dispatcherToAssign, "dispatcherToAssign");

            dispatcher = dispatcherToAssign;
        }

        public static void Raise<TEvent>(TEvent @event) where TEvent : IDomainEvent
        {
            Guard.AgainstNull(@event, "@event");

            dispatcher.Dispatch(@event);
        }
    }
}