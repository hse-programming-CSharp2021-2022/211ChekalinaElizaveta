/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     • Сформировать целочисленную матрицу размером MxN (M и N задаются с клавиатуры) по следующему правилу:
    элементы i-ой строки равны 10*i.
    Сформировать и заполнить случайными значениями целочисленную матрицу размером MxN (M и N задаются с клавиатуры).
    Написать метод, выводящий на экран элементы переданной в качестве параметра матрицы в табличном виде через один
    в шахматном порядке. Способ вывода (начиная с первого в первой строке или со второго) задаётся параметром
    логического типа.
    Дата:       2021.10.15
*/

using System;

namespace Task06
{
    class Program
    {
        
        /// <summary>
        /// Выводит на экран матрицу (зубч. массив)
        /// </summary>
        /// <param name="array"></param>
        static void PrintMatrix(ref int[][] array)
        {
            int n = array.Length;
            int m = array[0].Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(array[i][j] + "\t");
                }
                Console.WriteLine();   
            }
        }

        /// <summary>
        /// Выводит на экран матрицу (зубч. массив) в шахм. порядке
        /// </summary>
        /// <param name="array"></param>
        /// <param name="flag"></param>
        static void PrintMatrixChess(ref int[][] array, bool flag)
        {
            int n = array.Length;
            int m = array[0].Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (flag && (i + j) % 2 == 0 || !flag && (i + j) % 2 != 0)
                    {
                        Console.Write(array[i][j] + "\t");                        
                    }
                    else
                    {
                        Console.Write(" \t");
                    }
                    
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

            } while (!int.TryParse(Console.ReadLine(), out num) || num <= 0);
        }

        /// <summary>
        /// Заполняет матрицу так, что элементы i-той строки равны 10*i
        /// </summary>
        /// <param name="array"></param>
        static void Fill(ref int[][] array)
        {
            int n = array.Length;
            int m = array[0].Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i][j] = 10*(i+1);

                }
            }
        }
        
        /// <summary>
        /// Заполняет матрицу случайными целыми числами в диапазоне от -100 до 100. 
        /// </summary>
        /// <param name="array"></param>
        static void FillWithRandom(ref int[][] array)
        {
            Random generator = new Random();
            
            int n = array.Length;
            int m = array[0].Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i][j] = generator.Next(-100,101);

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
                int[][] array;
                //числа, вводимые в задаче.
                int n, m;
                ReadNumber("Введите размер матрицы", out n);
                ReadNumber("Введите размер матрицы", out m);
                //Создаём массив.
                array = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    array[i] = new int[m];
                }
                //Заполняем массив.
                Fill(ref array);
                PrintMatrix(ref array);
                FillWithRandom(ref array);
                PrintMatrix(ref array);
                Console.WriteLine("Задание 2:");
                PrintMatrixChess(ref array, true);
                PrintMatrixChess(ref array, false);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода нового числа.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}