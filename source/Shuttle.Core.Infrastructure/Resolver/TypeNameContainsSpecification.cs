using System;

namespace Shuttle.Core.Infrastructure
{
	public class TypeNameContainsSpecification : Specification<Type>
	{
		public string Contains { get; set; }

		public TypeNameContainsSpecification(string contains)
		{
			Contains = contains.ToLower();
		}

		public override bool IsSatisfiedBy(Type item)
		{
			Guard.AgainstNull(item, "item");

			return item.Name.ToLower().Contains(Contains);
		}
	}
}