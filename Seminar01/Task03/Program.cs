using System;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            string surname = Console.ReadLine();
            string name = Console.ReadLine();
            string whateverItsCalled = Console.ReadLine();
            Console.WriteLine("Имя: " + name);
            Console.WriteLine("Отчество: {0}", surname);
            Console.WriteLine($"Фамилия: {whateverItsCalled}");
            Console.WriteLine("Для завершения нажмите Enter");
            Console.ReadLine();
        }
    }
}