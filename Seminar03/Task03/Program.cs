/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Написать метод, вычисляющий логическое значение функции G=F(X,Y). Результат равен true, если
    точка с координатами (X,Y) попадает в фигуру G, и результат равен false, если точка с координатами (X,Y)
    не попадает в фигуру G. Фигура G - сектор круга радиусом R=2 в диапазоне углов -90<= fi <=45.
    Дата:        2021.10.12
*/

using System;

namespace Task03
{
    class Program
    {
        /// <summary>
        /// Определяет, принадлежит ли точка фигуре G
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="belongs"></param>
        static void G(double x, double y, out bool belongs)
        {
            belongs = Math.Sqrt(x * x + y * y) <= 2 && (x >= 0 && y <= 0 || x >= y && y > 0);
        }
        static void Main(string[] args)
        {
            // нажатая пользователем клавиша
            ConsoleKeyInfo keyToExit;
            do
            {
                // координаты точки
                double x, y;
                // результат
                bool res;
                do
                {
                    Console.Write("Введите координату x: ");
                } while (!double.TryParse(Console.ReadLine(), out x));
                do
                {
                    Console.Write("Введите координату y: ");
                } while (!double.TryParse(Console.ReadLine(), out y));
                
                G(x,y, out res);
                Console.WriteLine(res);
                Console.WriteLine("Для выхода нажмите Escape....");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}