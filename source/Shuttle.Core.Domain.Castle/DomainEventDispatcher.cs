using Castle.Windsor;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Domain.Castle
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IWindsorContainer container;

        public DomainEventDispatcher(IWindsorContainer container)
        {
            Guard.AgainstNull(container, "container");

            this.container = container;
        }

        public void Dispatch<T>(T @event) where T : IDomainEvent
        {
            foreach (var handler in container.ResolveAll<IDomainEventHandler<T>>())
            {
                handler.Handle(@event);
            }
        }
    }
}
