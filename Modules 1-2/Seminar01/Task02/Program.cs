using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите Ваше имя:");
            string name = Console.ReadLine();
            Console.WriteLine($"Приветствую Вас, {name}");
            Console.WriteLine("Для завершения нажмите ENTER");
            Console.ReadLine();
        }
    }
}