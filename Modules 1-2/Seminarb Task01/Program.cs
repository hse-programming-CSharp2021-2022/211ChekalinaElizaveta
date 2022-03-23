using System;

namespace Seminarb_Task01
{
    class MyComplex
    {
        private double re, im;

        public MyComplex(double xre, double xim)
        {
            re = xre;
            im = xim;
        }

        public double Re
        {
            get
            {
                return this.re;
            }
        }

        public double Im
        {
            get
            {
                return this.im;
            }
        }

        public static MyComplex operator ++(MyComplex mc)
        {
            return new MyComplex(mc.re + 1, mc.im + 1);
        }
        
        public static MyComplex operator --(MyComplex mc)
        {
            return new MyComplex(mc.re - 1, mc.im - 1);
        }

        public static MyComplex operator +(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.Re + b.Re, a.Im + b.Im);
        }
        
        public static MyComplex operator -(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.Re - b.Re, a.Im - b.Im);
        }
        
        public static MyComplex operator *(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.Re * b.Re - a.Im * b.Im, a.Im*b.Re + a.Re*b.Im);
        }

        public static MyComplex operator /(MyComplex a, MyComplex b)
        {
            double re = (a.Re * b.Re + a.Im * b.Im) / (b.Re * b.Re + b.Im * b.Im);
            double im = (a.Im*b.Re - a.Re*b.Im) / (b.Re * b.Re + b.Im * b.Im);
            return new MyComplex(re,im);
        }

        public double Mod()
        {
            return Math.Abs(re * re + im * im);
        }

        public static bool operator true(MyComplex f)
        {
            if (f.Mod() > 1.0) return true;
            return false;
        }

        public static bool operator false(MyComplex f)
        {
            if (f.Mod() <= 1.0) return true;
            return false;
        }

        public override string ToString()
        {
            return "real=" + this.re + ", image=" + this.im;
        }
    }

    class Program
    {
        static void Main()
        {
            MyComplex c1 = new MyComplex(4, 3.3);
            Console.WriteLine("Модуль исходного комплексного числа = " +
                              c1.Mod());
            while (c1)
            {
                Console.Write("c1 => ");
                Console.WriteLine(c1);
                c1--;
            }

            Console.WriteLine("Модуль полученного числа = " +
                              c1.Mod());
            MyComplex a = new MyComplex(1, 6);
            MyComplex b = new MyComplex(2, 4);
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);

        }

    }
}