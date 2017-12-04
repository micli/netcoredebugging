namespace AppSimpleCrash
{
    using System;

    public class MyMethods
    {
        public void NowCrashThisApplication()
        {
            Console.WriteLine("Welcome to .NET Core world, the OSS offering from Microsoft & Community to develop Corss Platform Applications using .NET Framework".ToUpper());
            string str = null;
            Console.WriteLine(str.ToLower());
        }
    }
}

