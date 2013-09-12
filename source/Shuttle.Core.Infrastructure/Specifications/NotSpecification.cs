using System.Collections.Generic;
using System.Linq;

namespace Shuttle.Core.Infrastructure
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        public NotSpecification(Specification<T> specification)
            : base(new List<Specification<T>>
                       {
                           specification
                       })
        {
        }

        public NotSpecification(IEnumerable<Specification<T>> specifications)
            : base(specifications)
        {
        }

        public override bool IsSatisfiedBy(T item)
        {
        	return specifications.All(specification => specification.IsSatisfiedBy(item));
        }
    }
}
