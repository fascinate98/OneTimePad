using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePad
{
    class Decoder
    {
        public static string Decoding(List<string> binary)
        {
            char[] outBytes = new char[binary.Count];
            string result = "";
            for (int i = 0; i < binary.Count; i++)
            {
                outBytes[i] = (char)Convert.ToInt32(binary[i], 2);
                result += outBytes[i].ToString();
            }
            return result;
        }
    }
}
