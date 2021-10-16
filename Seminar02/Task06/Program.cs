/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Получить от пользователя вещественное значение – бюджет пользователя и целое число – 
    процент бюджета, выделенный на компьютерные игры. Вычислить и вывести на экран сумму в рублях/евро
    или долларах, выделенную на компьютерные игры. Использовать спецификаторы формата для валют
    Дата:        2021.10.11
*/

using System;

namespace Task06
{
    class Program
    {
        static void ToEuro(double roubles, out double euros)
        {
            euros = roubles / 83.02;
        }

        static void ToDollars(double roubles, out double dollars)
        {
            dollars = roubles / 71.85;
        }

        static void GetPercentage(double roubles, uint percentage, out double res)
        {
            res = roubles * percentage / 100;
        }
        
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyToExit; // нажатая пользователем клавиша
            double budget;            // бюджет пользователя
            uint percentage;          // процент под компьютерные; в условии не указан тип, предположила, что целый.
            double res;               // часть под игры
            double euro, bucks;       // значение в евро и долларах 
            do
            {
                do
                {
                    Console.Write("Введите бюджет: ");
                } while (!double.TryParse(Console.ReadLine(), out budget) | budget < 0);
                do
                {
                    Console.Write("Введите процент бюджета под игры: ");
                } while (!uint.TryParse(Console.ReadLine(), out percentage) | percentage > 100);
               
                GetPercentage(budget, percentage, out res);
                //ToEuro(res, out euro); // при желании можно также подсчитать в евро
                ToDollars(res, out bucks);
                //Console.OutputEncoding = System.Text.Encoding.Unicode;
                System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Console.WriteLine($"В долларах это: {bucks:c}");
                Console.WriteLine("Для выхода нажмите Escape....");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}