using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Shuttle.Core.Infrastructure
{
    public class CryptographyService : ICryptographyService
    {
        public string SHA1(string source, string salt)
        {
            Guard.AgainstNullOrEmptyString(source, "source");
            Guard.AgainstNullOrEmptyString(salt, "salt");

            var sha1 = new SHA1Managed();
            var ae = new ASCIIEncoding();

            var sourceBytes = ae.GetBytes(salt + source);

        	return sha1.ComputeHash(sourceBytes).Aggregate("", (current, b) => current + string.Format("{0:x2}", b));
        }

        public string TripleDESEncrypt(string plain, string key)
        {
            Guard.AgainstNullOrEmptyString(plain, "plain");
            Guard.AgainstNullOrEmptyString(key, "key");

            return Convert.ToBase64String(GetEncryptedBytes(key, plain.Length, Encoding.UTF8.GetBytes(plain)));
        }

        private static byte[] GetEncryptedBytes(string key, int plainLength, byte[] plainBytes)
        {
            byte[] encryptedBytes;

            using (var ms = new MemoryStream((plainLength * 2) - 1))
            using (
                var cs = new CryptoStream(ms, TripleDESCryptoServiceProvider(key).CreateEncryptor(),
                                          CryptoStreamMode.Write))
            {
                cs.Write(plainBytes, 0, plainBytes.Length);

                cs.FlushFinalBlock();

                encryptedBytes = new byte[(int)ms.Length];

                ms.Position = 0;

                ms.Read(encryptedBytes, 0, (int)ms.Length);
            }
            return encryptedBytes;
        }

        private static TripleDESCryptoServiceProvider TripleDESCryptoServiceProvider(string key)
        {
            return new TripleDESCryptoServiceProvider
                       {
                           IV = new byte[8],
                           Key =
                               new PasswordDeriveBytes(key, new byte[0]).CryptDeriveKey("RC2", "MD5", 128, new byte[8])
                       };
        }

        public string TripleDESDecrypt(string encrypted, string key)
        {
            Guard.AgainstNullOrEmptyString(encrypted, "secure");
            Guard.AgainstNullOrEmptyString(key, "key");

            return Encoding.UTF8.GetString(GetPlainBytes(key, encrypted.Length, Convert.FromBase64String(encrypted)));
        }

        public Stream TripleDESEncrypt(Stream plain, string key)
        {
            Guard.AgainstNull(plain, "plain");
            Guard.AgainstNullOrEmptyString(key, "key");

            return new MemoryStream(GetEncryptedBytes(key, (int)plain.Length, plain.ToBytes()));
        }

        public Stream TripleDESDecrypt(Stream encrypted, string key)
        {
            Guard.AgainstNull(encrypted, "secure");
            Guard.AgainstNullOrEmptyString(key, "key");

            return new MemoryStream(GetPlainBytes(key, (int)encrypted.Length, encrypted.ToBytes()));
        }

    	public byte[] TripleDESEncrypt(byte[] plain, string key)
    	{
			return GetEncryptedBytes(key, plain.Length, plain);
    	}

    	public byte[] TripleDESDecrypt(byte[] encrypted, string key)
    	{
			return GetPlainBytes(key, encrypted.Length, encrypted);
    	}

    	private static byte[] GetPlainBytes(string key, int secureLength, byte[] encryptedBytes)
        {
            byte[] plainBytes;

            using (var ms = new MemoryStream(secureLength))
            using (
                var cs = new CryptoStream(ms, TripleDESCryptoServiceProvider(key).CreateDecryptor(),
                                          CryptoStreamMode.Write))
            {
                cs.Write(encryptedBytes, 0, encryptedBytes.Length);

                cs.FlushFinalBlock();

                plainBytes = new byte[(int)ms.Length];

                ms.Position = 0;

                ms.Read(plainBytes, 0, (int)ms.Length);
            }

            return plainBytes;
        }
    }
}