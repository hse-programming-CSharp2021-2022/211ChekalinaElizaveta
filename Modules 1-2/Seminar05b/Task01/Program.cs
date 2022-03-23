/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Сформировать и заполнить случайными значениями целочисленную матрицу 
    размером MxN (M и N задаются с клавиатуры). На экран вывести сумму и произведение 
    элементов k-ой строки (k – задается с клавиатуры).
    Дата:       2021.10.13
*/

using System;

namespace Task01
{
    class Program
    {
        
        /// <summary>
        /// Выводит на экран целочисленную матрицу через пробел
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

            } while (!int.TryParse(Console.ReadLine(), out num));
        }

        /// <summary>
        /// Вычисляет сумму и произведение элементов k-той строки прямоугольноц целочисл. матрицы.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="k"></param>
        /// <param name="sum"></param>
        /// <param name="mult"></param>
        static void SumMultLine(ref int[,] array, in int k, out long sum, out long mult)
        {
            sum = 0;
            mult = 1;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                sum += array[k, i];
                mult = mult *array[k, i];
            }
        }

        /// <summary>
        /// Заполняет матрицу случайными целыми числами. 
        /// </summary>
        /// <param name="array"></param>
        static void FillWithRandom(ref int[,] array)
        {
            Random generator = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    //Примечание. Я сделала диапазон от -1000 до 1000, иначе числа слишком большие, неудобно.
                    //Но в методах учтено то, что числа могут быть и больше.
                    array[i, j] = generator.Next(-1000, 1001);
                    
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
                //числа, вводимые в задаче.
                int m, n, k;
                // сумма и произведение.
                long sum, mult;
                ReadNumber(out m);
                ReadNumber(out n);
                ReadNumber(out k);
                //нумерация в строках массива - не такая, как в реальной матрице.
                k--;
                array = new int[m, n];
                FillWithRandom(ref array);
                PrintMatrix(ref array);
                SumMultLine(ref array, k, out sum, out mult);
                Console.WriteLine("Сумма: {0}, произведение:{1}", sum, mult);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода новых чисел.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}