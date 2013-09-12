namespace Shuttle.Core.Infrastructure
{
    public interface ICanBeReadOnly<T>
    {
        T AsReadOnly();

        bool ReadOnly { get; }
    }
}
