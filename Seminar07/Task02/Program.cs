/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     
        //    Ввести n, сгенировать массив чисел от 1 до 10000. 
        //    1) Запрос, который вернет двухначные числа кратные 3 
        //    2) Запрос, который вернет в порядке возрастания 
        //    все палиндромы (читается одинако) 
        //    3) Запрос, который отсортирует числа по сумме цифр, а затем по 
        //    значению числа 
        //    4) Запрос, который найдет сумму всех четырехзнчных чисел 
        //    5) Запрос, который найдет минимальное значение среди всех двузначных 
        //    чисел 
        //    6) запрос, который формирует коллекцию
    Дата:       2021.10.16
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Task03
{
    class Program
    {
        /// <summary>
        /// Считывает с клавиатуры одно целое число.
        /// </summary>
        /// <param name="num"></param>
        static void ReadNumber(out int num)
        {
            do
            {
                Console.Write("Введите число: ");
            } while (!int.TryParse(Console.ReadLine(), out num) || num < 0);
        }

        /// <summary>
        /// Заполняет матрицу случайными целыми числами в диапазоне от1 до 10000. 
        /// </summary>
        /// <param name="array"></param>
        static void FillWithRandom(in int len, out int[] array)
        {
            Random generator = new Random();
            array = new int[len];
            for (int j = 0; j < len; j++)
            {
                array[j] = generator.Next(1, 10001);
            }
        }

        static void PrintArray(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
        
        static int Sum(int a)
        {
            int sum = 0;
            while (a>0)
            {
                sum += a % 10;
                a = a / 10;

            }
            return sum;
        }

        /// <summary>
        /// Определяет, является ли число палиндромом
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        static bool IsPalindrom(in int k)
        {
            if (k < 10)
            {
                return true;
            }
            int a = k;
            int numDigits = 0;
            int accum = 1;
            while (a > 0)
            {
                a = a / 10;
                numDigits += 1;
                accum = accum * 10;
            }
            accum = accum / 10;
            a = k;
            for (int i = 0; i < numDigits/2; i++)
            {
                int lastDigit = a % 10;
                int firstDigit = (a / accum) % 10;
                if (lastDigit != firstDigit)
                {
                    return false;
                }

                a = a / 10;
                accum = accum / 100;
            }

            return true;
        }

        static void Main(string[] args)
        {
            // нажатая пользователем клавиша.
            ConsoleKeyInfo keyToExit;
            do
            {
                // массив.
                int[] array;
                //числа, вводимые в задаче.
                int n;
                ReadNumber(out n);
                FillWithRandom(in n, out array);
                PrintArray(ref array);
                Console.WriteLine("Запрос, который вернет двухначные числа кратные 3 ");
                //Запрос, который вернет двухначные числа кратные 3 
                var selected2 = (from t in array
                    where (t >= 10 && t < 100 && t % 3 == 0)
                    select t).ToArray();
                foreach (var i in selected2)
                    Console.Write(i + " ");
                Console.WriteLine();
                //2) Запрос, который вернет в порядке возрастания 
                //    все палиндромы (читается одинако) 
                Console.WriteLine("2) Запрос, который вернет в порядке возрастания все палиндромы");
                selected2 = (from t in array
                    where IsPalindrom(t) orderby t
                    select t).ToArray();
                foreach (var i in selected2)
                    Console.Write(i + " ");
                Console.WriteLine();
                //3) Запрос, который отсортирует числа по сумме цифр, а затем по 
                //    значению числа 
                Console.WriteLine("3) Запрос, который отсортирует числа по сумме цифр, а затем по значению числа ");
                var selected3 = array
                    .OrderBy(Sum)
                    .ThenBy(t => t);
                foreach (var i in selected3)
                    Console.Write(i + " ");
                Console.WriteLine();
                //    4) Запрос, который найдет сумму всех четырехзнчных чисел 
                Console.WriteLine("4) Запрос, который найдет сумму всех четырехзнчных чисел");
                int sum = array.Where(t => t >= 1000 && t<=9999).Sum();
                Console.WriteLine(sum);
                //5) Запрос, который найдет минимальное значение среди всех двузначных 
                //    чисел
                Console.WriteLine("5) Запрос, который найдет минимальное значение среди всех двузначных чисел");
                int min = array.Where(t => t >= 10 && t <= 99).Min();
                Console.WriteLine(min);
                //    6) запрос, который формирует коллекцию
                List<int> list = array.ToList();
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода новых чисел.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}