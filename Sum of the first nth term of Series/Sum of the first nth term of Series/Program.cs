using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_of_the_first_nth_term_of_Series
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please inpout a number:");
            int m = int.Parse(Console.ReadLine());

            Console.WriteLine(NthSeries.seriesSum(m));

            Console.ReadKey();
        }
    }
}
