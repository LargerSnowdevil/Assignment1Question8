using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PRT580Assignment1Question8
{
    public class BinaryOperationMethods
    {
        /// <summary>
        /// Finds and returns the product of two binary numbers.
        /// </summary>
        public int[] ProductOf(int[] x, int[] y)
        {
            var partialProducts = new List<int[]>();
            var i = 0;
            int workingIndex = y.Length - 1;

            while (i < y.Length)
            {
                var result = new int[x.Length + i];

                if (y[workingIndex].Equals(1))
                {
                    Array.Copy(x, result, x.Length);
                }

                partialProducts.Add(result);
                workingIndex--;
                i++;
            }

            return SumOf(partialProducts);
        }

        /// <summary>
        /// Finds and returns the sum of a list of binary numbers.
        /// </summary>
        private int[] SumOf(List<int[]> terms, int depth = 0)
        {
            //depth + 1 is to accound for the off by 1 error.
            if (terms.Count == depth)
            {
                //The last number in the list can be returned as due to there being nothing else to add to it.
                return Array.Empty<int>();
            }

            var carry = 0;
            var total = SumOf(terms, depth + 1);
            var result = total.Length > terms[depth].Length ? new int[total.Length + 1] : new int[terms[depth].Length + 1];

            //Ensure arrays being added are the same length
            var x = new int[result.Length];
            Array.Copy(total.Flip(), x, total.Length);

            var y = new int[result.Length];
            Array.Copy(terms[depth].Flip(), y, terms[depth].Length);

            for (int i2 = 0; i2 < result.Length; i2++)
            {
                var sum = x[i2] + y[i2] + carry;

                switch (sum)
                {
                    case 0:
                        carry = 0;
                        result[i2] = 0; 
                        break;
                    case 1:
                        carry = 0;
                        result[i2] = 1;
                        break;
                    case 2:
                        carry = 1;
                        result[i2] = 0;
                        break;
                    case 3:
                        carry = 1;
                        result[i2] = 1;
                        break;
                    default:
                        throw new Exception($"Invaid state sum was: {sum}");
                }
            }

            //Trim all exess 0 from the most sig figure until we hit a non 0
            while (result[result.Length - 1].Equals(0)) { 
                var trimed = new int[result.Length - 1];
                Array.Copy(result, trimed, trimed.Length);
                result = trimed;
            }

            return result.Flip();
        }
    }
}
