using Shuttle.Core.Data;
using NUnit.Framework;
using Shuttle.Core.Domain;

namespace Test.All
{
    [SetUpFixture]
    public class Startup
    {
        public Startup()
        {
            DatabaseConnectionFactory = Shuttle.Core.Data.DatabaseConnectionFactory.Default();
            DatabaseGateway = Shuttle.Core.Data.DatabaseGateway.Default();
        }

		public static IDatabaseConnectionFactory DatabaseConnectionFactory { get; private set; }
        public static IDatabaseGateway DatabaseGateway { get; private set; }
    }
}
