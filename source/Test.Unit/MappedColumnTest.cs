using System.Data;
using Shuttle.Core.Data;
using NUnit.Framework;

namespace Test.All
{
    [TestFixture]
    public class MappedColumnTest : Fixture
    {
        [Test]
        public void Should_be_able_to_get_the_text_for_a_column_from_the_resources()
        {
            var column = new MappedColumn("LoginName", DbType.AnsiString, 100);

            Assert.AreEqual("Login name", column.Text(Properties.Resources.ResourceManager));
        }
    }
}
