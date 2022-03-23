/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Пользователем с клавиатуры вводится целое число N > 1. 
    В программе сформировать целочисленный массив, содержащий N первых элементов последовательности Фибоначчи:
    A[0] = 1, A[1] = 1, A[2] = A[0] + A[1], … A[K] = A[K-1] + A[K-2], … Формирование массива организовать при помощи метода.
    Элементы массива вывести на экран в обратном порядке, методы класса Array не использовать. 
    Дата:       2021.10.13
*/

using System;

namespace Task03
{
    class Program
    {

        /// <summary>
        /// формирует массив из n эл-тов последовательности фибоначчи
        /// </summary>
        /// <param name="n"></param>
        /// <param name="arr"></param>
        static void Fib(int n, out int[] arr)
        {
            // для неподходящих эн вернём пустой массив
            if (n < 2)
            {
                arr = Array.Empty<int>();
                return;
            }

            arr = new int[n];
            arr[0] = 1;
            arr[1] = 1;
            for (int i = 2; i < n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }

        }

        /// <summary>
        /// Выводит на экран массив целых чисел через пробел в обратном порядке
        /// </summary>
        /// <param name="array"></param>
        static void PrintArrayReversed(ref int[] array)
        {
            for (int i = array.Length-1; i >=0; i--)
            {
                Console.Write(array[i]+ " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Считывает с клавиатуры одно целое число > 1
        /// </summary>
        /// <param name="num"></param>
        static void ReadNumber(out int num)
        {
            do
            {
                Console.Write("Введите число:");

            } while (!int.TryParse(Console.ReadLine(), out num) || num < 2);
        }

        
        static void Main(string[] args)
        {
            // нажатая пользователем клавиша
            ConsoleKeyInfo keyToExit;
            do
            {
                int[] array;
                
                int n;
                // считываем эн
                ReadNumber(out n);
                // заполняем массив - "формируется в методе" предполагает создание тоже, да?
                Fib(n, out array);
                // вывод в обратном порядке без методов класса Array.
                PrintArrayReversed(ref array);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода нового числа.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}