using System;
using System.Collections.Generic;

namespace HW_28._01
{
    class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double Distance(Point p)
        {
            return Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));
        }

        public override string ToString()
        {
            return $"Point. X: {this.X}, Y: {this.Y}";
        }
    }

    class Circle : IComparable
    {
        public Point center;
        public double Rad { get; private set; }

        public Circle(double x, double y, double radius)
        {
            this.center = new Point(x, y);
            this.Rad = radius;
        }

        public override string ToString()
        {
            return $"Circle. Radius: {Rad}, Center: {center}";  
        } 

        public int CompareTo(object? a)
        {
            if (a != null)
            {
                var x1 = this;
                var x2 = a as Circle;
                if (x1.Rad * x1.center.Distance(new Point(0, 0)) > x2.Rad * x2.center.Distance(new Point(0, 0)))
                    return 1;
                if (x1.Rad * x1.center.Distance(new Point(0, 0)) - x2.Rad * x2.center.Distance(new Point(0, 0)) ==
                    0)
                    return 0;
                return -1;
            }

            return -2;
        }
    }
    
    
    struct PointTwo
    {

        public double X { get; private set; }
        public double Y { get; private set; }

        public PointTwo(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double Distance(Point p)
        {
            return Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));
        }

        public override string ToString()
        {
            return $"Point. X: {this.X}, Y: {this.Y}";
        }
    }

    struct CircleTwo
    {
        public PointTwo center;
        public double Rad { get; private set; }

        public CircleTwo(double x, double y, double radius)
        {
            this.center = new PointTwo(x, y);
            this.Rad = radius;
        }

        public override string ToString()
        {
            return $"Circle. Radius: {Rad}, Center: {center}";  
        } 

        public int CompareTo(object? a)
        {
            if (a != null)
            {
                var x1 = this;
                var x2 = a as Circle;
                if (x1.Rad * x1.center.Distance(new Point(0, 0)) > x2.Rad * x2.center.Distance(new Point(0, 0)))
                    return 1;
                if (x1.Rad * x1.center.Distance(new Point(0, 0)) - x2.Rad * x2.center.Distance(new Point(0, 0)) ==
                    0)
                    return 0;
                return -1;
            }

            return -2;
        }
    }


    class Program
    {
        static void Main()
        {
            Random rand = new();
            var circles = new List<Circle>(rand.Next(3,11));

            for (int i = 0; i < circles.Count; i++)
            {
                double x = rand.Next(-10, 10);
                double y = rand.Next(-10, 10);
                double r = rand.Next(-10, 10);

                Circle circle = new Circle(x, y, r);
                circles.Add(circle);
            }
            
            // лямбда-выражение
            circles.Sort((t, o) =>
            {
                Point z = new Point(0, 0);
                return (t.Rad * t.center.Distance(z)).CompareTo(o.Rad * o.center.Distance(z));
            });
            // анонимный метод
            circles.Sort(delegate (Circle t, Circle o)
            {
                Point z = new Point(0, 0);
                return (t.Rad * t.center.Distance(z)).CompareTo(o.Rad * o.center.Distance(z));
            });
            // IComparable
            circles.Sort((circle, circle1) => circle.CompareTo(circle1));
        }
    }
}