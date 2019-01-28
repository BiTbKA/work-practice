using BinarySystemConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your decimal:");
            string n = Console.ReadLine();

            Console.WriteLine(Converter.ConvertToDecimal(n).Result);

            Console.ReadKey();
        }
    }
}
