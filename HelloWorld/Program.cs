using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {

        public static async Task HelloWorld(int timeout)
        {
            await Task.Delay(timeout);
            Console.WriteLine("Hello World");
        }

        private static async void doWork()
        {
            Console.WriteLine("Being Task");
            await HelloWorld(5000);
            Console.WriteLine("Done");
        }        
        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to Start");
            Console.ReadLine();
            doWork();
            Console.ReadLine();
        }
    }
}
