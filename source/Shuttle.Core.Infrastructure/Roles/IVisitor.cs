namespace Shuttle.Core.Infrastructure
{
    public interface IVisitor<T>
    {
        void Visit(T item);
    }
}
