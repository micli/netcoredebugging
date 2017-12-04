using System;
using System.Threading;

namespace HighCPU
{
    class Program
    {
        private static bool _stop = true;
        static void Main(string[] args)
        {
            Console.WriteLine("Now high CPU...");
            Thread t = new Thread(new ThreadStart(HighCPU));
            t.Start();
            Console.WriteLine("Press <Enter> to exit.");
            Console.ReadLine();
        }

        private static void HighCPU()
		{
			System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.BelowNormal;
			long x = 0;
			long z = 0;
			while(_stop)
			{
				x = x + 1;
				z = 0;
				for(int y = 0; y < 1000; y++)
				{
					z = z + 1;
				}
			}
			System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal;
		}
    }
}
