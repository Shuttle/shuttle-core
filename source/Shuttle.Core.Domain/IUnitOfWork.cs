using System;

namespace Shuttle.Core.Domain
{
    public interface IUnitOfWork : IDisposable
    {
    	void WillUse<T>();
        void WillUseFullObjectGraph();
        void WillUseNothing();
        bool Uses<T>();
        T Get<T>(IComparable id) where T : class;
        bool Contains(IComparable id);
        void Register<T>(Guid id, T entity) where T : class;
    }
}