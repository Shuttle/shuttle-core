using System;
using Shuttle.Core.Infrastructure;
using NUnit.Framework;

namespace Test.All
{
    [TestFixture]
    public class ResultTest : Fixture
    {
        [Test]
        public void Should_be_able_to_add_messages_using_all_the_available_add_methods_for_the_non_generic_result_class()
        {
            var result = new Result();

            result.AddException(new NotImplementedException());
            result.AddFailureMessage(new ResultMessage("zero"));
            result.AddFailureMessage("one");
            result.AddFailureMessages("two", "three");

            result.AddSuccessMessage(new ResultMessage("zero"));
            result.AddSuccessMessage("one");
            result.AddSuccessMessages("two", "three");

            Assert.AreEqual(5, result.FailureMessages.Count);
            Assert.AreEqual(4, result.SuccessMessages.Count);
        }

        [Test]
        public void Should_be_able_to_add_sub_messages_to_an_existing_ResultMessage()
        {
            var message = new ResultMessage("blah");

            message.Messages.Add(new ResultMessage("sub1"));
            message.Messages.Add(new ResultMessage("sub2"));

            Assert.AreEqual(2, message.Messages.Count);
        }
    }
}
