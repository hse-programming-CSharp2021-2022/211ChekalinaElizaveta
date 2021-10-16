/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Написать метод, формирующий по целочисленной матрице MxN 
    (M и N задаются с клавиатуры) одномерный массив индексов A. 
    В А хранятся индексы столбцов матрицы в отсортированном виде, 
    в порядке возрастания сумм элементов столбцов. В основной программе 
    сформировать матрицу, получить индексный массив, использовать его для 
    вывода столбцов матрицы в порядке возрастания сумм их элементов.
    Дата:       2021.10.14
*/

using System;

namespace Task03
{
    class Program
    {
        
        /// <summary>
        /// Выводит на экран матрицу через пробел
        /// </summary>
        /// <param name="array"></param>
        static void PrintMatrix(ref int[,] array)
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
        /// Выводит на экран матрицу через пробел, столбцы упорядочены.
        /// </summary>
        /// <param name="array"></param>
        static void PrintMatrixInOrder(ref int[,] array, ref int[] order)
        {
            for (int i = 0; i <  array.GetLength(0); i++)
            {
                for (int j = 0; j < order.Length; j++)
                {
                    Console.Write(array[i, order[j]] + " ");
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
        /// Вычисляет сумму элементов столбцов матрицы, формирует массив сумм
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="a"></param>
        static void GetSumElems(ref int[,] arr, out int[] b)
        {
            // Массив сумм по столбцам.
           int[] a = new int[arr.GetLength(1)];
            // Теперь создадим индексный массив.
            b = new int[a.Length];
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                int sum = 0;
                for (int i=0;i<arr.GetLength(0); i++)
                {
                    sum += arr[i, j];
                }
                //Console.WriteLine("Сумма {0} столбца: {1}", j+1, sum);
                a[j] = sum;
                b[j] = j;

            }
            // Сортируем индексный массив
            for (int j = 0; j < a.Length; j++)
            {
                for (int i=j+1; i < a.Length; i++)
                {
                    if (a[j] > a[i])
                    {
                        int t = a[j];
                        a[j] = a[i];
                        a[i] = t;
                        t = b[j];
                        b[j] = b[i];
                        b[i] = t;
                    }
                }
            }
        }
        /// <summary>
        /// Заполняет матрицу случайными целыми числами в диапазоне от -100 до 100. 
        /// </summary>
        /// <param name="array"></param>
        static void FillWithRandom(ref int[,] array)
        {
            Random generator = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = generator.Next(-10,10);

                }
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
            // нажатая пользователем клавиша.
            ConsoleKeyInfo keyToExit;
            do
            {
                // матрица.
                int[,] array;
                //индексный массив.
                int[] b;
                //числа, вводимые в задаче.
                int m, n;
                ReadNumber(out m);
                ReadNumber(out n);
                array = new int[m, n];
                FillWithRandom(ref array);
                PrintMatrix(ref array);
                GetSumElems(ref  array, out b);
                Console.WriteLine("Индексный массив:");
                PrintArray(ref b);
                PrintMatrixInOrder(ref array, ref b);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода новых чисел.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}