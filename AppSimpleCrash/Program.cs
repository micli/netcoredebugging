using System;

namespace AppSimpleCrash
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World".ToUpper());
            new MyMethods().NowCrashThisApplication();
        }
    }
}
