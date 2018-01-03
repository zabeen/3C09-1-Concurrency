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

        private DataStore store1 = new DataStore();
        private DataStore store2 = new DataStore();

        public void TestConcurrency()
        {
            var thread1 = new Thread(IncrementTheValue1);
            var thread2 = new Thread(IncrementTheValue2);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Final values: {store1.Value}, {store2.Value}");
        }

        private void IncrementTheValue1()
        {
            lock (store1)
            {
                lock (store2)
                {
                    store1.Value++;
                    store2.Value++;
                }
            }
        }

        private void IncrementTheValue2()
        {
            lock (store2)
            {
                lock (store1)
                {
                    store1.Value++;
                    store2.Value++;
                }
            }
        }
    }
}
