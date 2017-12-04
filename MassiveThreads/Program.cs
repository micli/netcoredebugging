using System;
using System.Threading;
namespace MassiveThreads
{
	internal class Program
	{
		private static object obj;
		private static ReaderWriterLock rwl;
		private static ReaderWriterLockSlim rwlSlim;
		private static Mutex mutex;
		private static Random rand = new Random();
		private static void Main(string[] args)
		{
			if (args.Length != 1)
			{
				Console.WriteLine("mutex, rw, rwslim");
			}
			else
			{
				if (args[0] == "rw")
				{
					Program.rwl = new ReaderWriterLock();
				}
				else
				{
					if (args[0] == "rwslim")
					{
						Program.rwlSlim = new ReaderWriterLockSlim();
					}
					else
					{
						if (args[0] == "mutex")
						{
							Program.mutex = new Mutex();
						}
						else
						{
							Program.obj = new object();
						}
					}
				}
				for (int i = 0; i < 50; i++)
				{
					Thread workerThread = new Thread(new ThreadStart(Program.DoWork));
					workerThread.Start();
				}
				Thread.Sleep(900000);
			}
		}
		public static void DoWork()
		{
			int r = Program.rand.Next(0, 10);
			if (Program.rwl != null)
			{
				if (r < 2)
				{
					Thread.Sleep(20000);
					Program.rwl.AcquireReaderLock(2147483647);
					Thread.Sleep(10000);
					Program.rwl.ReleaseReaderLock();
				}
				else
				{
					Program.rwl.AcquireWriterLock(2147483647);
					Thread.Sleep(10000);
					Program.rwl.ReleaseWriterLock();
				}
			}
			else
			{
				if (Program.rwlSlim != null)
				{
					if (r < 2)
					{
						Thread.Sleep(20000);
						Program.rwlSlim.EnterReadLock();
						Thread.Sleep(10000);
						Program.rwlSlim.ExitReadLock();
					}
					else
					{
						Program.rwlSlim.EnterWriteLock();
						Thread.Sleep(10000);
						Program.rwlSlim.ExitWriteLock();
					}
				}
				else
				{
					if (Program.mutex != null)
					{
						Program.mutex.WaitOne();
						Thread.Sleep(10000);
						Program.mutex.ReleaseMutex();
					}
					else
					{
						object obj;
						Monitor.Enter(obj = Program.obj);
						try
						{
							Thread.Sleep(10000);
						}
						finally
						{
							Monitor.Exit(obj);
						}
					}
				}
			}
		}
	}
}
