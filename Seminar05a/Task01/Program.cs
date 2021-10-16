/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Задача 9
                9.1. Написать метод замены всех вхождений максимального элемента массива значением, переданным в параметре.
                9.2. В основной программе объявить и инициализировать массив; получить от пользователя число, заменить им
                все вхождения максимального элемента в массив. Исходный и изменённый массивы вывести на экран.
    Дата:       2021.10.13
*/

using System;

namespace Task04
{
    class Program
    {
        /// <summary>
        /// Вводит массив с клавиатуры. Не проверяет, правильно ли организован ввод
        /// </summary>
        /// <param name="array"></param>
        static void ReadArray(out int[] array)
        {
            Console.WriteLine("Введите массив целых чисел через пробел");
            array = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
        }

        /// <summary>
        /// Выводит на экран массив целых чисел через пробел
        /// </summary>
        /// <param name="array"></param>
        static void PrintArray(ref int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Заменяет максимальный элемент массива на заданное значение
        /// </summary>
        /// <param name="array"></param>
        /// <param name="replacement"></param>
        static void ReplaceMax(ref int[] array, int replacement)
        {
            if (array == null || array.Length < 1)
            {
                return;
            }

            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (max == array[i])
                {
                    array[i] = replacement;
                }
            }
        }

        static void Main(string[] args)
        {
            // нажатая пользователем клавиша
            ConsoleKeyInfo keyToExit;
            do
            {
                int[] array;
                int replacement;
                ReadArray(out array);
                do
                {
                    Console.Write("Введите число для замены: ");

                } while (!int.TryParse(Console.ReadLine(), out replacement));
                ReplaceMax(ref array, replacement);
                PrintArray(ref array);
                Console.WriteLine(
                    "Нажмите Escape для выхода, или любую другую клавишу для ввода нового массива.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}