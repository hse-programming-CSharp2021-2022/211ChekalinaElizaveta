using System;
using System.Runtime.CompilerServices;

namespace Seminara_Task02
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point() : this(0, 0)
        {
            X = 0;
            Y = 0;
        } // конструктор умолчания

        public double Ro
        {
            get { return Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2)); }
        }

        public double Fi
        {
            get
            {
                if (this.X > 0 && this.Y >= 0)
                {
                    return Math.Atan2(this.Y, this.X);
                }

                if (this.X > 0 && this.Y < 0)
                {
                    return Math.Atan2(this.Y, this.X);
                }

                if (this.X < 0)
                {
                    return Math.Atan2(this.Y, this.X) + Math.PI;
                }

                if (this.X == 0 && this.Y > 0)
                {
                    return Math.PI / 2;
                }

                if (this.X == 0 && this.Y < 0)
                {
                    return Math.PI * 3 / 2;
                }

                return 0.0;
            }
        }

        public string PointData
        {
            // СВОЙСТВО 
            get
            {
                string maket = "X = {0:F2}; Y = {1:F2}; Ro = {2:F2}; Fi = {3:F2} ";
                return string.Format(maket, X, Y, Ro, Fi);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Point a, b, c;
            a = new Point(3, 4);
            Console.WriteLine(a.PointData);
            b = new Point(0, 3);
            Console.WriteLine(b.PointData);
            c = new Point();
            double x = 0, y = 0;
            do
            {
                Console.Write("x = ");
                double.TryParse(Console.ReadLine(), out x);
                Console.Write("y = ");
                double.TryParse(Console.ReadLine(), out y);
                c.X = x;
                c.Y = y;
                if (a.Ro <= b.Ro && b.Ro <= c.Ro)
                {
                    Console.WriteLine(a.PointData);
                    Console.WriteLine(b.Ro <= c.Ro ? b.PointData : c.PointData);
                    Console.WriteLine(b.Ro <= c.Ro ? c.PointData : b.PointData);
                }
                else if (b.Ro <= a.Ro && b.Ro <= c.Ro)
                {
                    Console.WriteLine(b.PointData);
                    Console.WriteLine(a.Ro <= c.Ro ? a.PointData : c.PointData);
                    Console.WriteLine(a.Ro <= c.Ro ? c.PointData : a.PointData);
                }
                else
                {
                    Console.WriteLine(c.PointData);
                    Console.WriteLine(a.Ro <= b.Ro ? a.PointData : b.PointData);
                    Console.WriteLine(a.Ro <= b.Ro ? b.PointData : a.PointData);
                }
            } while (x != 0 | y != 0);
        }
    }
}