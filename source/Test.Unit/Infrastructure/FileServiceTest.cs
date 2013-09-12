using System;
using NUnit.Framework;
using Shuttle.Core.Infrastructure;

namespace Test.All
{
	public class FileServiceTest : Fixture
	{
		[Test]
		public void Should_be_able_to_get_mime_type_from_registry()
		{
			Assert.AreEqual("image/jpeg", new FileService().RegistryMimeType("someimage.jpg"));
		}

		[Test]
		public void Should_be_able_to_get_file_extension_for_mime_type_from_registry()
		{
			Assert.AreEqual(".pdf", new FileService().RegistryFileExtension("application/pdf"));
		}
	}
}