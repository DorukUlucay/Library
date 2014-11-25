using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace LibraryUI.Helpers
{
    public static class CryptoHelper
    {
        public static string unnamed(string PlainText)
        {
            string Hashed = string.Empty;
            SHA512 Provider = SHA512.Create();
            byte[] Buffer = Provider.ComputeHash(Encoding.UTF8.GetBytes(PlainText));
            Hashed = Encoding.UTF8.GetString(Buffer);
            
            return Hashed;
        }
    }
}