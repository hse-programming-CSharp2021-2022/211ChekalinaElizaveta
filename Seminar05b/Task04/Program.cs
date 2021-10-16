/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Работа с элементами массивов массивов и многомерных массивов
    Получить от пользователя целые числа n > 1 и m > 1. 
    Сформировать двумерный массив размера nxm и заполнить его случайными числами из диапазона [-100;100). 
    Выполнить следующие преобразования:
    • Заменить максимальный по модулю элемент каждой строки на противоположный по знаку;
    • Вставить после каждой строки с чётным индексом нулевую строку;
    • Удалить все строки, содержащие хотя бы одно нулевое значение;
    • Поменять местами средние столбцы.
    Дата:       2021.10.14
*/

using System;

namespace Task03
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
        static void ReadNumber(out int num)
        {
            do
            {
                Console.Write("Введите число: ");

            } while (!int.TryParse(Console.ReadLine(), out num) || num <= 1);
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

        /// <summary>
        /// Заменяет максимальный элемент массива на противоположный
        /// Для зубчатого массива: применить этот метод ко всем строкам в цикле.
        /// </summary>
        /// <param name="array"></param>
        static void ReplaceMax(ref int[] array)
        {
            if (array == null || array.Length < 1)
            {
                return;
            }

            // ищем макс. эл-т
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
            }
            
            // заменяем.
            for (int i = 0; i < array.Length; i++)
            {
                if (max == array[i])
                {
                    array[i] = -max;
                }
            }
        }

        /// <summary>
        /// Заменяет макс. эл-т в каждой строке на противоположный.
        /// </summary>
        /// <param name="array"></param>
        static void ReplaceMaxMatrix(ref int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                // ищем макс. эл-т
                int max = array[i, 0];
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    if (max < array[i, j])
                    {
                        max = array[i, j];
                    }
                }
            
                // заменяем.
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (max == array[i, j])
                    {
                        array[i, j] = -max;
                    }
                }
            }
        }

        static void InsertAfterEven(in int[,] array, out int[,] newArray)
        {
            int n = array.GetLength(1);
            int m = array.GetLength(0);
            int l = (m + m / 2 + m % 2);
            newArray = new int[l, n];
            int k = 0;
          for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    newArray[k, j] = array[i, j];
                }

                if (i % 2 == 0)
                {
                    k = k + 2;
                }
                else
                {
                    k++;

                }
            }
        }
        static void PrintArray(ref bool[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void DeleteLines(in int[,] array, out int[,] newArray)
        {
            //Решение для зубчатого тривиально - достаточно удалять строку методами массива.
            int numLines = array.GetLength(0);
            bool[] delete = new bool[numLines];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                delete[i] = false;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 0)
                    {
                        delete[i] = true;
                        numLines--;
                        break;
                    }
                }
            }
            
            newArray = new int[numLines, array.GetLength(1)];
            int k = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (!delete[i])
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        newArray[k, j] = array[i, j];
                       
                    } 
                    k++;
                }
                
            }
        }

        static void SwapMiddleColumns(ref int[,] array)
        {
            //если кол-во столбцов нечётно, то и делать нечего
            //решение очень легко адаптируется под зубч. массивы - достаточно по-другому написать индексацию
            // и определение длины.
            if (array.GetLength(1) % 2 == 1) return;

            int numCols = array.GetLength(1);
            int right = numCols / 2 ;
            int left = right - 1;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int t = array[i, right];
                array[i, right] = array[i, left];
                array[i, left] = t;
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
                //числа, вводимые в задаче.
                int m, n;
                ReadNumber(out n);
                ReadNumber(out m);
                array = new int[n, m];
                FillWithRandom(ref array);
                PrintMatrix(ref array);
                Console.WriteLine("Заменим макс:");
                ReplaceMaxMatrix(ref array);
                PrintMatrix(ref array);
                Console.WriteLine("Вставим пустые строки");
                int[,] array2;
                InsertAfterEven(in array, out array2);
                PrintMatrix(ref array2);
                Console.WriteLine("Удалим строчки с 0");
                DeleteLines(in array2, out array);
                PrintMatrix(ref array);
                Console.WriteLine("Обменяем столбцы");
                SwapMiddleColumns(ref array);
                PrintMatrix(ref array);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода новых чисел.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}