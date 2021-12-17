using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Seminar12._11
{
    internal class Program
    {
        public class CoolException : Exception
        {

        }
        static void Main(string[] args)
        {
            try { 
                throw new CoolException();
            }
            catch (CoolException e)
            {
                Console.WriteLine($"0. {e.Message}");
            }
            try
            {
                int k = 1;
                int m = 0;
                int n = k / m;
            } catch (DivideByZeroException e)
            {
                Console.WriteLine($"1. {e.Message}");
            }
            try
            {
                int[] n = new int[1];
                int l = n[2];
            } catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"2. {e.Message}");
            }
            try
            {
                string s = "uwu";
                int k = (int)(s as object);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine($"3. {e.Message}");
            }
            try
            {
                Random r = new Random();
                r.Next(-1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"4. {e.Message}");
            }
            try
            {
                string k= null;
                string[] arr = new string[1];
                arr[0] = k;
                string l = arr[0].Normalize();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"5. {e.Message}");
            }
            checked
            {
                try
                {
                    int one = 780000000;
                    int three = one * one;
                    Console.WriteLine(three);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine($"6. {e.Message}");
                }
            }
            try
            {
                StreamReader reader = new StreamReader("file that doesnt exist.txt");
                reader.ReadToEnd();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"7. {e.Message}");
            }
            try
            {
                File.Create("temp2.txt");
                StreamReader reader = new StreamReader("temp2.txt");
                reader.ReadToEnd();
                reader.ReadLine();
            }
            catch (IOException e)
            {
                Console.WriteLine($"8. {e.Message}");
            }
            try
            {
                string dir = ("U:\\w\\u\\");
                Directory.SetCurrentDirectory(dir);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"9. {e.Message}");
            }
            try
            {
                var numbers= new List<int> { 1, 2, 3 };
                var firstgtf = numbers.Where(x => x > 5).First();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"10. {e.Message}");
            }

        }
    }
}
