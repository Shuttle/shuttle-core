using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Shuttle.Core.Infrastructure
{
	public class ImageService : IImageService
	{
		public Icon IconFrom(Image image)
		{
			const int SIZE = 16;

			var square = new Bitmap(SIZE, SIZE);
			var g = Graphics.FromImage(square);

			int x, y, w, h;

			var r = image.Width / (float)image.Height;

			if (r > 1)
			{
				w = SIZE;
				h = (int)(SIZE / r);
				x = 0;
				y = (SIZE - h) / 2;
			}
			else
			{
				w = (int)(SIZE * r);
				h = SIZE;
				y = 0;
				x = (SIZE - w) / 2;
			}

			g.InterpolationMode = InterpolationMode.HighQualityBicubic;

			g.DrawImage(image, x, y, w, h);

			g.Flush();

			return Icon.FromHandle(square.GetHicon());
		}

		public Image Convert(Image image, ImageFormat format)
		{
			Guard.AgainstNull(image, "image");

			using (var stream = new MemoryStream())
			{
				image.Save(stream, format);

				return Image.FromStream(stream);
			}
		}

		public ImageFormat ImageFormat(Image image)
		{
			Guard.AgainstNull(image, "image");

			var format = image.RawFormat;

			if (format.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
			{
				return System.Drawing.Imaging.ImageFormat.Bmp;
			}

			if (format.Equals(System.Drawing.Imaging.ImageFormat.Emf))
			{
				return System.Drawing.Imaging.ImageFormat.Emf;
			}

			if (format.Equals(System.Drawing.Imaging.ImageFormat.Exif))
			{
				return System.Drawing.Imaging.ImageFormat.Exif;
			}

			if (format.Equals(System.Drawing.Imaging.ImageFormat.Gif))
			{
				return System.Drawing.Imaging.ImageFormat.Gif;
			}

			if (format.Equals(System.Drawing.Imaging.ImageFormat.Icon))
			{
				return System.Drawing.Imaging.ImageFormat.Icon;
			}

			if (format.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
			{
				return System.Drawing.Imaging.ImageFormat.Jpeg;
			}

			if (format.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp))
			{
				return System.Drawing.Imaging.ImageFormat.MemoryBmp;
			}

			if (format.Equals(System.Drawing.Imaging.ImageFormat.Png))
			{
				return System.Drawing.Imaging.ImageFormat.Png;
			}

			if (format.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
			{
				return System.Drawing.Imaging.ImageFormat.Tiff;
			}

			return format.Equals(System.Drawing.Imaging.ImageFormat.Wmf) ? System.Drawing.Imaging.ImageFormat.Wmf : null;
		}

		public ImageFormat ImageFormat(Stream stream)
		{
			try
			{
				using (var image = Image.FromStream(stream))
				{
					return ImageFormat(image);
				}
			}
			catch
			{
				return null;
			}
		}

		public ImageFormat ImageFormatMagic(Stream stream)
		{
			Guard.AgainstNull(stream, "stream");

			var position = stream.Position;
			var length = stream.Length;

			var buffer = new byte[256];

			stream.Position = 0;

			if (stream.Length > 256)
			{
				stream.Read(buffer, 0, 256);
			}
			else
			{
				stream.Read(buffer, 0, (int)length);
			}

			stream.Position = position;

			if (buffer.Length > 7
				&& buffer[0] == 255
				&& buffer[1] == 216
				&& buffer[2] == 255
				&& buffer[3] == 224)
			{
				return System.Drawing.Imaging.ImageFormat.Jpeg;
			}

			if (buffer.Length > 7
				&& buffer[0] == 137
				&& buffer[1] == 80
				&& buffer[2] == 78
				&& buffer[3] == 71)
			{
				return System.Drawing.Imaging.ImageFormat.Png;
			}

			if (buffer.Length > 7 &&
				((buffer[0] == 77
				  && buffer[1] == 77
				  && buffer[2] == 0
				  && buffer[3] == 42)
				 ||
				 (buffer[0] == 73
				  && buffer[1] == 73
				  && buffer[2] == 42
				  && buffer[3] == 0)))
			{
				return System.Drawing.Imaging.ImageFormat.Tiff;
			}

			return null;
		}

		public ImageFormat ImageFormat(string file)
		{
			using (var fs = new FileStream(file, FileMode.Open))
			{
				return ImageFormat(fs);
			}
		}

		public string FileExtension(ImageFormat format)
		{
			Guard.AgainstNull(format, "format");

			if (format.Equals(System.Drawing.Imaging.ImageFormat.Icon))
			{
				return "ico";
			}

			if (format.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
			{
				return "jpg";
			}

			if (format.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp))
			{
				return "bmp";
			}

			if (format.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
			{
				return "tif";
			}

			return format.ToString().ToLower();
		}

		public ImageCodecInfo GetEncoderInfo(string mimeType)
		{
			foreach (var encoderInfo in ImageCodecInfo.GetImageEncoders().Where(t => t.MimeType == mimeType))
			{
				return encoderInfo;
			}

			throw new Exception(string.Format(InfrastructureResources.ImageEncoderNotFoundException,  mimeType));
		}
	}
}