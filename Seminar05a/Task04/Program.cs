/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Пользователем с клавиатуры вводятся целые числа N > 1, A и D.
    В программе сформировать и вывести на экран целочисленный массив из N элементов.
    Элементы вычисляются: A[0] = A, A[1] = A + D, A[2] = A + 2*D, … A[N-1] = A + (N-1)*D.
    Формирование массива организовать при помощи метода.
    Дата:       2021.10.13
*/

using System;

namespace Task03
{
    class Program
    {

        /// <summary>
        /// заполняет массив. Элементы вычисляются: A[0] = A, A[1] = A + D, A[2] = A + 2*D, … A[N-1] = A + (N-1)*D.
        /// </summary>
        /// <param name="array"></param>
        static void ArithProg(ref int[] array, int a, int d)
        {
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                array[i] = a + i*d;
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

        /// <summary>
        /// Считывает с клавиатуры одно целое число.
        /// </summary>
        /// <param name="num"></param>
        static void ReadNumber(out int num)
        {
            do
            {
                Console.Write("Введите число:");

            } while (!int.TryParse(Console.ReadLine(), out num));
        }

        
        static void Main(string[] args)
        {
            // нажатая пользователем клавиша
            ConsoleKeyInfo keyToExit;
            do
            {
                int[] array;
                //числа, вводимые в задаче
                int n, a, d;
                do
                {
                    Console.Write("Введите длину массива ");

                } while (!int.TryParse(Console.ReadLine(), out n) || n < 1);
                Console.WriteLine("Введите a:");
                ReadNumber(out a);
                Console.WriteLine("Введите d:");
                ReadNumber(out d);
                array = new int[n];
                ArithProg(ref array, a, d);
                PrintArray(ref array);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода нового числа.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}