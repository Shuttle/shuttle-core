using Shuttle.Core.Data;
using Shuttle.Core.Domain;
using Shuttle.Core.Infrastructure;
using NUnit.Framework;
using Rhino.Mocks;

namespace Test.All
{
    [TestFixture]
    public abstract class Fixture
    {
        protected IUnitOfWorkFactory UnitOfWorkFactory
        {
            get
            {
                return Startup.UnitOfWorkFactory;
            }
        }

		protected IDatabaseConnectionFactory DatabaseConnectionFactory
        {
            get
            {
				return Startup.DatabaseConnectionFactory;
            }
        }

        protected IDatabaseGateway DatabaseGateway
        {
            get
            {
                return Startup.DatabaseGateway;
            }
        }

        protected static T Mock<T>() where T : class
        {
            return MockRepository.GenerateMock<T>();
        }

        protected T Stub<T>() where T : class
        {
            return MockRepository.GenerateStub<T>();
        }
    }
}
