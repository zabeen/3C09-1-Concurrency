using System;
using System.Threading;

namespace ConcurrencyTest
{
    public class ConcurrencyTest
    {
        private class DataStore
        {
            public int Value { get; set; }
        }

        private DataStore store = new DataStore();

        public void TestConcurrency()
        {
            var thread1 = new Thread(IncrementTheValue);
            var thread2 = new Thread(IncrementTheValue);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Final value: {store.Value}");
        }

        private void IncrementTheValue()
        {
            lock (store)
            {
                store.Value++;
            }
        }
    }
}
