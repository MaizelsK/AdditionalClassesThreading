using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AdditionalClassesThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer();

            Thread[] threads = new Thread[50];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new ThreadStart(printer.Print));
                threads[i].Name = "Поток №" + i;
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }

            #region Thread
            for (int i = 0; i < 50; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(
                    state =>
                    {
                        ((Printer)state).Print();
                    }), printer);
            }
            #endregion

            // Таймер на выполнение какого-либо метода
            Timer timer = new Timer(new TimerCallback(stubObject => Console.WriteLine("Выполняется работа")),
                                    null, 500, 2000);

            Console.ReadLine();
        }
    }
}
