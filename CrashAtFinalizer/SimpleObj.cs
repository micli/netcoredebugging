using System;

namespace CrashAtFinalizer
{
    public class SimpleObj
    {
        public SimpleObj()
        {
            Console.WriteLine("Simple object constructed.");
        }

        public void DoSomething()
        {
            Console.WriteLine("Do something.");
        }

        ~SimpleObj()
        {
            Console.WriteLine("Simple object deconstructing.");          
            throw new NullReferenceException();
        }
    }
}