using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePad
{
    class Rand
    {
        public static List<string> GetRandomBinary(int textLen)
        {
            List<string> binaryList = new List<string>();
            Random r = new Random();
            for (int i = 0; i < textLen; i++)
            {
                string s = "";
                for(int j = 0; j < 8; j++)
                {
                    s += r.Next(0, 2);
                }
                binaryList.Add(s);
            }
            return binaryList;
        }
    }
}
