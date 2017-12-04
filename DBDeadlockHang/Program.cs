using System;
using System.Threading;

namespace DBDeadlockHang
{
    public class Program
    {
        private static DBWrapper1 db1;
        private static DBWrapper2 db2;

        static void Main(string[] args)
        {
            db1 = new DBWrapper1("DBCon1");
            db2 = new DBWrapper2("DBCon2");
            new Thread(new ThreadStart(Program.ThreadProc)).Start();
            Thread.Sleep(0x7d0);
            lock (db2)
            {
                Console.WriteLine("Updating DB2");
                Thread.Sleep(0x7d0);
                lock (db1)
                {
                    Console.WriteLine("Updating DB1");
                }
            }
        }

        private static void ThreadProc()
        {
            Console.WriteLine("Start worker thread");
            lock (db1)
            {
                Console.WriteLine("Updating DB1");
                Thread.Sleep(0xbb8);
                lock (db2)
                {
                    Console.WriteLine("Updating DB2");
                }
            }
            Console.WriteLine("Out");
        }
    }
}
