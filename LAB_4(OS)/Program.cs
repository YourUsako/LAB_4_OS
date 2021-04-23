using System;
using System.Threading;
namespace LAB_4_OS_
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 4;
            int capacity = 5;
            int interval = 10;

            Thread[] producerThreads = new Thread[length];
            Thread[] consumerThreads = new Thread[length];

            for (int i = 0; i < length; i++)
            {
                var c = new ProducerConsumer(interval, capacity);
                producerThreads[i] = new Thread(() => {
                    try
                    {
                        c.Produce();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                });
                consumerThreads[i] = new Thread(() => {
                    try
                    {
                        c.Consume();
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                });
            }


            foreach (Thread producerThread in producerThreads)
            {
                producerThread.Start();
            }
            foreach (Thread consumerThread in consumerThreads)
            {
                consumerThread.Start();
            }

            foreach (Thread producerThread in producerThreads)
            {
                producerThread.Join();
            }

            foreach (Thread consumerThread in consumerThreads)
            {
                consumerThread.Join();
            }
        }
    }
}
