using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Common
{
    public static class EncodingPassword
    {
        public static string EncodingUTF8(string password)
        {
            Byte[] passBytes = Encoding.UTF8.GetBytes(password);
            string passE = "";
            foreach (byte b in passBytes)
                passE += b;
            return passE;
        }
    }
}
