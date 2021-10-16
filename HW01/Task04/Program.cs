using System;

namespace Task04
{
    //Получить от пользователя значения напряжения U и сопротивления R, вычислить силу тока
    //I = U/R и потребляемую мощность  P = U^2/R электрической цепи.
    class Program
    {
        static void Main(string[] args)
        {
            double U, R, I, P;
            double.TryParse(Console.ReadLine(), out U);
            double.TryParse(Console.ReadLine(), out R);
            I = U / R;
            Console.WriteLine("I = " + I);
            P = U * U / R;
            Console.WriteLine("P = " + P);
        }
    }
}