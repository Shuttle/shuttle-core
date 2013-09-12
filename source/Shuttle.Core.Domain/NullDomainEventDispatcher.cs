namespace Shuttle.Core.Domain
{
    public class NullDomainEventDispatcher : IDomainEventDispatcher
    {
        public void Dispatch<T>(T @event) where T : IDomainEvent
        {
        }
    }
}