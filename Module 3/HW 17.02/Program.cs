using System;
using System.IO;

namespace HW_17._02
{
    class Program
    {

        private static Random rnd = new();
        static void Main(string[] args)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; i++)
                    bw.Write(rnd.Next(1, 101));
            }

            int[] data = new int[10];

            using (BinaryReader br = new BinaryReader(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; i++)
                {
                    data[i] = br.ReadInt32();
                    Console.WriteLine(data[i]);
                }

                Console.WriteLine("Введите число:");
                int n = int.Parse(Console.ReadLine());
                int min = Math.Abs(n - data[0]), index = 0;
                for (int i = 1; i < 10; i++)
                {
                    if (Math.Abs(n - data[i]) < min)
                    {
                        min = Math.Abs(n - data[i]);
                        index = i;
                    }
                }
                data[index] = n;
            }
            using (BinaryWriter bw = new BinaryWriter(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; i++)
                    bw.Write(data[i]);
            }
            using (BinaryReader br = new BinaryReader(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; i++)
                {
                    data[i] = br.ReadInt32();
                    Console.Write(data[i] + " ");
                }
            }
        }
    }
}