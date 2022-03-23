using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace HW_14
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            do
            {
                /* В некоторой̆ коллекции хранятся целые числа.
                1. Составить LINQ-выражение, формирующее коллекцию их квадратов.
                2. Составить LINQ- выражение, выбирающее только положительные двузначные числа.
                3. Составить LINQ- выражение, выбирающее только чётные числа и сортирующее их по убыванию.
                4. Составить LINQ- выражение, группирующее числа по порядку (сотни, десятки, единицы)
                Написать программу, применяющую выражения к коллекции из n (задать с клавиатуры) случайных чисел из отрезка
                [-1000, 1000]. (снабдить выводом исходных чисел и сформированных коллекций). */
                Console.WriteLine("Введите число (это HW 14!): ");
                int.TryParse(Console.ReadLine(), out int n);
                Random rnd = new();
                List<int> list = Enumerable.Range(0, n).Select(x => rnd.Next(-1000, 1001)).ToList();
                list.ForEach(x => Console.Write(x + " "));
                Console.WriteLine();
                // 1
                list.Select(x => x * x)
                    .ToList()
                    .ForEach(x => Console.Write(x + " "));
                Console.WriteLine();
                // 2
                list.Where(x => x <= 99 && x >= 10)
                    .ToList()
                    .ForEach(x => Console.Write(x + " "));
                Console.WriteLine();
                // 3 
                list.Where(x => x % 2 == 0)
                    .OrderByDescending(x => x)
                    .ToList()
                    .ForEach(x => Console.Write(x + " "));
                Console.WriteLine();
                // 4
                list.GroupBy(x => { return Math.Abs(x).ToString().Length; })
                    .ToList()
                    .ForEach(x =>
                    {
                        Console.WriteLine($"Length: {x.Key}");
                        foreach (var elem in x)
                        {
                            Console.Write(elem + " ");
                        }
                        Console.WriteLine();
                    });
                Console.WriteLine("Нажмите Esc для завершения программы и любую другую клавишу иначе");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}