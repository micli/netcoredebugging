using System;

namespace CrashAtFinalizer
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleObj obj = null;
            for(int i = 0; i < 2; i++)
            {
               obj = new SimpleObj();
               obj.DoSomething();

            }
            
            obj = null;
            GC.Collect();
            Console.WriteLine("Press Enter to exit.");
            GC.Collect();            
            Console.ReadLine();
        }
    }
}
