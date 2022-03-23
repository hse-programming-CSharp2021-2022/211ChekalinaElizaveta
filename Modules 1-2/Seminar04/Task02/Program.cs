/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     Пользователь последовательно вводит целые числа.
    Для хранения полученных чисел в программе используется одна переменная.
    Окончание ввода чисел определяется либо желанием пользователя,
    либо когда сумма уже введённых отрицательных чисел становится меньше -1000.
    Определить и вывести на экран среднее арифметическое отрицательных чисел.
    Дата:        2021.10.12
*/

using System;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            // нажатая пользователем клавиша
            ConsoleKeyInfo keyToExit;
            // текущая переменная для числа, сумма отрицательных чисел, общая сумма, кол-во чисел.
            int current, negativeSum, kolVo;
            negativeSum = 0;
            kolVo = 0;
            do
            {
                do
                {
                    Console.Write("Введите число. ");
                } while (!int.TryParse(Console.ReadLine(), out current));
                // Замечу, что моё решение задачи не позволяет ввести пустую последовательность
                // если бы можно было её ввести, я делала бы проверку на KolVo != 0.
                negativeSum = (current < 0 ? negativeSum + current : negativeSum);
                kolVo = (current < 0 ? kolVo + 1 : kolVo);
                if (negativeSum < -1000) break;
                Console.WriteLine("Если желаете завершить ввод, нажмите Escape, иначе любую другую клавишу");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
            Console.WriteLine("Среднее арифметическое: {0}", (double)negativeSum/(double)kolVo);
        }
    }
}