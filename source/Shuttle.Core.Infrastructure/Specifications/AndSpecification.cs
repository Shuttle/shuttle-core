using System.Collections.Generic;
using System.Linq;

namespace Shuttle.Core.Infrastructure
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(IEnumerable<Specification<T>> specifications)
            : base(specifications)
        {
        }

        public AndSpecification(
            Specification<T> augmentSpecification,
            Specification<T> withSpecification)
            : base(new List<Specification<T>>
                       {
                           augmentSpecification,
                           withSpecification
                       })
        {
        }

        public override bool IsSatisfiedBy(T item)
        {
			if (specifications.Count() == 0)
			{
				return false;
			}

        	return specifications.All(specification => specification.IsSatisfiedBy(item));
        }
    }
}
