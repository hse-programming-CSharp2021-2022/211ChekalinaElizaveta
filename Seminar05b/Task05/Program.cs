/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     В программе создать матрицу размеров NxN (1 < N < 20 – вводится с клавиатуры пользователем.
     Заполнить матрицу числами от 1 до N2, в направлениях, указанных стрелками на рисунках ниже.
     Полученные матрицы вывести на экран.
    Дата:       2021.10.15
*/

using System;

namespace Task05
{
    class Program
    {
        
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

            } while (!int.TryParse(Console.ReadLine(), out num) || num <= 1 || num >= 20);
        }

        /// <summary>
        /// Заполняет матрицу по первому паттерну.
        /// </summary>
        /// <param name="array"></param>
        static void Fill1(ref int[,] array)
        {
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j % 2 == 0)
                    {
                        array[i, j] = j * m + i + 1;
                    }
                    else
                    {
                        array[i, j] =  (j + 1) * m - i;
                    }
                     
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
                //число, вводимое в задаче.
                int n;
                ReadNumber("Введите размер матрицы", out n);
                array = new int[n, n];
                Fill1(ref array);
                PrintMatrix(ref array);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода нового числа.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}