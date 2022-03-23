using System;

namespace Task04
{
    //Получить от пользователя значения длин двух катетов, вычислить и вывести на экран значение гипотенузы.
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;
            double.TryParse(Console.ReadLine(), out a);
            double.TryParse(Console.ReadLine(), out b);
            c = Math.Pow((Math.Pow(a, 2) + Math.Pow(b, 2)), (1.0 / 2.0));
            Console.WriteLine(c);
        }
    }
}