/*
    Дисциплина: "Программирование"
    Группа:     БПИ2111
    Студент:    Чекалина Елизавета Алексеевна
    Задача:     В основной программе ввести натуральное число и вычислить суммы его цифр,
    находящихся в чётных и на нечётных разрядах. Разряд единиц считать нулевым и чётным.
    Для этого написать метод с натуральным параметром, вычисляющий суммы цифр, находящихся
    на четных и на нечетных позициях в записи значения параметра.  
    Заголовок метода: 
    void Sums(uint number, out uint sumEven, out uint sumOdd)
    Основная программа, используя метод, «общается» с пользователем.
    Дата:        2021.10.12
*/

// Задача была бы интереснее, начинай мы считать с начала числа. Тогда я бы тоже использовала переменную,
// в которой хранила бы текущую чётность. Если, когда число закончилось, она совпадает с начальной,
// то в числе нечётное кол-во цифр, и моя "нечётная" сумма действительно такова, иначе их нужно поменять местами с чётной.
using System;

namespace Task03
{
    class Program
    {
        /// <summary>
        /// Считает сумму цифр на чётных и нечётных позициях в числе; счёт начинается с разряда единиц.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="sumEven"></param>
        /// <param name="sumOdd"></param>
        static void Sums(uint number, out uint sumEven, out uint sumOdd)
        {
            // переменная для чётности
            bool isEven = true;
            sumEven = 0;
            sumOdd = 0;
            while (number > 0)
            {
                if (isEven)
                {
                    sumEven += number % 10;
                }
                else
                {
                    sumOdd += number % 10;
                }
                isEven = !isEven;
                number /= 10;
            }
        }
        static void Main(string[] args)
        {
            // нажатая пользователем клавиша
            ConsoleKeyInfo keyToExit;
            // текущая переменная для числа, сумма цифр на нечётных позициях, сумма цифр на чётных позициях
            uint current, sumOdd, sumEven;
            do
            {
                do
                {
                    Console.Write("Введите число. ");
                } while (!uint.TryParse(Console.ReadLine(), out current));
                Sums(current, out sumEven, out sumOdd);
                Console.WriteLine("Сумма на чётных позициях: {0};\nСумма на нечётных позициях:{1}", sumEven, sumOdd);
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для ввода нового числа.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}