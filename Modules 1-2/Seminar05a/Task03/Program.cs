/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Пользователем с клавиатуры вводится целое число N > 0. 
    В программе сформировать и вывести на экран целочисленный массив из N элементов, 
    элементами которого являются нечетные числа от 1. Заполнение массива нечётными числами организовать при помощи метода.

    Дата:       2021.10.13
*/

using System;

namespace Task03
{
    class Program
    {

        /// <summary>
        /// заполняет массив нечётными числами
        /// </summary>
        /// <param name="array"></param>
        static void FillWithOdds(ref int[] array)
        {
            int length = array.Length;
            // число, которое будем записывать в массив
            int num = 1;
            for (int i = 0; i < length; i++)
            {
                array[i] = num;
                num += 2;
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
                FillWithOdds(ref array);
                PrintArray(ref array);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода нового числа.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}