using System;

namespace ConcurrencyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 1; i < 101; i++)
            {
                Console.Write($"{i}: ");
                new ConcurrencyTest().TestConcurrency();
            }
            
            Console.ReadLine();
        }
    }
}
