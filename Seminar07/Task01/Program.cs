using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp23
{
    class Program
    {
        // преобразование массива строк в массив целых чисел
        public static int[] StringArrayToIntArray(string[] str)
        {
            int[] arr = null;
            if (str.Length != 0)
            {
                arr = new int[0];
                foreach (string s in str)
                {
                    int tmp;
                    if (int.TryParse(s, out tmp))
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = tmp;
                    }
                } // end of foreach (string s in str)      
            }

            return arr;
        } // end of StringToIntArray()

        static void WriteToFile(in int[] numbers, in string path)
        {
            // Создаем файл с данными
            try
            {
                if (File.Exists(path))
                {

                 StringBuilder builder = new StringBuilder();
                int k = 0;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (k < 4)
                    {
                        k++;
                        builder.Append(numbers[i] + " ");
                    }
                    else
                    {
                        k = 0;
                        builder.Append(numbers[i] + Environment.NewLine);
                    }
                }

                string createText = builder.ToString();
                File.WriteAllText(path, createText, Encoding.UTF8);
                
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }

        static void ReadIntsFromFile(in string path, out int[] nums)
        {
            nums = null;
            // Open the file to read from
            try
            {
                if (File.Exists(path))
                {
                    string readText = File.ReadAllText(path);
                    string[] stringValues = readText.Split();
                    nums = StringArrayToIntArray(stringValues);
                    Console.WriteLine("Прочитанный массив: ");
                    foreach (int i in nums)
                    {
                        Console.Write(i + " ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }

        static void GenerateArray(in int length, out int[] numbs)
        {
            var generator = new Random();
            numbs = new int[length];
            for (int i = 0; i < length; i++)
            {
                numbs[i] = generator.Next(10, 101);
            }
        }

        /// <summary>
        /// Считывает с клавиатуры одно целое число.
        /// </summary>
        /// <param name="num"></param>
        static void ReadNumber(string prompt, out int num)
        {
            do
            {
                Console.Write($"Введите {prompt}:");
            } while (!int.TryParse(Console.ReadLine(), out num) || num < 1);
        }

        /// <summary>
        /// Выводит на экран массив целых чисел через пробел
        /// </summary>
        /// <param name="array"></param>
        static void PrintArray(ref int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Формирует два индексных массива, с нечётными и чётными числами.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="oddIndices"></param>
        /// <param name="evenIndices"></param>
        static void OddEvenIntoArrs(in int[] array, out int[] oddIndices, out int[] evenIndices)
        {
            List<int> odds = new List<int>();
            List<int> evens = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evens.Add(i);
                }
                else
                {
                    odds.Add(i);
                }
            }

            oddIndices = odds.ToArray();
            evenIndices = evens.ToArray();
        }

        static void ReplaceWithZeros(ref int[] array, in int[] oddIndices)
        {
            for (int i = 0; i < oddIndices.Length; i++)
            {
                array[oddIndices[i]] = 0;
            }
        }

        static void Main(string[] args)
        {
            int k;
            ReadNumber("длину массива", out k);
            int[] numbers;
            GenerateArray(length: k, out numbers);
            Console.WriteLine("Сгенерированный массив:");
            PrintArray(ref numbers);
            string path = @"Data.txt";
            WriteToFile(in numbers, path);
            int[] numsRead;
            ReadIntsFromFile(path, out numsRead);
            int[] odds, evens;
            OddEvenIntoArrs(in numsRead, out odds, out evens);
            ReplaceWithZeros(ref numsRead, in odds);
            Console.WriteLine("После зануления нечётных: ");
            PrintArray(ref numsRead);
        } // end of Main()
    } // end of Program
}