using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Shuttle.Core.Infrastructure
{
	public class FileService : IFileService
	{
		[DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
		private static extern UInt32 FindMimeFromData(
			UInt32 pBC,
			[MarshalAs(UnmanagedType.LPStr)] String pwzUrl,
			[MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
			UInt32 cbSize,
			[MarshalAs(UnmanagedType.LPStr)] String pwzMimeProposed,
			UInt32 dwMimeFlags,
			out UInt32 ppwzMimeOut,
			UInt32 dwReserverd
			);

		public string KnownMimeType(string file)
		{
			using (var fs = new FileStream(file, FileMode.Open))
			{
				return KnownMimeType(fs);
			}
		}

		public string KnownMimeType(Stream stream)
		{
			var buffer = new byte[256];

			if (stream.Length >= 256)
			{
				stream.Read(buffer, 0, 256);
			}
			else
			{
				stream.Read(buffer, 0, (int) stream.Length);
			}

			stream.Position = 0;

			try
			{
				UInt32 mimetype;
				FindMimeFromData(0, null, buffer, 256, null, 0, out mimetype, 0);
				var mimeTypePtr = new IntPtr(mimetype);
				var mime = Marshal.PtrToStringUni(mimeTypePtr);
				Marshal.FreeCoTaskMem(mimeTypePtr);
				return mime;
			}
			catch
			{
				return null;
			}
		}

		public string RegistryMimeType(string file)
		{
			if (!Path.HasExtension(file))
			{
				throw new ArgumentException(string.Format(InfrastructureResources.PathHasNoExtensionException, file));
			}

			string result = null;
			var extension = Path.GetExtension(file).ToLower();

			var regKey = Registry.ClassesRoot.OpenSubKey(extension);

			if (regKey != null && regKey.GetValue("Content Type") != null)
			{
				result = regKey.GetValue("Content Type").ToString();
			}

			return result;
		}

		public string RegistryFileExtension(string mimeType)
		{
			var key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + mimeType, false);

			var value = key != null ? key.GetValue("Extension", null) : null;

			return value != null ? value.ToString() : null;
		}
	}
}