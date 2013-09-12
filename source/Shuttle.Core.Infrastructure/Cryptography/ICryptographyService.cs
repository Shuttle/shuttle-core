using System.IO;

namespace Shuttle.Core.Infrastructure
{
    public interface ICryptographyService
    {
        string SHA1(string source, string salt);
        string TripleDESEncrypt(string plain, string key);
        string TripleDESDecrypt(string encrypted, string key);
        Stream TripleDESEncrypt(Stream plain, string key);
        Stream TripleDESDecrypt(Stream encrypted, string key);
        byte[] TripleDESEncrypt(byte[] plain, string key);
        byte[] TripleDESDecrypt(byte[] encrypted, string key);
    }
}
