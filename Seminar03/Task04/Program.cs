/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     (***) Трехзначным целым числом кодируется номер аудитории в учебном корпусе. 
    Старшая цифра обозначают номер этажа, а две младшие –  номер аудитории на этаже. 
    Из трех аудиторий определить и вывести на экран ту аудиторию, которая имеет минимальный номер внутри этажа. 
    Если таких аудиторий несколько - вывести любую из них. 
    Дата:        2021.10.12
*/

using System;

namespace Task07
{
    class Program
    {
        /// <summary>
        /// Вычисляет максимальное из трёх чисел.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="min"></param>
        static void MinOfThree(int a, int b, int c, out int min)
        {
            int temp1, temp2;
            Remainder(a, out temp1);
            Remainder(b, out temp2);
            if (temp1 > temp2)
            {
                a = b;
                temp1 = temp2;
            }

            Remainder(c, out temp2);
            if (temp1 > temp2)
            {
                a = c;
            }

            min = a;

        }

        /// <summary>
        /// Вычисляет номер аудитории
        /// </summary>
        /// <param name="number"></param>
        /// <param name="roomNumber"></param>
        static void Remainder(int number, out int roomNumber)
        {
            roomNumber = number % 100;
        }
        
        static void Main(string[] args)
        {
            // нажатая пользователем клавиша
            ConsoleKeyInfo keyToExit; 
            // номера аудиторий и ответ
            int a, b, c, ans;

            do
            {
                do
                {
                    Console.Write("Введите номер аудитории - трёхзначное число: ");
                } while (!int.TryParse(Console.ReadLine(), out a) || a < 100 || a > 999 || a % 100 == 0);
                do
                {
                    Console.Write("Введите номер аудитории - трёхзначное число: ");
                } while (!int.TryParse(Console.ReadLine(), out b) || b < 100 || b > 999 || b % 100 == 0);
                do
                {
                    Console.Write("Введите номер аудитории - трёхзначное число: ");
                } while (!int.TryParse(Console.ReadLine(), out c) || c < 100 || c > 999 || c % 100 == 0);
                
                MinOfThree(a, b, c,out ans);
                Console.WriteLine("Минимальная аудитория: {0}", ans);
                
                Console.WriteLine("Для выхода нажмите Escape....");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}