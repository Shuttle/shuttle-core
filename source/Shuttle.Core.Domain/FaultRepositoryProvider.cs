using System;

namespace Shuttle.Core.Domain
{
    public class FaultRepositoryProvider : IRepositoryProvider
    {
        public IRepository<T, IComparable> Get<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}