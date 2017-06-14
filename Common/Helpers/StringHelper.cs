using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class StringHelper
    {
        public static string GetRandomString(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("'length' parameter is mandatory !");
            }

            char[] chars = new char[] {
                'a','b','c','d','e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A','B','C','D','E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                '1','2','3','4','5','6','7','8','9',
                '&','~','#','{','}','[',']','|','\\','@','_','-'
            };
            StringBuilder strb = new StringBuilder();
            int charsLength = chars.Length;
            Random rdm = new Random();
            for (int i = 0; i < length; i++)
            {
                strb.Append(rdm.Next(0, charsLength));
            }

            return strb.ToString();
        }
    }
}
