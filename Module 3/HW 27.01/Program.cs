using System;

namespace HW_27._01
{
    interface IFunction
    {
        double Function(double x);
    }

    public delegate double Calculate(double x);

    class F : IFunction
    {
        public Calculate Calculate;

        public F(Calculate func)
        {
            this.Calculate = func;
        }

        public double Function(double x)
        {
            return Calculate(x);
        }
    }

    class G
    {
        private F f, g;

        public G(F f, F g)
        {
            this.f = f;
            this.g = g;
        }

        public double GF(double x0)
        {
            return g.Function(f.Function(x0));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            do
            {
                G g = new G(new F(x => Math.Sin(x)), new F(x => x * x + 4));
                for (double i = 0.0; i <= Math.PI; i += Math.PI / 16)
                {
                    Console.WriteLine($"G(F({i:F4}))  =  {g.GF(i):F4}");
                }

                Console.WriteLine("Нажмите Esc для завершения программы и любую другую клавишу иначе");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}