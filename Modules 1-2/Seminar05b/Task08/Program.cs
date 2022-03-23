/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     • Сформировать двумерный целочисленный массив размером MxN, заполнить его случайными значениями 
    (M и N задаются с клавиатуры). 
    •Преобразовать этот двумерный массив в массив массивов. 
    •Dычислить и вывести на экран сумму и произведение элементов k-ого столбца массива массивов (k – задается с клавиатуры).
    Дата:       2021.10.15
*/

using System;

namespace Task08
{
    class Program
    {

        /// <summary>
        /// Вычисляет сумму и произв. эл-тов заданного столбца зубчатого массива прямоуг. формы
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <param name="sum"></param>
        /// <param name="mult"></param>
        static void SumMult(ref int[][] arr, in int k, out int sum, out int mult)
        {
            sum = 0;
            mult = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i][k];
                mult *= arr[i][k];
            }
        }

        /// <summary>
        /// Переводит прямоугольный массив в массив массивов
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        static void MakeJagged(in int[,] arr1, out int[][] arr2)
        {
            arr2 = new int[arr1.GetLength(0)][];
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                arr2[i] = new int[arr1.GetLength(1)];
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    arr2[i][j] = arr1[i, j];

                }
            }
        }
        
        /// <summary>
        /// Выводит на экран матрицу.
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
        static void FillWithRandom(ref int[,] array)
        {
            Random generator = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = generator.Next(-100,101);

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
                int[,] array;
                // зубч. массив;
                int[][] arr2;
                //числа, вводимое в задаче.
                int n,m,k;
                ReadNumber("Введите размер матрицы", out n);
                ReadNumber("Введите размер матрицы", out m);
                ReadNumber("Введите номер столбца", out k);
                array = new int[m, n];
                FillWithRandom(ref array);
                PrintMatrix(ref array);
                MakeJagged(in array, out arr2);
                int sum, mult;
                SumMult(ref arr2, k-1, out sum, out mult);
                Console.WriteLine($"Сумма: {sum}, произведение: {mult}");
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода нового числа.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}