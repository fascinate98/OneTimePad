using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePad
{
    class Encrypt
    {

        public static List<string> Encryption(List<string> plainBinary, List<string> keyBinary)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < plainBinary.Count; i++)
            {
                result.Add(string.Join(null, Enumerable.Zip(plainBinary[i], keyBinary[i], (a, b) => (Convert.ToByte(a) ^ Convert.ToByte(b)) == 0 ? '0' : '1')));
            }

            return result;
        }
    }
}
