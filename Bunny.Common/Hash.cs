using System;
using System.Security.Cryptography;
using System.Text;

namespace Bunny.Common
{
    public class Hash
    {
        public string Go(string s)
        {
            byte[] _encoded = new UTF8Encoding()
                .GetBytes(s);

            byte[] _hash = ((HashAlgorithm)CryptoConfig
                .CreateFromName("MD5"))
                .ComputeHash(_encoded);

            string r = BitConverter.ToString(_hash)
               .Replace("-", string.Empty);

            return r;
        }
    }
}
