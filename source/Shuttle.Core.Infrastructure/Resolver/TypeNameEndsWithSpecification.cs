using System;

namespace Shuttle.Core.Infrastructure
{
	public class TypeNameEndsWithSpecification : Specification<Type>
	{
		public string EndsWith { get; set; }

		public TypeNameEndsWithSpecification(string endsWith)
		{
			EndsWith = endsWith.ToLower();
		}

		public override bool IsSatisfiedBy(Type item)
		{
			Guard.AgainstNull(item, "item");

			return item.Name.ToLower().EndsWith(EndsWith);
		}
	}
}