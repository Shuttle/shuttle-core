using NUnit.Framework;
using Shuttle.Core.Data;

namespace Test.All
{
	[TestFixture]
	public class DbConnectionFactoryTests : Fixture
	{
		[Test]
		public void Should_be_able_to_create_a_valid_connection()
		{
			var factory = DbConnectionFactory.Default();

			using (var connection = factory.CreateConnection(DefaultDataSource()))
			{
				Assert.IsNotNull(connection);
			}
		}
	}
}