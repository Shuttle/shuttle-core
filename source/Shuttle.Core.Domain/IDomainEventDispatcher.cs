namespace Shuttle.Core.Domain
{
    public interface IDomainEventDispatcher
    {
        void Dispatch<T>(T @event) where T : IDomainEvent;
    }
}