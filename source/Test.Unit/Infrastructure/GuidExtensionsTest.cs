using Shuttle.Core.Infrastructure;
using NUnit.Framework;

namespace Test.All
{
    public class GuidExtensionsTest : Fixture
    {
        [Test]
        public void Should_be_able_to_check_whether_a_given_string_is_a_guid()
        {
            const string GUID = "49765693-750E-47D4-8CA6-507DA5B67568";
            const string BOGUS = "bogus";

            Assert.IsTrue(GUID.IsGuid());
            Assert.IsFalse(BOGUS.IsGuid());
        }
    }
}
