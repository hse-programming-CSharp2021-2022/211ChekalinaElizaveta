/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Пользователем с клавиатуры вводится целое число N > 0.
    В программе сформировать и вывести на экран целочисленный массив из N элементов.
    Значениями элементов являются степени числа 2 от нулевой до N-1 (1, 2, … 2N-1).
    Заполнение массива степенями числа 2 организовать при помощи метода.

    Дата:       2021.10.13
*/

using System;

namespace Task02
{
    class Program
    {

        /// <summary>
        /// заполняет массив степенями двойки
        /// </summary>
        /// <param name="array"></param>
        static void PowerTwo(ref int[] array)
        {
            int length = array.Length;
            // число, которое будем записывать в массив
            int num = 1;
            for (int i = 0; i < length; i++)
            {
                array[i] = num;
                // быстрое возведение в степень
                num = num << 1;
            }
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

        
        static void Main(string[] args)
        {
            // нажатая пользователем клавиша
            ConsoleKeyInfo keyToExit;
            do
            {
                int[] array;
                int n;
                do
                {
                    Console.Write("Введите длину массива ");

                } while (!int.TryParse(Console.ReadLine(), out n) || n < 1);

                array = new int[n];
                PowerTwo(ref array);
                PrintArray(ref array);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода нового числа.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}