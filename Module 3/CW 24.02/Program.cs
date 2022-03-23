using System;
using System.Collections;
using System.Collections.Generic;

namespace CW_24._02
{
    class Fibbonacci : IEnumerable
    {
        int s = 1, n = 0, limit;

        public IEnumerable NextMemb(int limit)
        {
            int t;
            for (int i = 0; i < limit; i++)
            {
                t = s + n;
                s = n;
                yield return n = t;
            }
        }

        public Fibbonacci()
        {
            
        }

        public Fibbonacci(int limit)
        {
            this.limit = limit;
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(limit, s, n);
        }

        class Enumerator : IEnumerator
        {
            private int s, n, limit, i;

            public Enumerator(int limit , int s, int n)
            {
                this.s = s;
                this.i = 0;
                this.n = n;
                this.limit = limit;
            }

            public bool MoveNext()
            {
                if (i >= limit)
                {
                    return false;
                }

                int t = s + n;
                s = n;
                n = t;
                i++;
                return true;
            }

            public void Reset()
            {
                s = 1;
                n = 0;
                i = 0;
            }

            public object Current => n;
        }
    }

    static class Program
    {
        public static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            do
            {
                int.TryParse(Console.ReadLine(), out int n);
                Fibbonacci fibs2 = new Fibbonacci();
                foreach (int num in fibs2.NextMemb(n))
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
                foreach (int num in fibs2.NextMemb(n))
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
                Fibbonacci fibs = new Fibbonacci(n);
                foreach (int num in fibs)
                {
                    Console.Write(num + " ");
                }
                foreach (int num in fibs)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Нажмите Esc для завершения программы и любую другую клавишу иначе");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}