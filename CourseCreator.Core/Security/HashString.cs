using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Core.Security
{
    public static class HashString
    {
        public static string EncodeString(string str)
        {
            Byte[] originalBytes;
            Byte[] encodeBytes;

            MD5 md5;

            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(str);
            encodeBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodeBytes);
        }
    }
}
