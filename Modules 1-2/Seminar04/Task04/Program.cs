/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     В основной программе ввести значения трех вещественных чисел. 
    Если числа могут быть длинами сторон треугольника - вычислить его площадь по формуле Герона. 
    Написать метод, вычисляющий площадь (s) и периметр (p) треугольника по заданным длинам его сторон.
    Метод должен возвращать значение false, если параметры заданы неверно и треугольник с такими длинами
    построить нельзя. При удачном задании длин сторон метод возвращает true. 
    Заголовок метода: bool Triangle(double x, double y, double z, out double p, out double s)
    Основная программа, используя метод, «общается» с пользователем.
    Дата:        2021.10.12
*/

using System;

namespace Task04
{
    class Program
    {
        /// <summary>
        /// Считывает с клавиатуры одно вещественное число.
        /// </summary>
        /// <param name="number"></param>
        static void ReadNum(out double number)
        {
            do
            {
                Console.Write("Введите число. ");
            } while (!double.TryParse(Console.ReadLine(), out number));
        }
        
        /// <summary>
        /// Проверяет, существует ли треугольник, и вычисляет его площадь и периметр, если да.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="p"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        static bool Triangle(double x, double y, double z, out double p, out double s){
            if (x + y <= z || z + y <= x || z + x <= y)
            {
                p = 0; s = 0;
                return false;
            }

            p = x + z + y;
            // полупериметр
            double halfp = p / 2;
            s = Math.Sqrt(halfp*(halfp-x)*(halfp-y)*(halfp-z));
            return true;
        }
        
        static void Main(string[] args)
        {
            // нажатая пользователем клавиша
            ConsoleKeyInfo keyToExit;
            do
            {
                //длины сторон потенциального треугольника
                double a, b, c;
                // Площадь и периметр
                double s, p;
                // true, если такой треуг. можно построить
                bool exists; 
                ReadNum(out a);
                ReadNum(out b);
                ReadNum(out c);
                exists = Triangle(a, b, c, out p, out s);

                if (exists)
                {
                    Console.WriteLine("Треугольник существует. Его периметр: {0:F3}, площадь: {1:F3}", p, s);
                }
                else
                {
                    Console.WriteLine("Такого треугольника не существует!");
                }
                
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода нового набора сторон.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}