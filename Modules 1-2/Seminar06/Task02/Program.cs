/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Дана строка (вводится пользователем), состоящая из русских слов,
                разделенных пробелами (одним или несколькими).
                Вывести количество слов, состоящих более чем из четырех букв.
    Дата:       2021.10.14
*/

using System;
using System.Text;

namespace Task01
{
    class Program
    {
        /// <summary>
        /// Считает количество слов, состоящих из пяти и более букв.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="amnt"></param>
        static void CountWords(ref string str, out uint amnt)
        {
            // считает, продолжается ли сейчас последовательность символов (слово).
            bool inWord = false;
            //длина текущего слова.
            uint wordLen = 0;
            //искомое кол-во символов.
            amnt = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    wordLen += 1;
                    inWord = true;
                }
                else if (inWord)
                {
                    if (wordLen > 4) amnt++;
                    wordLen = 0;
                    inWord = false;
                }
            }

            if (inWord & wordLen > 4) amnt++;
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
                CountWords(ref sentence, out result);
                Console.WriteLine(result);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода новой строки.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}