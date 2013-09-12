using System;
using System.IO;
using System.Text;
using NUnit.Framework;
using Shuttle.Core.Infrastructure;

namespace Test.All
{
    public class CryptographyServiceTest : Fixture
    {
        [Test]
        public void Should_be_able_to_use_string_based_TripleDES()
        {
            var sut = CreateSUT();

            var key = Guid.NewGuid().ToString();
            const string PLAIN = "just a simple string";

            var encrypted = sut.TripleDESEncrypt(PLAIN, key);

            Assert.AreEqual(PLAIN, sut.TripleDESDecrypt(encrypted, key));
        }

        [Test]
        public void Should_be_able_to_use_stream_based_TripleDES()
        {
            var sut = CreateSUT();

            var key = Guid.NewGuid().ToString();

            const string PLAIN_TEXT = "just a simple string";

            using (var plain = new MemoryStream(Encoding.UTF8.GetBytes(PLAIN_TEXT)))
            using (var encrypted = sut.TripleDESEncrypt(plain, key))
            using (var decrypted = sut.TripleDESDecrypt(encrypted, key))
            {
                Assert.AreEqual(plain, decrypted);
                Assert.AreEqual(PLAIN_TEXT, Encoding.UTF8.GetString(decrypted.ToBytes()));
            }
        }

        private static ICryptographyService CreateSUT()
        {
            return new CryptographyService();
        }
    }
}