namespace Shuttle.Core.Domain
{
    public interface ICanSaveEntity<TEntity>
        where TEntity : class
    {
        void Save(TEntity entity);
    }
}