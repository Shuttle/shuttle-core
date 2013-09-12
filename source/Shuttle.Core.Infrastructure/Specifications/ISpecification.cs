namespace Shuttle.Core.Infrastructure
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T item);
    }
}
