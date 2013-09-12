using System;

namespace Shuttle.Core.Domain
{
    public interface IRepositoryProvider
    {
        IRepository<T, IComparable> Get<T>() where T : class;
    }
}