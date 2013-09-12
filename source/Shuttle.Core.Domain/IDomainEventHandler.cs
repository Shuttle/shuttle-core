namespace Shuttle.Core.Domain
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}