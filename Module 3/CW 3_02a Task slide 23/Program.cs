using System;

namespace CW_3_02a_Task_slide_23
{ 
    delegate void SquareSizeChanged(double d);
    class Square
    {
        
        private double x1;
        private double x2;
        private double y1;
        private double y2;
        public event SquareSizeChanged OnSizeChanged;

        public Square(double x1, double x2, double y1, double y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }


        public double X1
        {
            get => x1;
            set
            {
                x1 = value;
                OnSizeChanged(Math.Abs(x2 - x1));
            }
        }

        public double X2
        {
            get => x2;
            set
            {
                x2 = value;
                OnSizeChanged(Math.Abs(x2 - x1));
            }
        }

        public double Y1
        {
            get => y1;
            set
            {
                y1 = value;
                OnSizeChanged(Math.Abs(y2 - y1));
            }
        }

        public double Y2
        {
            get => y2;
            set
            {
                y2 = value;
                OnSizeChanged(Math.Abs(y2 - y1));
            }
        }
    }

    class Program
    {
        public static void SquareConsoleInfo(double A)
        {
            Console.WriteLine($"{A:F2}");
        }

        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            Square S = new Square(x1, x2, y1, y2);
            S.OnSizeChanged += SquareConsoleInfo;
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            while (Math.Abs(x3)>0.001 && Math.Abs(y3) > 0.001)
            {
                S.X2 = x3;
                S.Y2 = y3;
                x3 = double.Parse(Console.ReadLine());
                y3 = double.Parse(Console.ReadLine());
            }

        }
    }
}