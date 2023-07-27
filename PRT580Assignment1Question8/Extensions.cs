using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRT580Assignment1Question8
{
    public static class Extensions
    {
        /// <summary>
        /// Converts a string containing a binary number into an int[] containing the same binary number.
        /// </summary>
        public static int[] ToBinary(this string s)
        {
            var result = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                result[i] = int.Parse(s[i].ToString());
            }
            return result;
        }

        /// <summary>
        /// Converts an int[] containing a binary number into a string containing the same binary number.
        /// </summary>
        public static string ToReadableBinary(this int[] a)
        {
            return string.Join("", a);
        }

        /// <summary>
        /// Reverses the order of elements held in an int[].
        /// </summary>
        public static int[] Flip(this int[] a)
        {
            return a.Reverse().ToArray();
        }
    }
}
