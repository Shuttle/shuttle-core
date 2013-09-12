namespace Shuttle.Core.Domain
{
    public interface ICanRemoveEntity<TEntity>
        where TEntity : class
    {
        void Remove(TEntity entity);
    }
}