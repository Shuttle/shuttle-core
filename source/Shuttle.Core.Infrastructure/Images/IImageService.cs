using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Shuttle.Core.Infrastructure
{
    public interface IImageService
    {
        Icon IconFrom(Image image);
        Image Convert(Image image, ImageFormat format);
        ImageFormat ImageFormat(Image image);
        ImageFormat ImageFormat(Stream stream);
        ImageFormat ImageFormatMagic(Stream stream);
        ImageFormat ImageFormat(string file);
    	string FileExtension(ImageFormat format);
    	ImageCodecInfo GetEncoderInfo(string mimeType);
    }
}