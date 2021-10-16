/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Получить от пользователя четырехзначное натуральное число и напечатать его цифры в обратном порядке.
    Дата:        2021.10.11
*/

using System;

namespace Task04
{
    class Program
    {
        static void Numerals(uint number, out uint first, out uint second, out uint third, out uint last)
        {
            first = number / 1000;           // первая цифра
            second = number / 100 % 10;      // вторая цифра
            third = number / 10 % 10;        // третья цифра
            last = number % 10;              // четвёртая цифра
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyToExit;   // нажатая пользователем клавиша
            uint a, b, c, d;            // цифры числа
            uint number;                // введённое число
            string res;                 // результат
            do
            {
                do {
                    Console.Write("Введите четырёхзначное число: ");
                } while (!uint.TryParse(Console.ReadLine(), out number) | number < 1000 | number > 9999);
                
                Numerals(number, out a, out b, out c, out d);
                res = "" + d + c + b + a; // привет JS и неявному приведению типов
                // Кстати, в задаче не сказано, должны быть цифры или число;
                // будь это числом, я бы сделала так:
                //res = (d * 1000 + c * 100 + b * 10 + a) + "";
                
                Console.WriteLine("Цифры числа в обратном порядке: " + res);
                Console.WriteLine("Для выхода нажмите Escape....");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}