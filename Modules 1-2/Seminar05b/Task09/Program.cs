/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:    • Сформировать массив ссылок на вещественные массивы D,
    число элементов получить от пользователя. Количество элементов в каждом вещественном массиве равно индексу в D,
    увеличенному на единицу. Элементы вещественных массивов - случайные значениями из диапазона (0;1).
    • Написать метод, преобразующий массив ссылок на вещественные массивы в двумерный вещественный массив.
    Недостающие элементы обнулить.
    • Обработать массив D при помощи этого метода, экран вывести D, результат преобразования и суммы элементов
    для каждого столбца. Точность вывода: два знака после запятой.
    Дата:       2021.10.15
*/

using System;

namespace Task08
{
    class Program
    {

        /// <summary>
        /// Вычисляет сумму эл-тов заданного столбца массива прямоуг. формы
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <param name="sum"></param>
        static void SumColumn(ref double[,] arr, in int k, out double sum)
        {
            sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                sum += arr[i, k];
            }
        }

        /// <summary>
        /// Вычисляет сумму эл-тов каждого столбца прямоуг. массива.
        /// </summary>
        /// <param name="arr"></param>
        static void PrintColSums(ref double[,] arr)
        {
            Console.WriteLine("Суммы столбцов:");
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                double sum;
                SumColumn(ref arr, i, out sum);
                Console.Write($"{sum:F2} ");
            }
        }
        /// <summary>
        /// Переводит массив массивов в прямоугольный массив 
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        static void MakeRectangular(in double[][] arr1, out double[,] arr2)
        {
            arr2 = new double[arr1.Length, arr1.Length];
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1[i].Length; j++)
                {
                    arr2[i, j] = arr1[i][j];
                }
            }
        }
        
        /// <summary>
        /// Выводит на экран матрицу.
        /// </summary>
        /// <param name="array"></param>
        static void PrintMatrix(ref double[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write("{0:F2} ", array[i][j]);
                }
                Console.WriteLine();   
            }
        }
        
        /// <summary>
        /// Выводит на экран матрицу (двум. массив).
        /// </summary>
        /// <param name="array"></param>
        static void PrintMatrix(ref double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]:F2} ");
                }
                Console.WriteLine();   
            }
        }
        
        /// <summary>
        /// Считывает с клавиатуры одно целое число.
        /// </summary>
        /// <param name="num"></param>
        static void ReadNumber(string prompt, out int num)
        {
            do
            {
                Console.Write(prompt + ": ");

            } while (!int.TryParse(Console.ReadLine(), out num) || num < 1);
        }

        /// <summary>
        /// Заполняет матрицу случайными целыми числами в диапазоне от -100 до 100. 
        /// </summary>
        /// <param name="array"></param>
        static void FillWithRandom(ref double[][] array)
        {
            Random generator = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = generator.NextDouble();

                }
            }
        }
        static void Main(string[] args)
        {
            // нажатая пользователем клавиша.
            ConsoleKeyInfo keyToExit;
            do
            {
                // массив массивов вещ. чисел.
                double[][] array;
                //числа, вводимое в задаче.
                int a;
                ReadNumber("Введите число эл-тов в зубч. массиве", out a);
                //инициализируем массив
                array = new double[a][];
                for (int i = 0; i < a; i++)
                {
                    array[i] = new double[i+1];
                }
                FillWithRandom(ref array);
                Console.WriteLine("Массив, заполненный случайными числами:");
                PrintMatrix(ref array);
                double[,] arr2;
                Console.WriteLine("Этот же массив в виде прямоугольного:");
                MakeRectangular(in array, out arr2);
                PrintMatrix(ref arr2);
                PrintColSums(ref arr2);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода нового числа.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}