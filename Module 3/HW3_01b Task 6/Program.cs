using System;

namespace HW3_01b_Task_6
{
    class Plant
    {
        private double growth;
        private double photosensitibity;
        private double frostresistance;

        public Plant(double g, double p, double f)
        {
            this.growth = g;
            this.photosensitibity = p;
            this.frostresistance = f;
        }

        public double Photosensitivity
        {
            get => photosensitibity;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Photosensitivity must be between 0 and 100");
                }

                photosensitibity = value;
            }
        }

        public double FrostResistance
        {
            get => frostresistance;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Frost resistance must be between 0 and 100");
                }

                frostresistance = value;
            }
        }

        public double Growth
        {
            get => growth;
            set { growth = value; }
        }

        public override string ToString()
        {
            return $"Growth: {growth}, Photosensitivity: {photosensitibity}, Frost resistance: {frostresistance}";
        }
    }


    class Program
    {
        private static Random random = new Random(1119);

        private static Plant GeneratePlant()
        {
            double growth = random.NextDouble() * (75) + 25;
            double ps = random.NextDouble() * 100;
            double fs = random.NextDouble() * 100;
            return new Plant(growth, ps, fs);
        }

        private static int EvenOddSort(Plant x, Plant y)
        {
            {
                // явный тип параметров не обязателен
                if (x.Photosensitivity % 2 != 0 & y.Photosensitivity % 2 == 0) return 1;
                if (Math.Abs(x.Photosensitivity - y.Photosensitivity) < 0.0001) return 0;
                return -1; // верный порядок 
            }
        }
        
        static void Main(string[] args)
        {
            // Клавиша, определяющая, нужно ли завершить работу.
            ConsoleKeyInfo keyToExit;
            do
            {
                int n;
                string line;
                do
                {
                    Console.WriteLine("Введите количество растений");
                    line = Console.ReadLine();
                } while (!int.TryParse(line, out n));

                Plant[] plants = new Plant[n];
                for (int i = 0; i < plants.Length; i++)
                {
                    plants[i] = GeneratePlant();
                }

                Array.ForEach(plants, plant => Console.WriteLine(plant));

                Array.Sort(plants, // сортировка по убыванию:
                    delegate(Plant x, Plant y)
                    {
                        if (x.Growth < y.Growth) return 1; // нарушен порядок 
                        if (Math.Abs(x.Growth - y.Growth) < 0.0001) return 0;
                        return -1;
                    }
                );
                
                Array.ForEach(plants, plant => Console.WriteLine(plant));
                Array.Sort(plants, // сортировка по возрастанию:
                    (x, y) =>
                    {
                        if (x.FrostResistance > y.FrostResistance) return 1; // нарушен порядок 
                        if (Math.Abs(x.FrostResistance - y.FrostResistance) < 0.0001) return 0;
                        return -1;
                    }
                );
                Array.ForEach(plants, plant => Console.WriteLine(plant));
                Array.Sort(plants, EvenOddSort);
                Array.ForEach(plants, plant => Console.WriteLine(plant));
                Array.ConvertAll<Plant, Plant>(plants, (input) =>
                {
                    var res = (int)input.FrostResistance;
                    if (res % 2 == 0)
                    {
                        input.FrostResistance /= 3;
                    }
                    else
                    {
                        input.FrostResistance /= 2;
                    }

                    return input;
                });


                Console.WriteLine("Нажмите Escape для выхода, или любую другую клавишу для повтора решения.");
                keyToExit = Console.ReadKey();
            } while (keyToExit.Key != ConsoleKey.Escape);
        }
    }
}