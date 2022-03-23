/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Сформировать и заполнить случайными значениями вещественную матрицу
    размером MxN (M и N задаются с клавиатуры). 
    На экран вывести сумму элементов для каждого столбца.
    Дата:       2021.10.13
*/

using System;

namespace Task01
{
    class Program
    {
        
        /// <summary>
        /// Выводит на экран матрицу через пробел
        /// </summary>
        /// <param name="array"></param>
        static void PrintMatrix(ref double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();   
            }
        }

        /// <summary>
        /// Считывает с клавиатуры одно целое число.
        /// </summary>
        /// <param name="num"></param>
        static void ReadNumber(out int num)
        {
            do
            {
                Console.Write("Введите число: ");

            } while (!int.TryParse(Console.ReadLine(), out num));
        }

        /// <summary>
        /// Вычисляет сумму элементов столбцов матрицы
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        static void SumElemsI(ref double[,] arr)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                double sum = 0;
                for (int i=0;i<arr.GetLength(0); i++)
                {
                    sum += arr[i, j];
                }
                Console.WriteLine("Сумма {0} столбца: {1}", j+1, sum);
            }
        }
        /// <summary>
        /// Заполняет матрицу случайными вещ. числами. 
        /// </summary>
        /// <param name="array"></param>
        static void FillWithRandom(ref double[,] array)
        {
            Random generator = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = generator.NextDouble();

                }
            }
        }

        static void Main(string[] args)
        {
            // нажатая пользователем клавиша.
            ConsoleKeyInfo keyToExit;
            do
            {
                // матрица.
                double[,] array;
                //числа, вводимые в задаче.
                int m, n;
                ReadNumber(out m);
                ReadNumber(out n);
                array = new double[m, n];
                FillWithRandom(ref array);
                PrintMatrix(ref array);
                SumElemsI(ref array);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода новых чисел.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}