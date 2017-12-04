using System;
using System.Threading;

namespace MemoryLeak
{
    class Program
    {

        public static void Main(string[] args)
        {
            SimpleObj obj = new SimpleObj();
            for (int i = 0; i < 10000; i++)
            {
                obj.CreateMemoryLeakClassAndTryQuit();
                Thread.Sleep(500);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine("Press <Enter> to continue.......");
            Console.ReadLine();
        }
    }
}
