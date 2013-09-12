using System.IO;

namespace Shuttle.Core.Infrastructure
{
    public interface IFileService
    {
        string KnownMimeType(string file);
        string KnownMimeType(Stream stream);
    	string RegistryMimeType(string file);
    	string RegistryFileExtension(string mimeType);
    }
}
