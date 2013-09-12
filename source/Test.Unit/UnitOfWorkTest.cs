using Shuttle.Core.Data;
using NUnit.Framework;
using Shuttle.Core.Domain;

namespace Test.All
{
    [TestFixture]
    public class UnitOfWorkTest : Fixture
    {
        [Test]
        public void Should_be_able_to_add_used_types()
        {
            IUnitOfWork uow = new UnitOfWork(Mock<IRepositoryProvider>());

            uow.WillUse<object>();

            Assert.IsTrue(uow.Uses<object>());
        }
    }
}
