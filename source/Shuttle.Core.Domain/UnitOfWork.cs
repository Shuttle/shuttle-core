using System;
using System.Collections.Generic;
using System.Text;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<IComparable, string> cycle = new Dictionary<IComparable, string>();
        private readonly Dictionary<IComparable, object> entities = new Dictionary<IComparable, object>();

        private readonly IRepositoryProvider repositoryProvider;

        private bool disposed;
        private List<Type> typesUsed = new List<Type>();
        private bool usesFullObjectGraph;

        public UnitOfWork(IRepositoryProvider repositoryProvider)
        {
			Guard.AgainstNull(repositoryProvider, "repositoryProvider");

            this.repositoryProvider = repositoryProvider;
        }

    	public void WillUse<T>()
        {
            typesUsed.Add(typeof (T));
        }

        public void WillUseFullObjectGraph()
        {
            usesFullObjectGraph = true;
        }

        public void WillUseNothing()
        {
            usesFullObjectGraph = false;
            typesUsed = new List<Type>();
        }

        public bool Uses<T>()
        {
            return usesFullObjectGraph || typesUsed.Contains(typeof (T));
        }

        public T Get<T>(IComparable id) where T : class
        {
            if (Contains(id))
            {
                return (T) entities[id];
            }

            T result;

            using (Cycle<T>(id))
            {
                result = repositoryProvider.Get<T>().Get(id);
            }

            if (!Contains(id))
            {
                entities.Add(id, result);
            }

            return result;
        }

        public bool Contains(IComparable id)
        {
            return entities.ContainsKey(id);
        }

        public void Register<T>(Guid id, T entity) where T : class
        {
            if (!entities.ContainsKey(id))
            {
                entities.Add(id, entity);
            }
        }

        private IDisposable Cycle<T>(IComparable id)
        {
            if (cycle.ContainsKey(id))
            {
                throw new ApplicationException(string.Format("Circular reference detected: {0}",
                                                             CircularReference()));
            }

            return new Cycle<T>(cycle, id);
        }

        private string CircularReference()
        {
            var result = new StringBuilder();

            foreach (var item in cycle)
            {
                result.AppendFormat("{0}{1} ({2}) ", result.Length > 0
                                                         ? "->"
                                                         : string.Empty, item.Value, item.Key);
            }

            result.Append("and back to the head.");

            return result.ToString();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            disposed = true;
        }
    }
}