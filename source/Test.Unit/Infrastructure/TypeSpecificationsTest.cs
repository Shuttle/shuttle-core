using System;
using NUnit.Framework;
using Shuttle.Core.Infrastructure;

namespace Test.All
{
	public class TypeSpecificationsTest : Fixture
	{
		[Test]
		public void Should_be_able_to_use_object_specifications()
		{
			var startsWith = new TypeNameStartsWithSpecification("First");

			Assert.IsTrue(startsWith.IsSatisfiedBy(typeof(FirstInterface)));
			Assert.IsFalse(startsWith.IsSatisfiedBy(typeof(IMockEntity)));

			var endsWith = new TypeNameEndsWithSpecification("Interface");

			Assert.IsTrue(endsWith.IsSatisfiedBy(typeof(FirstInterface)));
			Assert.IsFalse(endsWith.IsSatisfiedBy(typeof(IMockEntity)));

			var contains = new TypeNameContainsSpecification("Int");

			Assert.IsTrue(contains.IsSatisfiedBy(typeof(FirstInterface)));
			Assert.IsFalse(contains.IsSatisfiedBy(typeof(IMockEntity)));
		}
	}
}