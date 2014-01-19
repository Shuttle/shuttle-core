using Shuttle.Core.Data;
using NUnit.Framework;

namespace Test.All
{
    [TestFixture]
    public abstract class Fixture
    {
		protected static DataSource DefaultDataSource()
		{
			return new DataSource("Shuttle", new SqlDbDataParameterFactory());
		}
    }
}
