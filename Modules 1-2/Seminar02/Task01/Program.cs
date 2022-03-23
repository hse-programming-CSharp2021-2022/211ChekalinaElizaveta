/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Ввести значение x и вывести значение полинома: F(x) = 12x4 + 9x3 - 3x2 + 2x – 4. 
    Не применять возведение в степень. Использовать минимальное количество операций умножения.    
    Дата:        2021.10.11
*/

using System;

namespace Task01
{
    class Program
    {
        static void Polynom(double x, out double value)
        {
            value = x * (x * (x * (12 * x + 9) - 3) + 2) - 4; // минимум операций умножения  - 4 
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo keyToExit; // нажатая пользователем клавиша
            double x; // аргумент полинома
            double res; // значение полинома
            string str; // вводимая строка
            do
            {
                do
                {
                    Console.Write("Введите число: ");
                    str = Console.ReadLine();
                } while (!double.TryParse(str, out x));

                Polynom(x, out res);
                Console.WriteLine($"Polynom's value is: {res}");
                Console.WriteLine("Для выхода нажмите Escape....");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}