using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT580Assignment1Question8
{
    public static class Extensions
    {
        public static int[] ToBinary(this string s)
        {
            var result = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                result[i] = int.Parse(s[i].ToString());
            }
            return result;
        }

        public static string ToReadableBinary(this int[] a)
        {
            return string.Join("", a);
        }

        public static int[] Flip(this int[] a)
        {
            return a.Reverse().ToArray();
        }
    }
}
