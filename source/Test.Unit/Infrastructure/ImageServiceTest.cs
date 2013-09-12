using System;
using NUnit.Framework;
using Shuttle.Core.Infrastructure;

namespace Test.All
{
    public class ImageServiceTest : Fixture
    {
        [Test]
        public void Should_be_able_to_get_image_type_for_text_file()
        {
            var service = new ImageService();

            var format = service.ImageFormat(@"Infrastructure\Images\NotAnImage.txt");

            Console.WriteLine(Convert.ToString(format));
        }
    }
}