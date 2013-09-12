namespace Shuttle.Core.Infrastructure
{
    public interface IReplay<T>
    {
        void Replay(T destination);
    }
}