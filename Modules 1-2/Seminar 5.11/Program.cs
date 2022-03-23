using System;

namespace Seminar_5._11
{
    internal class Program
    {
        private static Random rand = new Random(119);
        class VideoFile
        {
            private string _name;
            private int _duration;
            private int _quality;

            public VideoFile(string name, int duration, int quality)
            {
                _name = name;
                _duration = duration;
                _quality = quality;
            }

            public int Size { get { return _duration*_quality; } }
            public override string ToString()
            {
                return $"VideoFile name:{_name}, duration: {_duration}, quality: {_quality}, size: {Size}";
            }

        }

        private static string GenerateName()
        {
            string s = "";
            int length = rand.Next(2, 10);
            
            for (int i = 0; i < length; i++)
            {
                int coin = rand.Next(2);
                string sym = ((char)rand.Next('a', 'z')).ToString();
                if (coin == 0)
                {
                    sym = sym.ToUpper();
                }
                s += sym;
                
            }
            return s;
        
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyToExit;
            do
            {
                int len = rand.Next(60, 361);
                int quality = rand.Next(100, 1001);
                string name = GenerateName();
                Console.WriteLine(new VideoFile(name, len, quality));
                int n = rand.Next(5, 16);
                VideoFile[] files = new VideoFile[n];
                for (int i = 0; i < n; i++)
                {
                    len = rand.Next(60, 361);
                    quality = rand.Next(100, 1001);
                    name = GenerateName();
                    VideoFile file = new VideoFile(name, len,quality);
                    files[i] = file;
                    Console.WriteLine($"File at index {i}: \t{file}");
                }
                Console.WriteLine($"Files with bigger size than {files[0].Size}:");
                int sizeFirst = files[0].Size;
                for (int i = 1; i < n; i++)
                {
                    if (files[i].Size > sizeFirst)
                    {
                        Console.WriteLine($"File at index {i}: \t{files[i]}");
                    }
                }

                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для повтора решения.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);

        }
    }
}
