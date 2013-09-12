using System.Collections.Generic;
using System.Linq;

namespace Shuttle.Core.Infrastructure
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(IEnumerable<Specification<T>> specifications)
            : base(specifications)
        {
        }

        public OrSpecification(
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
				return true;
			}

        	return specifications.Any(specification => specification.IsSatisfiedBy(item));
        }
    }
}
