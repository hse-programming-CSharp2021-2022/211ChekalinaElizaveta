/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Дан фрагмент текста, запрашиваемый у пользователя. 
    Написать программу, находящую наибольшее количество цифр, идущих в нём подряд.
    Дата:       2021.10.16
*/

using System;
using System.Text.RegularExpressions;


namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            // нажатая пользователем клавиша.
            ConsoleKeyInfo keyToExit;
            do
            {
                string text = Console.ReadLine(); 
                var rgx = new Regex(@"\d+");
                var matches = rgx.Matches(text);
                int l = 0;
                string max = "";
                foreach (Match m in matches)
                {
                    string n = m.ToString();
                    if (l < n.Length)
                    {
                        l = n.Length;
                        max = n;
                    }
                }
                Console.WriteLine(max);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода новой строки.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}