/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Введя значения коэффициентов А, В, С, вычислить корни квадратного уравнения. 
    Учесть (как хотите) возможность появления комплексных корней. Оператор if не применять.  
    Дата:        2021.10.11
*/

using System;

namespace Task03
{
    class Program
    {
        static void CalculateRoots(int a, int b, int c, out int amount, out double root1, out double root2) {
            // Вспомогательные переменные
            double Discr; // дискриминант
            Discr = b * b - 4 * a * c;
            amount = Discr >= 0 ? (Discr > 0 ? 2 : 1) : 0; // кол-во корней
            root1 = amount > 0 ? ((-b + Math.Sqrt(Discr)) / (2*a)) : 0; // корень 1, если есть
            root2 = amount > 1 ? ((-b - Math.Sqrt(Discr)) / (2*a)) : 0; // корень 2, если есть

        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyToExit;   // нажатая пользователем клавиша
            int a, b, c;                // коэффициенты кв. ур-ния
            double root1 = 0, root2 = 0;// корни (если есть)
            int amount;                 // кол-во корней
            do
            {
                do {
                    Console.Write("Введите коэфф. a: ");
                } while (!int.TryParse(Console.ReadLine(), out a));
                do {
                    Console.Write("Введите коэфф. b: ");
                } while (!int.TryParse(Console.ReadLine(), out b));
                do {
                    Console.Write("Введите коэфф. c: ");
                } while (!int.TryParse(Console.ReadLine(), out c));
                
                CalculateRoots(a, b, c, out amount, out root1, out root2);
                
                Console.WriteLine($"Кол-во действительных корней: {amount}");
                
                string res = (amount > 0 ? (amount > 1 ? $"Корни: {root1:F3}, {root2:F3}\n" : $"Корень: {root1:F3}\n") : "");
                Console.Write(res);
                
                Console.WriteLine("Для выхода нажмите Escape....");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}