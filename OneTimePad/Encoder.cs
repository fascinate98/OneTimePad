using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTimePad
{
    class Encoder
    {

        public static List<string> Encoding(string plainText)
        {
            //TODO:plainText to Binary 
            List<string> list = new List<string>();
         
            foreach (char c in plainText)
            {
                string binaryCharCode = Convert.ToString((int)c, 2).PadLeft(8,'0');
                list.Add(binaryCharCode);
            }

            return list;
        }
    }
}
