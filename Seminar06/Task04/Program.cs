/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Вывести все слова из 4 букв. Текст вводит пользователь с клавиатуры.
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
                var rgx = new Regex(@"\b\w{4}\b");
                var matches = rgx.Matches(text);
                foreach (Match m in matches)
                {
                    Console.WriteLine("[" + m + "]");
                }
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода новой строки.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}