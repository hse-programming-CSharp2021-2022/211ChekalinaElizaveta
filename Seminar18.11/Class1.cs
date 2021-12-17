using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    abstract class Figure
    {
        protected Point[] points;
        protected double length;

        public Figure(Point[] pts)
        {
            if (pts == null || pts.Length > 4 || pts.Length < 3)
            {
                throw new ArgumentException("Length must be 3 or 4");
            }
            points = new Point[pts.Length];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = pts[i];
            }
            this.length = pts[0].Distance(pts[1]);

        }

        abstract public double Radius { get; }
        abstract public double Length { get;}
        abstract public double Area
        { get; }
        public Point Center
        {
            get
            {
                double xsr = points[0].X, ysr = points[0].Y;
                for (int i = 1; i < points.Length; i++)
                {
                    xsr = xsr + points[i].X;
                    ysr = ysr + points[i].Y;
                }
                return new Point(xsr / points.Length, ysr / points.Length);
            }
        }

        public bool ClosenessZoneIntersects(Figure other)
        {
            return this.Radius + other.Radius >= this.Center.Distance(other.Center);
        }

        public override string ToString()
        {
            string s = $"{this.GetType()} Area: {this.Area:F3}, Side Length: {this.Length:F3}, Points:\n";
            for (int i = 0; i < points.Length; i++)
            {
                s += points[i].ToString() + " ";
            }
            return s;
        }

    }

    internal class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $"Point ({X:F3}, {Y:F3})";
        }

        public double Distance(Point other)
        {
            return Math.Sqrt((this.X - other.X) * (this.X - other.X) + (this.Y - other.Y) * (this.Y - other.Y));
        }
    }

    internal class EqTriangle : Figure
    {
        public override double Radius
        {
            get
            {
                return 2 * this.Length / Math.Sqrt(3);
            }
        }

        public override double Length
        {
            get
            {

                return this.length;
            }
        }
        public override double Area
        {
            get
            {
                return Math.Sqrt(3) * this.Length / 4;
            }
        }

        public EqTriangle(Point[] pts) : base(pts)
        {

        }

        public EqTriangle(Point botLeft, double len) : this(GetPointsForTriangle(botLeft, len))
        {
            if (len < 0)
            {
                throw new ArgumentException("Length can't be less than 0!");
            }
        }

        public static Point[] GetPointsForTriangle(Point botLeft, double len)
        {
            Point botRight = new Point(botLeft.X + len, botLeft.Y);
            double midX = (botLeft.X + botRight.X) / 2;
            double h = Math.Sqrt(3) * len / 2;
            double midY = botLeft.Y + h;
            Point[] points = new Point[3];
            points[0] = new Point(botLeft.X, botLeft.Y);
            points[1] = botRight;
            points[2] = new Point(midX, midY);
            return points;
        }
    }

    internal class Square : Figure
    {
        public Square(Point botLeft, double len) : this(GetPointsForSquare(botLeft, len))
        {
            if (len < 0)
            {
                throw new ArgumentException("Length can't be less than 0!");
            }
        }
        public Square(Point[] pts) : base(pts)
        {

        }

        public override double Radius
        {
            get
            {
                return this.Length * Math.Sqrt(2);
            }
        }

        public override double Length
        {
            get
            {
                return this.length;
            }
        }

        public override double Area {
            get
            {
                return this.Length * this.Length;
            }
        }

        public static Point[] GetPointsForSquare(Point botLeft, double len)
        {
            Point botRight = new Point(botLeft.X + len, botLeft.Y);
            Point topLeft = new Point(botLeft.X, botLeft.Y + len);
            Point botLeftcpy = new Point(botLeft.X, botLeft.Y);
            Point topRight = new Point(botLeft.X + len, botLeft.Y + len);
            return new Point[]{botLeftcpy, botRight, topLeft, topRight};
        }
    }
}
