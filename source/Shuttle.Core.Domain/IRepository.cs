using System;

namespace Shuttle.Core.Domain
{
    public interface IRepository<TEntity, TId> : 
        ICanGetEntity<TEntity, TId>,
        ICanAddEntity<TEntity>,
        ICanSaveEntity<TEntity>,
        ICanRemoveEntity<TEntity>
            where TEntity : class
            where TId : IComparable
    {
    }
}