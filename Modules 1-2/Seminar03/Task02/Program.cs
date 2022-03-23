/*
   Дисциплина: "Программирование"
   Группа:     БПИ2111
   Студент:    Чекалина Елизавета Алексеевна
   Задача:     Написать метод, преобразующий число переданное в качестве параметра в число,
   записанное теми же цифрами, но идущими в обратном порядке. 
   Например, 1024 - > 4201, 120 -> 21
    
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
            // число, результат
            int i, res;
            do
            {
                res = 0;
                do
                {
                    Console.Write("Введите число: ");
                } while (!int.TryParse(Console.ReadLine(), out i) || i < 0);

                while (i > 0)
                {
                    res = res * 10 + i % 10;
                    i /= 10;
                }
                Console.WriteLine(res);
                Console.WriteLine("Для выхода нажмите Escape....");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}