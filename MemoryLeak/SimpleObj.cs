namespace MemoryLeak
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    internal class SimpleObj
    {
        public static SimpleObj instance;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event EventHandler SomethingCompleted;

        public SimpleObj()
        {
            instance = this;
        }

        public void FireEvent()
        {
            this.SomethingCompleted(null, (EventArgs) null);
        }

        public void CreateMemoryLeakClassAndTryQuit()
        {
            new MemoryLeaksClass().TryQuit();
        }

    }
}

