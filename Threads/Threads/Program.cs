using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        class myThread
        {
            Thread thread;

            public myThread(string name, int num, bool isBackground) //Конструктор получает имя функции и номер до кторого ведется счет
            {

                thread = new Thread(this.func);
                thread.IsBackground = isBackground;
                thread.Name = name;
                thread.Start(num);//передача параметра в поток
            }

            void func(object num)//Функция потока, передаем параметр
            {
                for (int i = 0; i < (int)num; i++)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " output " + i);
                    Thread.Sleep(0);
                }
                Console.WriteLine(Thread.CurrentThread.Name + " done");
            }


        }

        static void Main(string[] args)
        {
            //var thread = new Thread(Func1);

            //thread.Start();

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("Thread 1 = " + i);
            //    Thread.Sleep(0);
            //}

            myThread t1 = new myThread("Thread 1", 6, false);
            myThread t2 = new myThread("Thread 2", 3, false);
            myThread t3 = new myThread("Thread 3", 2, true);

            Console.Read();

            Console.Read();
        }

        static void Func1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread 2 = " + i.ToString());
                Thread.Sleep(0);
            }
        }

        static void Func2()
        {
            Console.WriteLine("Func2");
        }
    }
}
