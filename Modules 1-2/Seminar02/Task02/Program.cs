/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Ввести натуральное трехзначное число Р. 
    Найти наибольшее целое число, которое можно получить, переставляя цифры числа Р.  
    Дата:        2021.10.11
*/

using System;

namespace Task02
{
    class Program
    {
        public static void ValuesSort(ref uint x, ref uint y, ref uint z) {
            // Вспомогательные переменные
            uint a1 = 0, a2 = 0, a3 = 0;
            a1 = x < y ? (z < x ? z : x) : (y < z ? y : z);
            a3 = x > y ? (z > x ? z : x) : (y > z ? y : z);
            a2 = x > y ? (y > z ? y : (x > z ? z : x)) : (y > z ? (x > z ? x : z) : y);
            z = a1; y = a2; x = a3;
        }
        static void Numerals(uint number, out uint first, out uint second, out uint third)
        {
            first = number / 100;           // первая цифра
            second = number / 10 % 10;      // вторая цифра
            third = number % 10;            // третья цифра
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo keyToExit;   // нажатая пользователем клавиша
            uint numb = 100;            // число
            string res;                 // результат
            do
            {
                do Console.Write("Введите целое число от 100 до 999: ");
                while (!uint.TryParse(Console.ReadLine(), out numb) ||
                       numb < 100 || numb > 999);
                uint first, second, third;
                Numerals(numb, out first, out second, out third);
                ValuesSort(ref first, ref second, ref third);
                res = first.ToString() + second.ToString() + third.ToString();
                Console.WriteLine($"Max value is: {res}");
                Console.WriteLine("Для выхода нажмите Escape....");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}