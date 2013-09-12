using System;

namespace Shuttle.Core.Infrastructure
{
	public class TypeNameStartsWithSpecification : Specification<Type>
	{
		public string StartsWith { get; set; }

		public TypeNameStartsWithSpecification(string startsWith)
		{
			StartsWith = startsWith.ToLower();
		}

		public override bool IsSatisfiedBy(Type item)
		{
			Guard.AgainstNull(item, "item");

			return item.Name.ToLower().StartsWith(StartsWith);
		}
	}
}