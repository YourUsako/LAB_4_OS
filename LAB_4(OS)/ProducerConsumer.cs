using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace LAB_4_OS_
{
    class ProducerConsumer
    {

        private readonly BlockingCollection<int> _numberQueue;
        private readonly int _interval;
        private readonly int _capacity;

        public ProducerConsumer(int interval, int capacity)
        {
            this._interval = interval;
            this._capacity = capacity;
            this._numberQueue = new BlockingCollection<int>(_capacity);
        }


        public void Produce()
        {
            while (true)
            {
                Random r = new Random();
                int genRand = r.Next(10, 50);
                _numberQueue.Add(genRand);
                Thread.Sleep(1000 * _interval);
            }
        }

        public void Consume()
        {
            while (true)
            {
                if (_numberQueue.IsCompleted)
                {
                    Thread.Sleep(1000);
                }
                int num = _numberQueue.First();
                long factorial = Factorial(num);
                Console.WriteLine($"Число: {num}  Факториал числа: {factorial}");
            }
        }
        private static int Factorial(int x)
        {
            if (x == 0)
                return 1;
            else
                return x * Factorial(x - 1);
        }
    }
}

