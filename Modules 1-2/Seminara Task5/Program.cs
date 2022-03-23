using System;
using System.Xml;

namespace Seminara_Task5
{
    public class ConsolePlate
    {
        private char _plateChar; // символ
        private ConsoleColor _plateColor = ConsoleColor.White; // цвет символа
        private ConsoleColor _plateBGColor = ConsoleColor.Black; // цвет фона символа
        // конструкторы
        public ConsolePlate()  
        {
            _plateChar = '+';
        }
        public ConsolePlate(char plateChar, ConsoleColor plateColor, ConsoleColor plateBgColor)
        {
            if ('A' <= plateChar && plateChar <= 'Z')
            {
                this.PlateChar = plateChar; // используем свойства   
            }
            else
            {
                this.PlateChar = 'A';
            }
            this.PlateColor = plateColor;
            this.PlateBgColor = plateBgColor;
        }
        
        public char PlateChar
        {
            set
            {
                if (value > 31 &&  'A' <= value && value <= 'Z') // отбрасываем командные символы
                    _plateChar = value;
                else
                    _plateChar = '+';
            }
            get { return _plateChar; }
        }
        public ConsoleColor PlateColor
        {
            set { if (this.PlateBgColor != value) this._plateColor = value; }
            get { return this._plateColor; }
        }

        public ConsoleColor PlateBgColor
        {
            set { if (this._plateColor != value) this._plateBGColor = value; }
            get { return this._plateBGColor; }
        }

        public void Write()
        {
            ConsoleColor currBG = Console.BackgroundColor;
            ConsoleColor currFG = Console.ForegroundColor;
            Console.BackgroundColor = this.PlateBgColor;
            Console.ForegroundColor = this.PlateColor;
            Console.Write(this.PlateChar);
            Console.BackgroundColor = currBG;
            Console.ForegroundColor = currFG;
        }

        public override string ToString()
        {
            return this._plateChar.ToString() + " " + this._plateColor.ToString() + " " + this._plateBGColor.ToString();
        }
    }
    class Program
    {
        static void Main( )
        {
            ConsolePlate cp = new ConsolePlate();
            /*ConsolePlate[] somePlates = 
            { 	   new ConsolePlate('*', ConsoleColor.Red), 
                cp, 
                new ConsolePlate((char)12, ConsoleColor.Green) 
            };
            foreach(ConsolePlate conPl in somePlates)
            {
                Console.ForegroundColor = conPl.PlateColor;
                Console.Write(conPl.PlateChar);
            }*/
            ConsolePlate first = new ConsolePlate('X', ConsoleColor.White, ConsoleColor.Red);
            ConsolePlate second = new ConsolePlate('O', ConsoleColor.White, ConsoleColor.Magenta);
            Console.WriteLine(first);
            Console.WriteLine(second);
            int n;
            do
            {
                do
                {
                    Console.WriteLine("Введите размер таблицы:");
                    int.TryParse(Console.ReadLine(), out n);
                } while (n != 0 && (n < 2 || n > 35));
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if ((i + j) % 2 == 0)
                        {
                            first.Write();
                        }
                        else
                        {
                            second.Write();
                        }
                    }
                    Console.WriteLine();
                }
            } while (n != 0);
        }
    }
}