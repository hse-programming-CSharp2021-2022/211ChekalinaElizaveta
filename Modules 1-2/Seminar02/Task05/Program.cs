/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Получить от пользователя три вещественных числа и проверить для них неравенство треугольника.
    Оператор if не применять. Точность вывода три знака после запятой.
    Дата:        2021.10.11
*/

using System;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyToExit; // нажатая пользователем клавиша
            double a, b, c; // стороны треугольника
            double sum; // сумма двух чисел
            string res; // меньше или нет?
            bool OK; // выполняется ли нер-во
            do
            {
                do
                {
                    Console.Write("Введите первое число: ");
                } while (!double.TryParse(Console.ReadLine(), out a));
                do
                {
                    Console.Write("Введите второе число: ");
                } while (!double.TryParse(Console.ReadLine(), out b));
                do
                {
                    Console.Write("Введите третье число: ");
                } while (!double.TryParse(Console.ReadLine(), out c));
                sum = a + b;
                res = a + b > c ? "больше" : "не больше";
                OK = a + b > c;
                Console.WriteLine($"Сумма чисел {a:F3} + {b:F3} = {sum:F3} {res} {c:F3}.");
                sum = b + c;
                res = b + c > a ? "больше" : "не больше";
                OK = OK & b + c > a;
                Console.WriteLine($"Сумма чисел {b:F3} + {c:F3} = {sum:F3} {res} {a:F3}.");
                sum = a + c;
                res = a + c > b ? "больше" : "не больше";
                OK = OK & a + c > b;
                Console.WriteLine($"Сумма чисел {a:F3} + {c:F3} = {sum:F3} {res} {b:F3}.");
                res = OK ? "Нер-во треугольника выполняется" : "Нер-во треугольника не выполняется";
                Console.WriteLine(res);
                Console.WriteLine("Для выхода нажмите Escape....");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}