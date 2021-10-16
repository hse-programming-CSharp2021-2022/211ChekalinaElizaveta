using System;

namespace Testt
{
    class Program
    {
        
        static int Sum(int a)
        {
            int sum = 0;
            while (a>0)
            {
                sum += a % 10;
                a = a / 10;

            }
            return sum;
        }
        
        /// <summary>
        /// Считывает с клавиатуры одно целое число.
        /// </summary>
        /// <param name="num"></param>
        static void ReadNumber(out int num)
        {
            do
            {
                Console.Write("Введите число: ");
            } while (!int.TryParse(Console.ReadLine(), out num) || num <= 0);
        }
        
        static void Main(string[] args)
        {
            while (true)
            {
                int n;
                ReadNumber(out n);
                Console.WriteLine(Sum(n));
            }
        }
    }
}