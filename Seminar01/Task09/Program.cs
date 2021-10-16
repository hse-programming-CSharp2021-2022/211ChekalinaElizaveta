using System;

namespace Task09
{
    class Program
    {
        static void Main(string[] args)
        {
            double first, second;
            string a, b;
            a = Console.ReadLine();
            b = Console.ReadLine();
            double.TryParse(a, out first);
            double.TryParse(b, out second);
            first = first - (int)first;
            second = second - (int)second;
            Console.WriteLine(first+second);
            Console.WriteLine("Для завершения нажмите enter");
            Console.ReadLine();

        }
    }
}