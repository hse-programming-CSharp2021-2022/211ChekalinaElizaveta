using System;

namespace CW_10._02
{
    public class Point<T> : IComparable<Point<T>>
    {
        public T X { get; }
        public T Y { get; }
        public dynamic Distance { get; }

        public Point(T x, T y) =>
            (X, Y, Distance) =
            (x, y, Math.Sqrt(Math.Pow((dynamic) X, 2) + Math.Pow((dynamic) Y, 2)));

        public int CompareTo(Point<T> other) => Distance >= other.Distance ? 1 : -1;
    }

    class Program
    {
        static T Maximum<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        static void Main()
        {
            int n = 5;
            Point<int>[] points = new Point<int>[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                points[i] = new Point<int>(random.Next(0, 10), random.Next(0, 10));
                Console.WriteLine(points[i].X + " " + points[i].Y);
            }

            Point<int> max = points[0];
            for (int i = 1; i < n; i++)
            {
                max = Maximum(max, points[i]);
            }

            Console.WriteLine(max.X + " " + max.Y);
        }
    }
}