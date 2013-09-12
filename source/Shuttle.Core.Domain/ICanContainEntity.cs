namespace Shuttle.Core.Domain
{
    public interface ICanContainEntity<TEntity>
        where TEntity : class
    {
        bool Contains(TEntity entity);
    }
}