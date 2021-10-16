/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Дана строка (вводится пользователем), состоящая из русских слов,
    разделенных пробелами (одним или несколькими). Вывести количество слов,
    начинающихся с гласной буквы.
    Дата:       2021.10.14
*/

using System;
using System.Linq;
using System.Text;

namespace Task01
{
    class Program
    {
        /// <summary>
        /// Считает количество слов, начинающихся с гласной буквы.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="amnt"></param>
        static void CountVowelWords(ref string str, out uint amnt)
        {
            // считает, продолжается ли сейчас последовательность символов (слово).
            bool inWord = false;
            //искомое кол-во символов.
            amnt = 0;
            char[] VOWELS = new char[] {'А', 'а', 'У', 'у', 'Э', 'э', 'О', 'о', 'Я','я','И','и','ю','Ю','Е','е','Ё','ё',};
            for (int i = 0; i < str.Length; i++)
            {
                // Первая буква слова.
                if (str[i] != ' ' && !inWord)
                {
                    inWord = true;
                    if (VOWELS.Contains(str[i])) amnt++;

                }
                else if (str[i] == ' ')
                {
                    inWord = false;
                }
            }
        }

        static void Main(string[] args)
        {
            // нажатая пользователем клавиша.
            ConsoleKeyInfo keyToExit;
            do

            {
                uint result;
                //ввод строки.
                Console.WriteLine("Введите предложение:");
                string sentence = Console.ReadLine();
                CountVowelWords(ref sentence, out result);
                Console.WriteLine(result);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода новой строки.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}