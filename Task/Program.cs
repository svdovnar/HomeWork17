using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> carList = new List<Car>();
            Stopwatch stopwatch = new Stopwatch();

            for (int i = 0; i < 10000000; i++)
            {
                carList.Add(new Car(i));
            }

            stopwatch.Start();
            foreach (var item in carList)
            {
                item.Age += (343 * 34 * 2 * 77) / 567;
            }
            stopwatch.Stop();
            Console.WriteLine($"Цикл Foreach---> {stopwatch.ElapsedTicks}");
            stopwatch.Reset();

            stopwatch.Start();
            for (int i = 0; i < carList.Count; i++)
            {
                carList[i].Age += (343 * 34 * 2 * 77) / 567;
            }
            stopwatch.Stop();
            Console.WriteLine($"Цикл for---> {stopwatch.ElapsedTicks}");
            stopwatch.Reset();

            stopwatch.Start();
            Parallel.For(0, carList.Count, i =>
            {
                carList[i].Age += (343 * 34 * 2 * 77) / 567;
            });
            stopwatch.Stop();
            Console.WriteLine($"Цикл Parallel.For---> {stopwatch.ElapsedTicks}");
            stopwatch.Reset();

            stopwatch.Start();
            Parallel.ForEach(carList, car =>
            {
                car.Age += (343 * 34 * 2 * 77) / 567;
            });
            stopwatch.Stop();
            Console.WriteLine($"Цикл Parallel.ForEach---> {stopwatch.ElapsedTicks}");

            Console.ReadLine();
        }
    }
}
