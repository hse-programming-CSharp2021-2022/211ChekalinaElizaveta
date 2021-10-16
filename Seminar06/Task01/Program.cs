/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Задача 9
                Дана строка (вводится пользователем), состоящая из русских слов, разделенных пробелами 
                (одним или несколькими). Преобразовать ее так, чтобы между словами был ровно один пробел
                и вывести результат.
    Дата:       2021.10.14
*/

using System;
using System.Text;

namespace Task01
{
    class Program
    {
        /// <summary>
        /// Преобразует строку, убирая повторяющиеся пробелы между словами.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="res"></param>
        static void RemoveWhitespaces(ref string str, out string res)
        {
            //Построим новую строку, т. к. нас училии, что так быстрее. Если бы не было стринБилдеров, то использовала бы массив char'ов.
            var builder = new StringBuilder();
            //критерий потвторяющегося пробела
            bool wasSpace = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    builder.Append(str[i]);
                    wasSpace = false;
                }
                else
                {
                    if (!wasSpace)
                    {
                        builder.Append(str[i]);
                        wasSpace = true;
                    }
                }
            }
            res = builder.ToString();
        }
        static void Main(string[] args)
        {
            // нажатая пользователем клавиша.
            ConsoleKeyInfo keyToExit;
            do
            {
                string result;
                //ввод строки
                Console.WriteLine("Введите предложение:");
                string sentence = Console.ReadLine();
                RemoveWhitespaces(ref sentence, out result);
                Console.WriteLine(result);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода новой строки.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}