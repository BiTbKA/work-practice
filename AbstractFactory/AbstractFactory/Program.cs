using AbstractFactory.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager(new CocaColaFactory());
            manager.Run();

            manager = new Manager(new PepsiColaFactory());
            manager.Run();

            Console.ReadKey();
        }
    }
}
