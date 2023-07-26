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
            //Due to wanting to add placeholder 0s to the least significant figure side of the numbers we need to 
            //keep track of both our loop count (i) and our working index.
            var i = 0;
            int workingIndex = y.Length - 1;

            while (i < y.Length)
            {
                //By initing this array using the loop count we add our placeholder 0s without having to worry about them.
                var result = new int[x.Length + i];

                //If the multiplier is 1 copy across the Multiplicand othwerwise leave the defult array values (0).
                if (y[workingIndex].Equals(1))
                {
                    Array.Copy(x, result, x.Length);
                }

                //Add the result to the list of partial products to add together later.
                partialProducts.Add(result);
                workingIndex--;
                i++;
            }

            //Add the partial products together and return the total.
            return SumOf(partialProducts);
        }

        /// <summary>
        /// Finds and returns the sum of a list of binary numbers.
        /// </summary>
        private int[] SumOf(List<int[]> terms, int depth = 0)
        {
            //Check for end of recurion. Ignoring the off by one error as we are returning 0 at max index + 1 instead of the last element.
            if (terms.Count == depth)
            {
                //This is equivilant to 0 as such does not effect final result.
                return Array.Empty<int>();
            }

            //Recusive call
            var total = SumOf(terms, depth + 1);
            //Sum of 2 binary numbers can be at most 1 bit longer than the longest term involved.
            var result = total.Length > terms[depth].Length ? new int[total.Length + 1] : new int[terms[depth].Length + 1];

            //Ensure arrays being added are the same length to prevent array out of bounds issues
            var x = new int[result.Length];
            var y = new int[result.Length];

            //The binary number is fliped to make it easier to work with (Move least significat figure to the 0 index and most significant to the last) 
            Array.Copy(total.Flip(), x, total.Length);
            Array.Copy(terms[depth].Flip(), y, terms[depth].Length);

            var carry = 0;
            //For each bit of the numbers
            for (int i2 = 0; i2 < result.Length; i2++)
            {
                //Add them together including the carry
                var sum = x[i2] + y[i2] + carry;

                //Then check the result and set both the output bit and the carry.
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
                        //Fail loudly.
                        throw new Exception($"Invaid state: Sum should be (0, 1, 2, or 3) was actually {sum}");
                }
            }

            //Trim all excess 0 from the most sig figure until we hit the first real sig figure.
            while (result[result.Length - 1].Equals(0)) { 
                var trimed = new int[result.Length - 1];
                Array.Copy(result, trimed, trimed.Length);
                result = trimed;
            }

            //Flip the result back to the format the method inputs are in.
            return result.Flip();
        }
    }
}
