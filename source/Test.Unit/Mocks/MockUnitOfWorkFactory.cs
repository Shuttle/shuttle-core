using Shuttle.Core.Data;
using Rhino.Mocks;
using Shuttle.Core.Domain;

namespace Test.All
{
    public class MockUnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Current
        {
            get
            {
                return MockRepository.GenerateMock<IUnitOfWork>();
            }
            set
            {
            }
        }

        public IUnitOfWork Create()
        {
            return MockRepository.GenerateMock<IUnitOfWork>();
        }

        public IUnitOfWork Create(DataSource source)
        {
            return Create();
        }
    }
}
