using System;

namespace Shuttle.Core.Domain
{
    public class RowIdentity<T>
    {
        public RowIdentity(T id)
        {
            Id = id;
        }

        public RowIdentity()
        {
            Id = default(T);
        }

        public T Id { get; protected set; }
    }

    public class RowIdentity : RowIdentity<Guid>
    {
        public RowIdentity()
        {
            AssignId();
        }

        public RowIdentity(Guid id)
            : base(id)
        {
        }

        public void AssignId()
        {
            Id = Guid.NewGuid();
        }
    }
}