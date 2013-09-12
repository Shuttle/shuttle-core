using System;

namespace Shuttle.Core.Domain
{
    public interface ICanGetEntity<TEntity, TId>
        where TEntity : class
        where TId : IComparable
    {
        TEntity Get(TId id);
    }
}