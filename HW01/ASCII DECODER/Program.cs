using System;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            int.TryParse(Console.ReadLine(), out n);
            char res = (char) n;
            Console.WriteLine(res);
        }
    }
}