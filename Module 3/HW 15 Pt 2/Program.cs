using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HW_15_Pt_2
{
    class Program
    {
        private static double Integral(Func<double, double> func, int a, int b, int n)
        {
            // без этого каждый таск обращался к одному и тому же экземпляру Random, и потоки ждали доступа к нему
            Random random = new Random();
            int correct = 0;
            int minX = a, maxX = b;
            int maxY = (int) Math.Max(func(a), func(b)) + 1;
            for (int i = 0; i < n; i++)
            {
                double x = random.Next(minX, maxX) + random.NextDouble();
                double y = random.Next(0, maxY) + random.NextDouble();
                if (y <= func(x))
                {
                    correct++;
                }
            }

            return (double) correct / n * (maxX - minX) * maxY;
        }

        public static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Integral");
            Console.WriteLine(Integral(x => x * x, 0, 4, (int) 1e7));
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds * 1.0 / 1000);

            timer.Start();
            Task<double>[] t =
            {
                Task.Run(() => Integral(x => x * x, 0, 1, (int) 1e7)),
                Task.Run(() => Integral(x => x * x, 1, 2, (int) 1e7)),
                Task.Run(() => Integral(x => x * x, 2, 3, (int) 1e7)),
                Task.Run(() => Integral(x => x * x, 3, 4, (int) 1e7))
            };

            Task.WaitAll(t);
            double res = 0;
            for (int i = 0; i < 4; i++)
            {
                res += t[i].Result;
            }

            Console.WriteLine(res);
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds * 1.0 / 1000);
        }
    }
}