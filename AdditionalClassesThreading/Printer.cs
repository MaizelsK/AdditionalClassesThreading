using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace AdditionalClassesThreading
{
    [Synchronization]
    public class Printer : ContextBoundObject
    {
        private object lockObject = new object();
        public void Print()
        {
            lock (lockObject)
            {
                Console.WriteLine("Работает поток " + Thread.CurrentThread.Name);
                for (int i = 0; i < 10; i++)
                {
                    Random random = new Random();

                    Thread.Sleep(5 * random.Next(150));
                    Console.WriteLine(i);
                }
            }

            #region Semaphore
            //Semaphore semaphore = new Semaphore(50, 3);
            //for (int i = 0; i < 10; i++)
            //{
            //    Random random = new Random();

            //    Thread.Sleep(5 * random.Next(150));
            //    Console.WriteLine(i);
            //}
            //semaphore.WaitOne();
            #endregion

            #region Monitor
            // Тоже самое через Monitor

            //Monitor.Enter(lockObject);
            //try
            //{
            //    {
            //        for (int i = 0; i < 10; i++)
            //        {
            //            Random random = new Random();
            //
            //            Thread.Sleep(5 * random.Next(150));
            //            Console.Write(i);
            //        }
            //    }
            //}
            //finally
            //{
            //    Monitor.Exit(lockObject);
            //}
            #endregion
        }
    }
}
