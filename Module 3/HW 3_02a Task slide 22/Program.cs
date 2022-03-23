using System;

namespace CW_3_02a_Task_slide_22
{
    delegate void CoordChanged(Dot d);

    class Dot
    {
        private static Random rnd = new Random();
        public double X1;
        public double Y1;
        public event CoordChanged OnCoordChanged;

        public Dot(double x1, double y1)
        {
            this.X1 = x1;
            this.Y1 = y1;
        }

        public void DotFlow()
        {
            for (int i = 0; i < 10; i++)
            {
                this.X1 = rnd.NextDouble() * 20 - 10;
                this.Y1 = rnd.NextDouble() * 20 - 10;
                if (X1 < 0 && Y1 < 0)
                {
                    OnCoordChanged?.Invoke(this);
                }
            }

        }
    }



    class Program
    {
        protected static void PrintInfo(Dot A)
        {
            Console.WriteLine($"x: {A.X1:F2}, y: {A.Y1:F2}");
        }

        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            Dot D = new Dot(x1, y1);
            D.OnCoordChanged += PrintInfo;
            D.DotFlow();

        }
    }
}