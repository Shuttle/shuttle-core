namespace Shuttle.Core.Infrastructure
{
    public interface ICache
    {
        void Flush();
        void Add(string key, object item);
        T Get<T>(string key);
    }
}
