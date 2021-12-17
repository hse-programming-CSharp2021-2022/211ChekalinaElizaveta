using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinderella
{
    abstract class Something
    {

    }

    class Ashes : Something
    {
        private static Random rand = new Random();
        public double Volume { get; set; }

        public Ashes()
        {
            int rnd = rand.Next(0, int.MaxValue);
            if (rnd == 0)
                Volume = 1;
            else
            {
                Volume = rand.NextDouble();
            }
        }
    }

    class Lentil : Something
    {
        private static Random rand = new Random();
        public double Weight { get; set; }

        public Lentil()
        {
            int rnd = rand.Next(0, int.MaxValue);
            if (rnd == 0)
                Weight = 1;
            else
            {
                Weight = rand.NextDouble() * 2;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            ConsoleKeyInfo keyToExit;
            do
            {
                int N;
                string s;
                Random rand = new Random(119);
                // первые пять будут Ashes, просто введите ещё.
                do
                {
                    Console.WriteLine("Введите число");
                    s = Console.ReadLine();
                } while (!int.TryParse(s, out N) || N < 0);
                Something[] arr = new Something[N];
                for (int i = 0; i < N; i++)
                {
                    int coin = rand.Next(2);
                    if (coin == 0) {
                        arr[i] = new Lentil();
                    } else {
                        arr[i] = new Ashes();
                    }
                    
                }
                List<Lentil> lntls = new List<Lentil>();
                List<Ashes> ashs = new List<Ashes>();
                for (int i = 0; i<N; i++)
                {
                    if (arr[i] is Lentil) {
                        Console.WriteLine($"Lentil: {(arr[i] as Lentil).Weight}");
                        lntls.Add(arr[i] as Lentil);
                    } else
                    {
                        Console.WriteLine($"Ashes: {(arr[i] as Ashes).Volume}");
                        ashs.Add(arr[i] as Ashes);
                    }
                }
                
                for (int i = 0; i < lntls.Count; i++)
                {
                    Console.WriteLine($"Lentil: {lntls[i].Weight}");
                }
                for (int i = 0; i < lntls.Count; i++)
                {
                    Console.WriteLine($"Ashes: {ashs[i].Volume}");

                }
                    Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для повтора решения.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }

}
