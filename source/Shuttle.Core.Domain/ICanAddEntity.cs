namespace Shuttle.Core.Domain
{
    public interface ICanAddEntity<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);
    }
}