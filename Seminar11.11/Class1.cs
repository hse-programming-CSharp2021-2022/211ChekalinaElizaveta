using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04Lib_Shape
{
    //2_03а задача 4
    class TestClass
    {
        public class Shape
        {
            public const double PI = Math.PI;
            protected double _x, _y;

            public Shape()
            {
            }

            public Shape(double x, double y)
            {
                _x = x;
                _y = y;
            }

            public virtual double Area()
            {
                return _x * _y;
            }
        }

        public class Circle : Shape
        {
            public Circle(double r) : base(r, 0)
            {
            }

            public override double Area()
            {
                return PI * _x * _x;
            }
        }

        public class Sphere : Shape
        {
            public Sphere(double r) : base(r, 0)
            {
            }

            public override double Area()
            {
                return 4 * PI * _x * _x;
            }
        }

        public class Cylinder : Shape
        {
            public Cylinder(double r, double h) : base(r, h)
            {
            }

            public override double Area()
            {
                return 2 * PI * _x * _x + 2 * PI * _x * _y;
            }
        }
        // раскомментируйте для решения . . .

       /* static void Main()
        {
            Random rand = new Random(119);
            ConsoleKeyInfo keyToExit;
            do
            {

                int n1, n2, n3;
                n1 = rand.Next(3, 6);
                n2 = rand.Next(3, 6);
                n3 = rand.Next(3, 6);
                Shape[] array = new Shape[n1 + n2 + n3];
                for (int i = 0; i < n1; i++)
                {
                    array[i] = new Circle(rand.NextDouble() * rand.Next(1, 6));
                    Console.WriteLine(array[i].Area());
                }
                for (int i = n1; i < n1 + n2; i++)
                {
                    array[i] = new Cylinder(rand.NextDouble() * rand.Next(1, 6), rand.NextDouble() * rand.Next(1, 6));
                    Console.WriteLine(array[i].Area());
                }
                for (int i = n1 + n2; i < array.Length; i++)
                {
                    array[i] = new Sphere(rand.NextDouble() * rand.Next(1, 6));
                    Console.WriteLine(array[i].Area());
                }
                Console.WriteLine();
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] is Circle)
                    {
                        Console.WriteLine($"Circle {i}: {array[i].Area()}");
                    }
                    else if (array[i] is Cylinder)
                    {
                        Console.WriteLine($"Cylinder {i}: {array[i].Area()}");
                    }
                    else if (array[i] is Sphere)
                    {
                        Console.WriteLine($"Sphere {i}: {array[i].Area()}");
                    }
                }
                Array.Sort(array, (obj, other) =>
                {
                    if (obj is Circle)
                    {
                        if (other is Circle)
                        {
                            return obj.Area().CompareTo(other.Area());
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else if (obj is Cylinder)
                    {
                        if (other is Circle)
                        {
                            return 1;
                        }
                        else if (other is Cylinder)
                        {
                            return obj.Area().CompareTo(other.Area());
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        if (other is Circle || other is Cylinder)
                        {
                            return 1;
                        }
                        return obj.Area().CompareTo(other.Area());
                    }
                });
                Console.WriteLine("After sorting:");
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] is Circle)
                    {
                        Console.WriteLine($"Circle {i}: {array[i].Area()}");
                    }
                    else if (array[i] is Cylinder)
                    {
                        Console.WriteLine($"Cylinder {i}: {array[i].Area()}");
                    }
                    else if (array[i] is Sphere)
                    {
                        Console.WriteLine($"Sphere {i}: {array[i].Area()}");
                    }
                }
                //Console.WriteLine("Area of Cylinder = {0:F2}", l.Area());
                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для повтора решения.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }*/
    }
}
/*
Output:
Area of Circle   = 28.27
Area of Sphere   = 113.10
Area of Cylinder = 150.80
*/


