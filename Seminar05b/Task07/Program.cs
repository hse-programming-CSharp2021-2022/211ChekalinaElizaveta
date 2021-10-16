/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     • Сформировать и заполнить случайными значениями массив A ссылок на целочисленные массивы.
    Количество ссылок в массиве A получить от пользователя. Количество элементов в каждом целочисленном массиве
    – случайное число из диапазона (0;15).
    Написать метод, формирующий по переданному в параметре массиву ссылок
    на целочисленные массивы новый массив, в котором сохранены только элементы, распложенные в нечетных столбцах
    исходного. Используя метод, сформировать из массива A «подмассив» B. A и  В вывести на экран.
    Дата:       2021.10.15
*/

using System;

namespace Task07
{
    class Program
    {
        /// <summary>
        /// Выделяет подмассив b, состоящий только из нечётных столбцов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void GetEvenCols(ref int[][] a, out int[][] b)
        {
            b = new int[a.Length][];
            for (int i = 0; i < a.Length; i++)
            {
                //массив будет состоять только из нечётных столбцов.
                int len = (a[i].Length + 1) / 2;
                b[i] = new int[len];
                //счётчик, пробегающий эл-ты нового массива
                int k = 0;
                //берём только нечётные столбцы.
                for (int j = 0; j < a[i].Length; j += 2)
                {
                    b[i][k] = a[i][j];
                    k++;
                }
            }
        }
        
        /// <summary>
        /// Выводит на экран матрицу (зубч. массив)
        /// </summary>
        /// <param name="array"></param>
        static void PrintMatrix(ref int[][] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + "\t");
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
        /// Заполняет зубч. массив случайными целыми числами в диапазоне от -100;100. 
        /// </summary>
        /// <param name="array"></param>
        static void FillWithRandom(ref int[][] array)
        {
            Random generator = new Random();
            
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
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
                //числ, вводимые в задаче.
                int m;
                ReadNumber("Введите размер матрицы", out m);
                //Создаём массив.
                array = new int[m][];
                Random generator = new Random();
                for (int i = 0; i < m; i++)
                {
                    array[i] = new int[generator.Next(1,15)];
                }
                //Заполняем массив.
                FillWithRandom(ref array);
                PrintMatrix(ref array);
                int[][] b;
                GetEvenCols(ref array, out b);
                PrintMatrix(ref array);
                PrintMatrix(ref b);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода нового числа.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}