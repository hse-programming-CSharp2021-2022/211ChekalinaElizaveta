using System;

namespace Task06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*-----------*--------*---------------------*");
            Console.WriteLine("|*Выражение*|*Формат*|**** Изображение ****|");
            Console.WriteLine("|-----------|--------|---------------------|");
            Console.WriteLine("| (5.0/3.0) |  F     | {0}                |", (5.0/3.0).ToString("F"));
            Console.WriteLine("| (5.0/3.0) |  F4    | {0}              |", (5.0/3.0).ToString("F4"));
            Console.WriteLine("| (5.0/3.0) |  E     | {0}       |", (5.0/3.0).ToString("E"));
            Console.WriteLine("| (5.0/3.0) |  E5    | {0}        |", (5.0/3.0).ToString("E5"));
            Console.WriteLine("| (5.0/3.0) |  G     | {0}  |", (5.0/3.0).ToString("G"));
            Console.WriteLine("| (5.0/3.0) |  G3    | {0}                |", (5.0/3.0).ToString("G3"));
            Console.WriteLine("| (5.0/3e10)|  G3    | {0}            |", (5.0/3e10).ToString("G3"));
            Console.WriteLine("|(5.0/3e-10)|  G     | {0}  |", (5.0/3e-10).ToString("G"));
            Console.WriteLine("| (5.0/3e20)|  G     |{0}|", (5.0/3e10).ToString("G"));
            Console.WriteLine("*-----------*--------*---------------------*");
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}