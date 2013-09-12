using Shuttle.Core.Infrastructure;
using NUnit.Framework;

namespace Test.All
{
    [TestFixture]
    public class ObjectSerializerTest : Fixture
    {
        [Test]
        public void Should_be_able_to_serialize_and_deserialize_an_object_using_the_xml_implementation()
        {
            IObjectSerializer serializer = new XmlObjectSerializer();

            const string name = "TheName";
            const string value = "TheValue";

            var input = new TestModel {Name = name, Value = value};

            var xml = serializer.Serialize(input);

            var output = serializer.Deserialize<TestModel>(xml);

            Assert.AreEqual(input.Name, output.Name);
            Assert.AreEqual(input.Value, output.Value);
        }
    }

    public class TestModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
