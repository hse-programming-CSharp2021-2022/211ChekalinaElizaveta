using System;

namespace ConsoleApp1
{
    internal delegate int Cast(double n);

    class Program
    {
        static void Main(string[] args)
        {
            Cast Anonim1 = delegate(double n)
            {
                int ceil = (int) n;
                if (ceil % 2 == 0)
                {
                    return ceil;
                }

                return ceil + 1;
            };
            Cast Anonim2 = delegate(double k)
            {
                int poryadok = 0;
                int n = (int) k;
                while (n > 0)
                {
                    poryadok++;
                    n /= 10;
                }

                return poryadok;
            };
            double k = double.Parse(Console.ReadLine());
            Console.WriteLine(Anonim1(k));
            Console.WriteLine(Anonim2(k));
            Cast del = new Cast(Anonim1);
            del += Anonim2;
            Console.WriteLine(del.Invoke(k));
            Cast Lambda1 = n =>
            {
                int ceil = (int) n;
                if (ceil % 2 == 0)
                {
                    return ceil;
                }

                return ceil + 1;
            };
            Cast del2 = new Cast(Lambda1);
            del2 += k =>
            {
                int poryadok = 0;
                int n = (int) k;
                while (n > 0)
                {
                    poryadok++;
                    n /= 10;
                }

                return poryadok;
            };
            Console.WriteLine(del2.Invoke(k));
            del2 -= k =>
            {
                int poryadok = 0;
                int n = (int) k;
                while (n > 0)
                {
                    poryadok++;
                    n /= 10;
                }

                return poryadok;
            };
            Console.WriteLine(del2.Invoke(k));
            Cast del3 = new Cast(Anonim1);
            del3 += Anonim2;
            Console.WriteLine(del3.Invoke(k));
            del3 -= Anonim2;
            Console.WriteLine(del3.Invoke(k));
            // удаление анонимного метода реально удаляет его из списка вызовов делегата
        }
    }
}