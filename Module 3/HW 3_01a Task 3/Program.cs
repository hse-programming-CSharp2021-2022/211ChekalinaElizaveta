using System;

namespace HW_3_01a_Task_3
{
    internal delegate double DelegateConvertTemperature(double temp);

    internal class TemperatureConverterImp
    {
        public TemperatureConverterImp()
        {
            
        }
        public double FtoC(double temp)
        {
            return 9 * temp / 5 + 32;
        }
        public double CtoF(double temp)
        {
            return (temp - 32) * 5 / 9;
        }
    }

    internal static class StaticTempConverters
    {
        public static double KtoC (double temp)
        {
            return temp - 273.15;
        }

        public static double CtoK(double temp)
        {
            return temp + 273.15;
        }
        public static double CtoRa(double temp)
        {
            return CtoK(temp) * 9 / 5;
        }
        
        public static double RatoC(double temp)
        {
            return (temp - 491.67) * 5 / 9;
        }
        
        public static double CtoRe(double temp)
        {
            return temp * 0.8;
        }
        
        public static double RetoC(double temp)
        {
            return temp * 5 / 4;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            TemperatureConverterImp conv = new();
            double t = double.Parse(Console.ReadLine());
            DelegateConvertTemperature del1 = new(conv.CtoF);
            DelegateConvertTemperature del2 = new(conv.FtoC);
            Console.WriteLine(del1(t));
            Console.WriteLine(del2(t));
            DelegateConvertTemperature[] dels = new DelegateConvertTemperature[2];
            dels[0] = new DelegateConvertTemperature(conv.CtoF);
            dels[1] = new DelegateConvertTemperature(StaticTempConverters.CtoK);
            dels[1] += StaticTempConverters.CtoRa;
            dels[1] += StaticTempConverters.CtoRe;
            double t2 = double.Parse(Console.ReadLine());
            Console.WriteLine($"Температура по Фаренгейту: {dels[0](t2)}");
            Console.WriteLine(dels[0](t2));
            foreach (var del in dels[1].GetInvocationList())
            {
                string s = "";
                //Console.WriteLine(del.Method.Name);
                if (del.Method.Name == "CtoK")
                {
                    s = "Температура по Кельвину:";
                } else if (del.Method.Name == "CtoRa")
                {
                    s = "Температура по Ранкину:";
                }else if (del.Method.Name == "CtoRe")
                {
                    s = "Температура по Реомюру:";
                }
                Console.WriteLine($"{s} {del.DynamicInvoke(t2)}");
            }
            
            

        }
    }
}