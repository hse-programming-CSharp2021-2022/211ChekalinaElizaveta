using System;
using System.Collections.Generic;

namespace CW_3_03a_Task_5
{
    class Program
    {
        abstract class Animal
        {
            public int age; //возраст животного

            public Animal(int age)
            {
                Age = age;
            }

            public int Age
            {
                get { return age; }
                set { age = value; }
            }

            public string Descript()
            {
                return string.Format("{0}. Возраст: {1}", this.GetType().Name, Age);
            }
        }

        public interface IRun
        {
            //Бег
            string Run();
        }

        public interface IJump
        {
            //Прыжки
            string Jump();
        }

        class Cockroach : Animal, IRun
        {
            //Таракан – животное и может бегать
            public int speed;

            public Cockroach(int age, int speed) : base(age)
            {
                this.speed = speed;
            }

            public string Run()
            {
                return string.Format("Таракан бегает со скоростью {0} км/ч", speed);
            }
        }

        class Kangaroo : Animal, IJump
        {
            //Кенгуру животное и может прыгать
            public int length;

            public Kangaroo(int age, int length) : base(age)
            {
                this.length = length;
            }

            public string Jump()
            {
                return string.Format("Кенгуру прыгает на {0} м", length);
            }
        }

        class Cheetah : Animal, IRun, IJump
        {
            //Гепард животное, может бегать и
            ////прыгать
            int speed;
            int length;

            public Cheetah(int age, int speed, int length) : base(age)
            {
                this.speed = speed;
                this.length = length;
            }

            public string Run()
            {
                return string.Format("Гепард бегает со скоростью {0} км/ч", speed);
            }

            public string Jump()
            {
                return string.Format("Гепард прыгает на {0} м", length);
            }
        }

        class CockroachComparer : IComparer<Cockroach>
        {
            public int Compare(Cockroach a, Cockroach b)
            {
                return a.speed.CompareTo(b.speed);
            }
        }

        class AnimalComparer : IComparer<Animal>
        {
            public int Compare(Animal a, Animal b)
            {
                return a.Age.CompareTo(b.Age);
            }
        }

        class KangarooComparer : IComparer<Kangaroo>
        {
            public int Compare(Kangaroo a, Kangaroo b)
            {
                return a.length.CompareTo(b.length);
            }
        }

        static Animal[] GenZoo()
        {
            //Создание массива животных
            Animal[] Zoo;
            Random gen = new Random();
            Zoo = new Animal[10];
            for (int i = 0; i < 10; i++)
            {
                //0 –Таракан, 1 – Кенгуру, 2 - Гепард
                int AnimalType = gen.Next(0, 3);
                switch (AnimalType)
                {
                    case 0: //Таракан
                        Zoo[i] = new Cockroach(gen.Next(0, 5), gen.Next(3, 8));
                        break;
                    case 1: //Кенгуру
                        Zoo[i] = new Kangaroo(gen.Next(0, 30), gen.Next(1, 5));
                        break;
                    case 2: //Гепард
                        Zoo[i] = new Cheetah(gen.Next(0, 30),
                            gen.Next(70, 120), gen.Next(3, 8));
                        break;
                }
            }

            return Zoo;
        }

        static void Main(string[] args)
        {
            Animal[] Zoo = GenZoo(); //Создание массива животных
            foreach (Animal An in Zoo) //Вывод массива на экран
            {
                Console.WriteLine(An.Descript());
                if (An is IJump) //Если животное умеет прыгать
                    Console.WriteLine(((IJump) An).Jump());
                if (An is IRun) //Если животное умеет бегать
                    Console.WriteLine(((IRun) An).Run());
            }

            List<IJump> jump = new List<IJump>();
            List<IRun> run = new List<IRun>();
            foreach (var animal in Zoo)
            {
                if (animal is IJump)
                {
                    jump.Add(animal as IJump);
                }

                if (animal is IRun)
                {
                    run.Add(animal as IRun);
                }
            }

            foreach (var animal in jump)
            {
                animal.Jump();
            }

            foreach (var animal in run)
            {
                animal.Run();
            }

            List<Cockroach> cockroaches = new List<Cockroach>();
            foreach (var animal in Zoo)
            {
                if (animal is Cockroach)
                {
                    cockroaches.Add((Cockroach) animal);
                }
            }

            Cockroach[] roaches = cockroaches.ToArray();
            Array.Sort(roaches, new CockroachComparer());
            Console.WriteLine($"Таракан: {roaches[roaches.Length - 1].Run()}");
            Console.WriteLine();
            Array.Sort(Zoo, new AnimalComparer());
            for (var i = 0; i < Zoo.Length; i++)
            {
                Console.WriteLine(Zoo[i].Descript());
            }

            Console.WriteLine();
            List<Kangaroo> kangaroos = new List<Kangaroo>();
            for (var i = 0; i < Zoo.Length; i++)
            {
                if (Zoo[i] is Kangaroo)
                {
                    kangaroos.Add((Kangaroo) Zoo[i]);
                }
            }

            Console.WriteLine();
            Array.Sort(kangaroos.ToArray(), new KangarooComparer());
            for (var i = 0; i < Zoo.Length; i++)
            {
                Console.WriteLine(Zoo[i].Descript());
            }
        }
    }
}