/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Написать программу с использованием двух методов. 
    Первый метод возвращает дробную и целую часть числа. Второй метод возвращает квадрат и корень из числа. 
    В основной программе пользователь вводит дробное число. 
    Программа должна вычислить, если это возможно, значение корня, квадрата числа, выделить целую и дробную часть из числа.
    Дата:        2021.10.11
*/

using System;

namespace Task07
{
    class Program
    {
        static void IntAndDec(double number, out int integer, out double dec)
        {
            integer = (int) number;
            dec = number - integer;
        }

        static void SquareAndRoot(double number, out double sqr, out double rt)
        {
            sqr = number * number;
            rt = number >= 0 ? Math.Sqrt(number) : -1;
        }
        
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyToExit; // нажатая пользователем клавиша
            double number;            // число
            int cel;                  // целая часть
            double drob, sqr, rt;     // дробная часть, квадрат, корень
            string res;               // результат для корня  
            do
            {
                do
                {
                    Console.Write("Введите число: ");
                } while (!double.TryParse(Console.ReadLine(), out number));
                IntAndDec(number, out cel, out drob);
                SquareAndRoot(number, out sqr, out rt);
                res = rt >= 0 ? $"Корень: {rt:f3}" : "Корень не извлекается";
                
                Console.WriteLine($"Целая часть: {cel}, дробная часть: {drob:F3};");
                Console.Write($"Квадрат: {sqr:F3}, ");
                Console.WriteLine(res);
                Console.WriteLine("Для выхода нажмите Escape....");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}