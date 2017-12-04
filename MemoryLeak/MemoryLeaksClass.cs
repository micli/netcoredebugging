namespace MemoryLeak
{
    using System;

    public class MemoryLeaksClass
    {
        public MemoryLeaksClass()
        {
            SimpleObj.instance.SomethingCompleted += new EventHandler(this.OnSomethingCompleted);
            Console.WriteLine("\nObject-{0}: Construct. Subscribe.", (int) this.GetHashCode());
        }

        ~MemoryLeaksClass()
        {
            Console.WriteLine("Object-{0}: deconstructed.", (int) this.GetHashCode());
        }

        private void OnSomethingCompleted(object sender, EventArgs e)
        {
        }

        public void TryQuit()
        {
            // How about Describe the event?
            // SimpleObj.instance.SomethingCompleted -= new EventHandler(this.OnSomethingCompleted);
        }
    }
}

