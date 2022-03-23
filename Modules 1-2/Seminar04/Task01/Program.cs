/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Написать программу, которая по двум целым неотрицательным числам A и B
    возвращает их наибольший общий делитель (НОД) и наименьшее общее кратное (НОК)
    Для вычисления НОД и НОК использовать один метод, откуда НОД и НОК вернуть,
    используя out-параметры

    Дата:        2021.10.12
*/

using System;

namespace Task01
{
    class Program
    {

        /// <summary>
        /// Вычисляет НОД и НОК двух целых неотр. чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="nod"></param>
        /// <param name="nok"></param>
        static void NodNok(uint a, uint b, out uint nod, out ulong nok)
        {
            //Временные переменные
            uint i, j;
            i = a;
            j = b;
            // более быстрый алг. Евклида - с остатками
            while (i != j && i != 0 && j != 0)
            {
                if (j > i)
                {
                    j %= i;
                }
                else
                {
                    i %= j;
                }
            }
            nod = j > i ? j : i;
            nok = a / nod * b;
        }
        static void Main(string[] args)
        {
            // нажатая пользователем клавиша
            ConsoleKeyInfo keyToExit;
            do
            {
                // числа; их НОД и НОК
                uint a, b, nod;
                //НОК - unsigned long потому, что НОК всегда >= max(a, b). Хотя a, b <= uint.MaxValue, НОК может быть больше
                ulong nok;
                do
                {
                    Console.Write("Введите первое число: ");
                } while (!uint.TryParse(Console.ReadLine(), out a));
                do
                {
                    Console.Write("Введите второе число: ");
                } while (!uint.TryParse(Console.ReadLine(), out b));
                
                NodNok(a, b, out nod, out nok);
                Console.WriteLine("НОД: {0}, НОК:{1}", nod, nok);
                    
                Console.WriteLine("Для выхода нажмите Escape....");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}