using System;

namespace Seminar02
{

    public class Polygon
    {
        private int n; // число сторон
        private double radius; // радиус вписанной окружности

        public Polygon(int n, double radius)
        {
            this.n = n;
            this.radius = radius;
        }

        public Polygon()
        {
            this.n = 1;
            this.radius = 0;
        }
        public double Perimeter
        {
            get
            {
                // длина стороны
                double an = 2  * this.radius / Math.Cos(Math.PI/this.n) * Math.Sin(Math.PI / this.n);
                return an * this.n;
            }
        }

        public double Area => this.Perimeter * this.radius / 2;

        public string PolygonData()
        {
            return $"PolygonData: {this.n} sides, {this.radius} radius; {this.Perimeter} perimeter, {this.Area} area.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
         Console.Write("Введите число многоугольников: ");
            int num;
            int.TryParse(Console.ReadLine(), out num);
            Polygon[] array = new Polygon[num];
            double minS = 0;
            double maxS = 0;
            int minI = -1;
            int maxI = -1;
            for (int i = 0; i < num; i++)
            {
                Console.Write("Введите число сторон: ");
                int n;
                int.TryParse(Console.ReadLine(), out n);
                Console.Write("Введите радиус вписанной ок-ти: ");
                double k;
                double.TryParse(Console.ReadLine(), out k);
                Polygon poly = new Polygon(n, k);
                array[i] = poly;
                if (poly.Area < minS || minS == 0.0)
                {
                    minS = poly.Area;
                    minI = i;
                }
                if (poly.Area > maxS)
                {
                    maxS = poly.Area;
                    maxI = i;
                }
            }
            Console.WriteLine(minI + " " +  maxI + " " +  minS + " " + maxS);
            for (int i = 0; i < num; i++)
            {
                if (i == minI)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(array[i].PolygonData());
                    Console.ForegroundColor = ConsoleColor.Black;
                } else if (i == maxI)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(array[i].PolygonData());
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.WriteLine(array[i].PolygonData());
                }
            }

        }
    }
}
