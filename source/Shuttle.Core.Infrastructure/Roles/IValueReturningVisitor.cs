namespace Shuttle.Core.Infrastructure
{
    public interface IValueReturningVisitor<TValueToReturn, T> : IVisitor<T>
    {
        TValueToReturn GetResult();
    }
}
