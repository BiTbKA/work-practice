using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_of_a_sequence
{
    public static class Kata
    {
        public static int SequenceSum(int start, int end, int step)
        {
            //return start > end ? 0 : Enumerable.Repeat(start, (end - start) / step + 1).Select((x, index) => x + step * index).Sum();
            int sum = 0;
            int curVal = start;
            for (; curVal <= end; curVal += step)
                sum += curVal;

            return sum;
        }
    }

    public class Recursion
    {
        public static ulong Factorial(ulong n)
        {
            checked
            {
                if (n == 0 || n == 1)
                    return 1;

                return n * Factorial(--n);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            float f = 0.8512f;
            Console.WriteLine(f);
        }
    }
}
